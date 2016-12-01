using UnityEngine;
using System.Collections;

public class Boss_Movement_Controller : MonoBehaviour {

	public float moveSpeed; // move speed of moveTo and persue
	public float chargeSpeed; // move speed of chargeTo
	public float lungeSpeed; // move speed of lunge
	public float orbitSpeed; // move speed of orbit

	private Boss_Movement_Decisions movementDecisions;

	void Start() {
		movementDecisions = GetComponent<Boss_Movement_Decisions>();
	}

	public void MoveTo(Vector2 destination) { // Moves at a slow speed to target location

	}

	public void ChargeTo(Vector2 destination) { // Charges at a high speed to target location after a short build up, overshoots

	}

	public void Lunge(Vector2 destination) { // Short distance charge after a short delay

	}

	public void Persue(GameObject target) { // Follows target gameObject at a slow speed

	}

	public IEnumerator Orbit(GameObject target, float distance, bool clockwise, int duration) { // Rotates around the target gameObject at a moderate speed
		Vector3 heading = target.transform.position - transform.position; // Get the direction towards the player
		heading = heading.normalized; // Normalize that direction
		heading = Vector3.Cross(heading, Vector3.forward); // Move it paralell
		heading = heading * distance; // Multiply that by the orbiting distance
		if (clockwise) { // Flip this orbit distance to the other side depending on direction specified
			heading = heading * -1;
		}
		heading = target.transform.position + heading; // Take the players position and transform it by the value we just calculated
		transform.position = Vector3.MoveTowards(transform.position, heading, orbitSpeed); // Move toward that position
		if (duration <= 0) {
			movementDecisions.SetBusy(false);
		} else {
			yield return new WaitForFixedUpdate();
			StartCoroutine(Orbit(target, distance, clockwise, duration - 1));
		}
	}
}
