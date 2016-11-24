using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DMG : MonoBehaviour {
	//public string DMGTargetTag;
	public int DMGDone;
	public float DamageRepeatTime;
	public GameObject Owner;

	private List<GameObject> CollidingWith = new List<GameObject>();

	void SetOwner (GameObject OwnerIn) {
		Owner = OwnerIn;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		// If the colliding object has health and is not the owner
		if (coll.gameObject.GetComponent("Health") != null && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone); // Deal damage
			if (DamageRepeatTime > 0) { // If this can hit multiple times
				CollidingWith.Add(coll.gameObject); // Add the colliding object to the array of colliding objects
				StartCoroutine("DamageRepeat", coll.gameObject); // Call the repeating damage
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		// If the colliding object has health or bossHealth and is not the owner
		if ((coll.gameObject.GetComponent("Health") != null
		 			|| coll.gameObject.GetComponent("BossHealth") != null) && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone); // Deal damage
			if (DamageRepeatTime > 0) { // If this can hit multiple times
				CollidingWith.Add(coll.gameObject); // Add the colliding object to the array of colliding objects
				StartCoroutine("DamageRepeat", coll.gameObject); // Call the repeating damage
			}
		}
	}

// Remove the object from array of colliding gameObjects
	void OnCollisionExit2D(Collision2D coll) {
		if (CollidingWith.Contains(coll.gameObject)) {
			CollidingWith.Remove(coll.gameObject);
		}
	}

// Remove the object from array of colliding gameObjects
	void OnTriggerExit2D(Collider2D coll) {
		if (CollidingWith.Contains(coll.gameObject)) {
			CollidingWith.Remove(coll.gameObject);
		}
	}

// Damages the colliding object, then calls itself
	IEnumerator DamageRepeat(GameObject theObject) {
		yield return new WaitForSeconds(DamageRepeatTime);
		if (theObject != null) { // Check to make sure the object still exists to avoid errors
			if (CollidingWith.Contains(theObject)) { // If you are still colliding with the object

				theObject.SendMessage("ApplyDMG", DMGDone); // Damage object

				StartCoroutine("DamageRepeat", theObject); // and Call self
			}
		}
	}
}
