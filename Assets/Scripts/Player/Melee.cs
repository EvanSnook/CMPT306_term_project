using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	public float cooldownDuration;
	public GameObject swing1Prefab;
	public GameObject swing2Prefab;
	public float swingSize;

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

			Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
			MousePosition.z = transform.position.z - Camera.main.transform.position.z;
			MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
			Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

			switch (comboState) {
				case 0:
					swing = Instantiate(swing1Prefab, transform.position, AngleToMouse) as GameObject;
					comboState = 1;
					break;
				case 1:
					swing = Instantiate(swing2Prefab, transform.position, AngleToMouse) as GameObject;
					comboState = 0;
					break;
				default:
					break;
			}
			swing.SendMessage("SetOwner", gameObject);
			swing.transform.localScale = new Vector3(swingSize, swingSize, swingSize);
			swing.transform.parent = gameObject.transform;

			StartCoroutine("RefreshSwing");
		}
	}

	IEnumerator RefreshSwing() {
		yield return new WaitForSeconds(cooldownDuration);

		canSwing = true;
	}
}
