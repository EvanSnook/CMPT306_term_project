using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody2D rigidBody;

	void Start () {
		 rigidBody = GetComponent<Rigidbody2D>();
	}

	public void MoveUp (float velocity) {
		rigidBody.velocity += Vector2.up * velocity;
	}

	public void MoveDown (float velocity) {
		rigidBody.velocity += Vector2.down * velocity;
	}

	public void MoveLeft (float velocity) {
		rigidBody.velocity += Vector2.left * velocity;
	}

	public void MoveRight (float velocity) {
		rigidBody.velocity += Vector2.right * velocity;
	}

	/*
	SlowMovement can be used to slow horizontal movement of a rigidBody
	Effectively the same as drag except solely on the x axis
	*/
	public void SlowMovement () {
		rigidBody.velocity = new Vector2(rigidBody.velocity.x*0.5f, rigidBody.velocity.y);
	}

}
