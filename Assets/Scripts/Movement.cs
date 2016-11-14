using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float LeftRightMovementSpeed; // This is how fast movement left and right is.
	public float JumpSpeed; // This is how fast the jump is.
	public float horizontalDrag;
	public float horizontalFriction;
	public bool isGrounded;

	private bool airJump;

	void Start () {
		 rigidBody = GetComponent<Rigidbody2D>();
		 airJump = true;
	}

	public void MoveLeft () {
		//rigidBody.velocity += Vector2.left * LeftRightMovementSpeed;
		rigidBody.AddForce(Vector2.left * LeftRightMovementSpeed);
	}

	public void MoveRight () {
		//rigidBody.velocity += Vector2.right * LeftRightMovementSpeed;
		rigidBody.AddForce(Vector2.right * LeftRightMovementSpeed);
	}

	/*
	SlowMovement can be used to slow horizontal movement of a rigidBody
	Effectively the same as drag except solely on the x axis
	*/
	public void SlowMovement () {
		rigidBody.velocity = new Vector2(rigidBody.velocity.x*(1.0f - horizontalDrag), rigidBody.velocity.y);
	}

	/* Stop is used to stop movement when not pressing a horizontal movement
	direction and grounded*/
	public void Stop () {
		if (isGrounded) {
			rigidBody.velocity = new Vector2(rigidBody.velocity.x*(1.0f - horizontalFriction), rigidBody.velocity.y);
		}
	}

	//setting the player as grounded or not grounded on collisions
	public void OnCollisionEnter2D(Collision2D col){
		/*
		Checking if the collided object is tagged as ground, and if the normal of the collision is facing upwards.
		using >= 0 includes vertical walls as ground which allows for walljumping, but rejects the bottoms of platforms.
		*/
		if(col.gameObject.tag == "Ground" && col.contacts[0].normal.y >= 0){
			isGrounded = true;
			airJump = true;
		}
	}
	public void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag == "Ground"){
			isGrounded = false;
		}
	}

	//player cannot jump while grounded
	public void Jump() {
		if(isGrounded || airJump){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, JumpSpeed);
			if (!isGrounded) {
				airJump = false;
			}
		}

	}

}
