using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	public float cooldownDuration;

	public float comboTimeout;
	public float pushIntensity;

	[Header("Swing Prefabs")]
	public GameObject swing1Prefab;
	public GameObject swing2Prefab;
	public GameObject swing3Prefab;
	
	[Header("Prefab Sizes")]
	[Range(0.1f, 1f)]
	public float swing1Size;
	[Range(0.1f, 1f)]
	public float swing2Size;
	[Range(0.1f, 1f)]
	public float swing3Size;
	[Space(20)]

	private GameObject swing; // The swing itself
	private bool canSwing;
	private int comboState;
	private float timeOfLastSwing;

	// Use this for initialization
	void Start () {
		canSwing = true;
		comboState = 0;
	}

	// Update is called once per frame
	void Update () {

	}

	void SwingAtMouse () {
		if (canSwing) {
			canSwing = false;
			if (Time.time - timeOfLastSwing > comboTimeout) {
				comboState = 0;
			}

			Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
			MousePosition.z = transform.position.z - Camera.main.transform.position.z;
			MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
			Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

			switch (comboState) {
				case 0:
					swing = Instantiate(swing1Prefab, transform.position, AngleToMouse) as GameObject;
					swing.transform.localScale = new Vector3(swing1Size, swing1Size, swing1Size);
					comboState = 1;
					break;
				case 1:
					swing = Instantiate(swing2Prefab, transform.position, AngleToMouse) as GameObject;
					swing.transform.localScale = new Vector3(swing2Size, swing2Size, swing2Size);
					comboState = 2;
					break;
				case 2:
					swing = Instantiate(swing3Prefab, transform.position, AngleToMouse) as GameObject;
					swing.transform.localScale = new Vector3(swing3Size, swing3Size, swing3Size);
					gameObject.SendMessage("Push", new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y).normalized * pushIntensity);
					comboState = 0;
					break;
				default:
					break;
			}
			swing.SendMessage("SetOwner", gameObject);
			swing.transform.parent = gameObject.transform;
			timeOfLastSwing = Time.time;

			StartCoroutine("RefreshSwing");
		}
	}

	IEnumerator RefreshSwing() {
		yield return new WaitForSeconds(cooldownDuration);

		canSwing = true;
	}
}
