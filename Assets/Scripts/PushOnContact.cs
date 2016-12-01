using UnityEngine;
using System.Collections;

public class PushOnContact : MonoBehaviour {

	// The intensity of the push
	public float intensity;

	void OnCollisionEnter2D(Collision2D coll) {
		// If collided object is pushable
		if (coll.gameObject.GetComponent("Pushable") != null) {
			// Push the object in the opposite direction of the normal
			coll.gameObject.SendMessage("Push", coll.contacts[0].normal.normalized * intensity * -1);
		}
	}
}
