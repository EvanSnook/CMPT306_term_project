using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	public float cooldownDuration;
	public GameObject swingPrefab;
	public float swingSize;

	private GameObject swing; // The swing itself
	private bool canSwing;

	// Use this for initialization
	void Start () {
		canSwing = true;
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
			swing = Instantiate(swingPrefab, transform.position, AngleToMouse) as GameObject;
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
