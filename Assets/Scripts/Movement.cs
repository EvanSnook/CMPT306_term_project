using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float LeftRightMovementSpeed; // This is how fast movement left and right is.
	public float JumpSpeed; // This is how fast the jump is.


	void Start () {
		 rigidBody = GetComponent<Rigidbody2D>();
	}

	public void MoveLeft () {
		rigidBody.velocity += Vector2.left * LeftRightMovementSpeed;
	}

	public void MoveRight () {
		rigidBody.velocity += Vector2.right * LeftRightMovementSpeed;
	}

	/*
	SlowMovement can be used to slow horizontal movement of a rigidBody
	Effectively the same as drag except solely on the x axis
	*/
	public void SlowMovement () {
		rigidBody.velocity = new Vector2(rigidBody.velocity.x*0.5f, rigidBody.velocity.y);
	}


	public void Jump() { // Needs to no be able to jump when not on ground.
		rigidBody.velocity += Vector2.up * JumpSpeed;
	}

}
