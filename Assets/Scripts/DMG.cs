using UnityEngine;
using System.Collections;

public class DMG : MonoBehaviour {
	public string DMGTargetTag;
	public float DMGDone;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == DMGTargetTag)
			coll.gameObject.SendMessage("ApplyAMG", DMGDone);

	}
}
