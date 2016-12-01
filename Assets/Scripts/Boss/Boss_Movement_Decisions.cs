using UnityEngine;
using System.Collections;

public class Boss_Movement_Decisions : MonoBehaviour {

	private bool busy; // Sets to true after a decision is made, when the action finishes, is set back to true so the next action can take place
	private GameObject player;
	private Boss_Movement_Controller movementController;

	void Start() {
		busy = false;
		player = GameObject.FindWithTag ("Player");
		movementController = GetComponent<Boss_Movement_Controller>();
	}

	void FixedUpdate() {
		if (!busy) {
			Decide(MakeDecision());
		}
	}

	int MakeDecision() { // Hard coded to test decisions
		return 4;
	}

	void Decide(int decision) {
		switch (decision) {
			case 0:
				movementController.MoveTo(new Vector2());
			break;
			case 1:
				movementController.ChargeTo(new Vector2());
			break;
			case 2:
				movementController.Lunge(new Vector2());
			break;
			case 3:
				movementController.Persue(player);
			break;
			case 4:
				StartCoroutine(movementController.Orbit(player, 30, false, 1000));
			break;
		}
		busy = true;
	}

	public void SetBusy(bool setTo) {
		busy = setTo;
	}
}
