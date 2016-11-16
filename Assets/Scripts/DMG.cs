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
		if (coll.gameObject.GetComponent("Health") != null && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone);
			if (DamageRepeatTime > 0) {
				CollidingWith.Add(coll.gameObject);
				StartCoroutine("DamageRepeat", coll.gameObject);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.GetComponent("Health") != null && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone);
			if (DamageRepeatTime > 0) {
				CollidingWith.Add(coll.gameObject);
				StartCoroutine("DamageRepeat", coll.gameObject);
			}
		}
	}

	void OnCollisionExit2D(Collision2D coll) {
		if (CollidingWith.Contains(coll.gameObject)) {
			CollidingWith.Remove(coll.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D coll) {
		if (CollidingWith.Contains(coll.gameObject)) {
			CollidingWith.Remove(coll.gameObject);
		}
	}

	IEnumerator DamageRepeat(GameObject theObject) {
		yield return new WaitForSeconds(DamageRepeatTime);
		if (theObject != null) {
			if (CollidingWith.Contains(theObject)) {

				theObject.SendMessage("ApplyDMG", DMGDone);

				StartCoroutine("DamageRepeat", theObject);
			}
		}
	}
}
