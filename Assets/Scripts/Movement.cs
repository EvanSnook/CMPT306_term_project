using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float LeftRightMovementSpeed; // This is how fast movement left and right is.
	public float JumpSpeed; // This is how fast the jump is.
	public bool isGrounded;

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

	//setting the player as grounded or not grounded on collisions
	public void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			isGrounded = true;
		}
	}
	public void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			isGrounded = false;
		}
	}

	//player cannot jump while grounded
	public void Jump() {
		if(isGrounded){
			rigidBody.velocity += Vector2.up * JumpSpeed;
		}
		
	}

}
