using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {

	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}

	void Push(Vector2 direction) {
		rigidBody.AddForce(direction);
	}
}
