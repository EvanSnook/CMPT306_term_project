﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool canJump;

	void Start () {
		canJump = true;
	}

	void FixedUpdate () {
		if (Input.GetAxisRaw ("Horizontal") < -0.1) { // This get's the Horizontal input and checks to see if you are pushing the left or right key's.
			this.SendMessage ("MoveLeft");
		} else if (Input.GetAxisRaw ("Horizontal") > 0.1) {
			this.SendMessage ("MoveRight");
		} else {
			this.SendMessage("Stop"); // If you are grounded and not pressing a movement direction, stop fast.
		}
		this.SendMessage("SlowMovement"); // Apply linear drag.

		if (Input.GetAxisRaw("Jump") > 0.1 && canJump) { // This get's the input for the jump and sends message to jump if pushed.
			this.SendMessage ("Jump");
			canJump = false;
		} else if (Input.GetAxisRaw("Jump") < 0.1) {
			canJump = true;
		}
		if (Input.GetAxisRaw("Fire1") > 0.1) { // This get's the input for the fir and sends message to fire if pushed.
			this.SendMessage ("FireProjectileAtMouse");
		}
		if (Input.GetAxisRaw("Fire2") > 0.1) { // This get's the input for the fir and sends message to fire if pushed.
			this.SendMessage ("SwingAtMouse");
		}
        if (Input.GetAxisRaw("Defensive Ability") > 0.1) { // This get's the input for the Q and sends message to use shield if pushed.
            this.SendMessage("UseShield");
        }
    }
}