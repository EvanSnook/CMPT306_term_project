﻿using UnityEngine;
using System.Collections;

public class Boss_Movement_Decisions : MonoBehaviour {

	public float moveTimeMin; // Minimum time to MoveTo before changing movement patterns (Measured in frames so values of around 500 are required)
	public float moveTimeMax; // Maximum time to MoveTo before changing movement patterns (Measured in frames so values of around 500 are required)
	public float pursueTimeMin; // Minimum time to pursue before changing movement patterns (Measured in frames so values of around 500 are required)
	public float pursueTimeMax; // Maximum time to pursue before changing movement patterns (Measured in frames so values of around 500 are required)
	public float orbitTimeMin; // Minimum time to do the orbit movement before changing movement patterns (Measured in frames so values of around 500 are required)
	public float orbitTimeMax; // Maximum time to orbit before changing movement patterns (Measured in frames so values of around 500 are required)
	public float orbitDistance; // Distance to "orbit" the player at

	private bool busy; // Sets to true after a decision is made, when the action finishes, is set back to true so the next action can take place
	private GameObject player;
	private Boss_Movement_Controller movementController;

	void Start() {
		busy = false;
		player = GameObject.FindWithTag ("Player");
		movementController = GetComponent<Boss_Movement_Controller>();
	}

	void FixedUpdate() {
		if (!busy) { // If you aren't busy, make a decision to do something and do it
			Decide(MakeDecision());
		}
	}

	bool RandomTrue() {
		if (Random.value < 0.5) {
			return true;
		}
		return false;
	}

	int MakeDecision() { // Hard coded to test decisions, will contain the decision tree
		return 2;
	}

	/* Call the appropiate movement method
	0 = MoveTo
	1 = ChargeTo
	2 = Lunge
	3 = Pursue
	4 = Orbit
	*/
	void Decide(int decision) {
		switch (decision) {
			case 0:
				StartCoroutine(movementController.MoveTo(new Vector2(), (int)Random.Range(moveTimeMin, moveTimeMax)));
			break;
			case 1:
				StartCoroutine(movementController.ChargeTo(new Vector2()));
			break;
			case 2:
				StartCoroutine(movementController.Lunge(player.transform.position));
			break;
			case 3:
				StartCoroutine(movementController.Pursue(player, (int)Random.Range(pursueTimeMin, pursueTimeMax)));
			break;
			case 4:
				StartCoroutine(movementController.Orbit(player, orbitDistance, RandomTrue(), (int)Random.Range(orbitTimeMin, orbitTimeMax)));
			break;
		}
		busy = true; // Set busy to true until the coroutine that was called sets it back to false
	}

	public void SetBusy(bool setTo) { // public accessor for busy so it can be called from the movement controller
		busy = setTo;
	}
}
