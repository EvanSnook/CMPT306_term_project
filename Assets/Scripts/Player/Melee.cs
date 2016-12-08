using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	public float cooldownDuration; // Time between swings
	public float comboTimeout; // The time required between swings before the combo resets
	public float pushIntensity; // The intensity of the push forward on the third swing

	[Header("Swing Prefabs")] // The prefabs for each swing
	public GameObject swing1Prefab;
	public GameObject swing2Prefab;
	public GameObject swing3Prefab;

	[Header("Prefab Sizes")] // The size of each of the swings, (1.0 is HUGE.)
	[Range(0.1f, 1f)]
	public float swing1Size;
	[Range(0.1f, 1f)]
	public float swing2Size;
	[Range(0.1f, 1f)]
	public float swing3Size;

	private GameObject swing; // The swing itself
	private bool canSwing;
	private int comboState;
	private float timeOfLastSwing;

	// Use this for initialization
	void Start () {
		canSwing = true;
		comboState = 0;
	}

	void SwingAtMouse () {
		if (canSwing) { // Checks the swing cooldown
			canSwing = false; // Ensures no more swing
			GetComponent<PlayerController> ().startGlobalCooldown();

			if (Time.time - timeOfLastSwing > comboTimeout) { // If more time has passed since the last swing than our combo timeout, reset our combo
				comboState = 0;
			}
			timeOfLastSwing = Time.time; // Take note of the time of this swing

			// Loads of mysterious mouse things.
			Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
			MousePosition.z = transform.position.z - Camera.main.transform.position.z;
			MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
			Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

			switch (comboState) { // Spawn the right prefab for what combo state we are in
				case 0:
					swing = Instantiate(swing1Prefab, transform.position, AngleToMouse) as GameObject; // Spawn the object
					swing.transform.localScale = new Vector3(swing1Size, swing1Size, swing1Size); // Size the object
					comboState = 1; // Set the combo state to next
					break;
				case 1:
					swing = Instantiate(swing2Prefab, transform.position, AngleToMouse) as GameObject;
					swing.transform.localScale = new Vector3(swing2Size, swing2Size, swing2Size);
					comboState = 2;
					break;
				case 2:
					swing = Instantiate(swing3Prefab, transform.position, AngleToMouse) as GameObject;
					swing.transform.localScale = new Vector3(swing3Size, swing3Size, swing3Size);

					Vector2 vectorToMouse = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y); // Get a vector pointing towards the mouse
					gameObject.SendMessage("Push", vectorToMouse.normalized * pushIntensity); // Normalize that vector and scale it by our push intensity, then push ourselves towards that

					comboState = 0;
					break;
				default:
					break;
			}
			swing.SendMessage("SetOwner", gameObject); // Tell the swing hitbox not to hurt us
			swing.transform.parent = gameObject.transform; // Parent the swing to us

			StartCoroutine("RefreshSwing"); // Start the cooldown timer
		}
	}

	IEnumerator RefreshSwing() { // Sets canSwing to true, used to control the cooldown of swing
		yield return new WaitForSeconds(cooldownDuration);

		canSwing = true;
	}
}
