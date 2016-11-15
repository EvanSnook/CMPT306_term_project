using UnityEngine;
using System.Collections;

public class DMG : MonoBehaviour {
	//public string DMGTargetTag;
	public int DMGDone;
	public GameObject Owner;

	void SetOwner (GameObject OwnerIn) {
		Owner = OwnerIn;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.GetComponent("Health") != null && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.GetComponent("Health") != null && coll.gameObject != Owner) {
			coll.gameObject.SendMessage("ApplyDMG", DMGDone);
		}
	}
}
