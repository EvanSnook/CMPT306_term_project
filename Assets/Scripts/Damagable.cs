using UnityEngine;
using System.Collections;

public class Damagable : MonoBehaviour {
	public int Health;

	void ApplyDMG(int DMGDone) {
		Health -= DMGDone;
	}
}
