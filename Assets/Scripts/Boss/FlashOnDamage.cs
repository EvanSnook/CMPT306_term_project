using UnityEngine;
using System.Collections;

public class FlashOnDamage : MonoBehaviour {
	public float FlashDuration;

	private SpriteRenderer Sprite;

	void Start() {
		Sprite = GetComponent<SpriteRenderer>();
	}

	public void ApplyDMG(int DMG) {
		Sprite.color = Color.white;
		StartCoroutine("RevertColor");
	}

	IEnumerator RevertColor() {
		yield return new WaitForSeconds(FlashDuration);
		Sprite.color = Color.red;
	}
}
