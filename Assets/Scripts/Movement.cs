using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {

	private Rigidbody2D rigidBody;
	public float LeftRightMovementSpeed; // This is how fast movement left and right is.
	public float JumpSpeed; // This is how fast the jump is.
	public float horizontalDrag;
	public float horizontalFriction;

	private List<GameObject> groundedOn; // This list stores all of the objects the player is touching that are considered ground. If this list has one or more objects in it, the player is considered grounded.
	private bool airJump;

	void Start () {
		groundedOn = new List<GameObject>();
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
		if (groundedOn.Count > 0) {
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
			groundedOn.Add(col.gameObject); // Add the object to our list of grounded objects
			airJump = true;
		}
	}
	public void OnCollisionExit2D(Collision2D col){
		// If this was an object we were grounded on, remove it from our list. This could use some optimization by first checking if we are grounded at all before searching
		if(groundedOn.Contains(col.gameObject)){
			groundedOn.Remove(col.gameObject);
		}
	}

	//player cannot jump while grounded
	public void Jump() {
		// If we are grounded or have an airjump, we can jump.
		if(groundedOn.Count > 0 || airJump){
			rigidBody.velocity = new Vector2(rigidBody.velocity.x, JumpSpeed);
			// If we just jumped and were not grounded, we used our airJump.
			if (groundedOn.Count == 0) {
				airJump = false;
			}
		}

	}

}
