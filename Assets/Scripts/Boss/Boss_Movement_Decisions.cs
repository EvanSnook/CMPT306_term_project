using UnityEngine;
using System.Collections;

public class Boss_Movement_Decisions : MonoBehaviour {

	public float moveTimeMin; // Minimum time to MoveTo before changing movement patterns (Measured in frames so values of around 500 are required)
	public float moveTimeMax; // Maximum time to MoveTo before changing movement patterns (Measured in frames so values of around 500 are required)
	public float moveRange; // Potential range of random positions around player to move to
	public float pursueTimeMin; // Minimum time to pursue before changing movement patterns (Measured in frames so values of around 500 are required)
	public float pursueTimeMax; // Maximum time to pursue before changing movement patterns (Measured in frames so values of around 500 are required)
	public float orbitTimeMin; // Minimum time to do the orbit movement before changing movement patterns (Measured in frames so values of around 500 are required)
	public float orbitTimeMax; // Maximum time to orbit before changing movement patterns (Measured in frames so values of around 500 are required)
	public float orbitDistance; // Distance to "orbit" the player at
	public float waitTimeMin; // Minimum time to wait before changing movement patterns (Measured in frames so values of around 500 are required)
	public float waitTimeMax; // Maximum time to wait before changing movement patterns (Measured in frames so values of around 500 are required)

	public float closeThreshold; // Threshold for what is considered close range
	public float mediumThreshold; // Threshold for what is considered medium range

	private bool busy; // Sets to true after a decision is made, when the action finishes, is set back to true so the next action can take place
	private GameObject player;
	private Boss_Movement_Controller movementController;

	void Start() {
		busy = false;
		movementController = GetComponent<Boss_Movement_Controller>();
	}

	void FixedUpdate() {
		if (player == null) {
			player = GameObject.FindWithTag ("Player");
		} else {
			if (!busy) { // If you aren't busy, make a decision to do something and do it
				Decide(MakeDecision());
			}
		}
	}

	bool RandomTrue() { // Returns true or false at random
		if (Random.value < 0.5) {
			return true;
		}
		return false;
	}

	int MakeDecision() { // The decision tree
		float distancetoPlayer = Vector3.Distance(transform.position, player.transform.position);
		if (distancetoPlayer < closeThreshold) { // If the boss is in close range to the player
			switch ((int)Random.Range(0, 3)) { // Choose one at random
				case 0:
					return 0; // MoveTo
				break;
				case 1:
					return 2; // Lunge
				break;
				case 2:
					return 3; // Pursue
				break;
				case 3:
					return 5; // Wait
				break;
				default:
					return 0; // Just in case something goes wrong, MoveTo
				break;
			}
		} else if (distancetoPlayer < mediumThreshold) { // If the boss is in medium range of the player
			switch ((int)Random.Range(0, 3)) { // Choose one at random
				case 0:
					return 0; // MoveTo
				break;
				case 1:
					return 4; // Orbit
				break;
				case 2:
					return 3; // Pursue
				break;
				case 3:
					return 5; // Wait
				break;
				default:
					return 0; // Just in case something goes wrong, MoveTo
				break;
			}
		} else { // If the boss is in long range of the player
			return 1; // ChargeTo
		}
	}

	/* Call the appropiate movement method
	0 = MoveTo
	1 = ChargeTo
	2 = Lunge
	3 = Pursue
	4 = Orbit
	5 - Wait
	*/
	void Decide(int decision) {
		switch (decision) {
			case 0: // Call Moveto with a random location near the player
				StartCoroutine(movementController.MoveTo(player.transform.position + new Vector3(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange), 0), (int)Random.Range(moveTimeMin, moveTimeMax)));
			break;
			case 1: // Call ChargeTo with the players position as the target
				StartCoroutine(movementController.ChargeTo(player.transform.position));
			break;
			case 2: // Call Lunge with the players position as the target
				StartCoroutine(movementController.Lunge(player.transform.position));
			break;
			case 3: // Call Pursue with a reference to the player and a random time
				StartCoroutine(movementController.Pursue(player, (int)Random.Range(pursueTimeMin, pursueTimeMax)));
			break;
			case 4: // Call Orbit with a reference to the player, the orbit distance, a random direction, and a random time
				StartCoroutine(movementController.Orbit(player, orbitDistance, RandomTrue(), (int)Random.Range(orbitTimeMin, orbitTimeMax)));
			break;
			case 5: // Call Wait for a random time
				StartCoroutine(movementController.Wait(Random.Range(waitTimeMin, waitTimeMax)));
			break;
		}
		busy = true; // Set busy to true until the coroutine that was called sets it back to false
	}

	public void SetBusy(bool setTo) { // public accessor for busy so it can be called from the movement controller
		busy = setTo;
	}
}
