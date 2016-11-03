using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	void FixedUpdate () {
		if (Input.GetAxisRaw ("Horizontal") < -0.1) { // This get's the Horizontal input and checks to see if you are pushing the left or right key's.
			this.SendMessage ("MoveLeft");
		} else if (Input.GetAxisRaw ("Horizontal") > 0.1) {
			this.SendMessage ("MoveRight");
		}
		this.SendMessage("SlowMovement"); // If you aren't going left or right do SlowMovement.

		if (Input.GetAxisRaw("Jump") > 0.1) { // This get's the input for the jump and sends message to jump if pushed.
			this.SendMessage ("Jump");
		}
		if (Input.GetAxisRaw("Fire1") > 0.1) { // This get's the input for the fir and sends message to fire if pushed.
			this.SendMessage ("FireProjectileAtMouse");
		}
		if (Input.GetAxisRaw("Fire2") > 0.1) { // This get's the input for the fir and sends message to fire if pushed.
			this.SendMessage ("SwingAtMouse");
		}
	}
}
