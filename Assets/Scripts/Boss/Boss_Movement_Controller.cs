using UnityEngine;
using System.Collections;

public class Boss_Movement_Controller : MonoBehaviour {

	public moveSpeed; // move speed of moveTo and persue
	public chargeSpeed; // move speed of chargeTo
	public lungeSpeed; // move speed of lunge
	public orbitSpeed; // move speed of orbit

	void moveTo(Vector2 destination) { // Moves at a slow speed to target location

	}

	void chargeTo(Vector2 destination) { // Charges at a high speed to target location after a short build up, overshoots

	}

	void lunge(Vector2 destination) { // Short distance charge after a short delay

	}

	void persue(GameObject target) { // Follows target gameObject at a slow speed

	}

	void orbit(GameObject target, float distance, bool clockwise) { // Rotates around the target gameObject at a moderate speed

	}
}
