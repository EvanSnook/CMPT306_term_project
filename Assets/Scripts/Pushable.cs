using UnityEngine;
using System.Collections;

public class Pushable : MonoBehaviour {

	private Rigidbody2D rigidBody;

    // This gets the rigidbody2D of the object this is on.
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>();
	}

    // This will push the object that this script is on and will be pushed in the direction input.
	void Push(Vector2 direction) {
		rigidBody.AddForce(direction);
	}
}
