using UnityEngine;
using System.Collections;

public class HitboxManager : MonoBehaviour {

	public PolygonCollider2D[] colliders;
	private PolygonCollider2D localCollider;

	// Use this for initialization
	void Start () {
		localCollider = GetComponent<PolygonCollider2D>();
	}

	public void SetHitBox (int hitBox) {
		localCollider.SetPath(0, colliders[hitBox].GetPath(0));
	}

	public void DestroySelf () {
		Destroy(gameObject);
	}
}
