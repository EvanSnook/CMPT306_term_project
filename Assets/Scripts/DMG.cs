﻿using UnityEngine;
using System.Collections;

public class DMG : MonoBehaviour {
	//public string DMGTargetTag;
	public int DMGDone;

	void OnCollisionEnter2D(Collision2D coll) {
	//if (coll.gameObject.tag == DMGTargetTag)
		coll.gameObject.SendMessage("ApplyDMG", DMGDone);
	//}
}
