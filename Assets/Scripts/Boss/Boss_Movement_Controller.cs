using UnityEngine;
using System.Collections;

public class Boss_Movement_Controller : MonoBehaviour {

	public float moveSpeed; // move speed of moveTo and persue
	public float chargeSpeed; // move speed of chargeTo
	public float chargeOvershoot; // Distance to charge past its original target
	public float lungeSpeed; // move speed of lunge
	public int lungeWindUpTime; // time (in frames) before wind up before lunging
	public float lungeWindUpSpeed; // the speed at wich the boss moves backwards during the wind up
	public float lungeOvershoot; // Distance to lunge past its original target
	public float pursueSpeed; // move speed of pursue
	public float orbitSpeed; // move speed of orbit

	private Boss_Movement_Decisions movementDecisions;

	void Start() {
		movementDecisions = GetComponent<Boss_Movement_Decisions>();
	}

	public IEnumerator MoveTo(Vector3 destination, int duration) { // Moves at a slow speed to target location
		StopAllCoroutines(); // We don't want to be doing multiple movement routines at the same time, stop any active ones.
		if (duration <= 0) { // If the duration of this move is zero (or somehow below zero)
			movementDecisions.SetBusy(false); // Then we're done here, set busy to false so a new move can start
		} else {
			yield return new WaitForFixedUpdate(); // Otherwise, wait a frame
			StartCoroutine(MoveTo(destination, duration - 1)); // Wait for a frame, basically fixedUpdate
		}
	}

	public IEnumerator ChargeTo(Vector3 destination) { // Charges at a high speed to target location after a short build up, overshoots
		StopAllCoroutines(); // We don't want to be doing multiple movement routines at the same time, stop any active ones.
		Vector3 heading = (transform.position - destination).normalized * -1; // change the destination to a normalized heading

		while (Vector3.Distance(transform.position, destination) < chargeOvershoot // Keep charging if we are close to our destination (This allows for the overshoot)
						|| Vector3.Angle((transform.position - destination), heading) >= 90) { // OR if we are pointing towards our destination (No longer pointing towards it once we pass it)

			transform.position = Vector3.MoveTowards(transform.position, transform.position + heading, chargeSpeed); // Do the charging
			yield return new WaitForFixedUpdate(); // Wait for a frame, basically fixedUpdate
		}

		movementDecisions.SetBusy(false); // We're done the lunge, get ready to do another movement
	}

	public IEnumerator Lunge(Vector3 destination) { // Short distance charge after a short delay
		StopAllCoroutines(); // We don't want to be doing multiple movement routines at the same time, stop any active ones.
		// ----------------------------------WIND UP------------------------------------------------
		Vector3 heading = (transform.position - destination).normalized; // change the destination to a normalized heading
		for (int i=0; i < lungeWindUpTime; i++) { // Wind up for this many frames
			transform.position = Vector3.MoveTowards(transform.position, transform.position + heading, lungeWindUpSpeed); // Move back slowly to telegraph the attack
			yield return new WaitForFixedUpdate(); // Wait for a frame, basically FixedUpdate
		}
		// ---------------------------------------------------------------------------------------------
		// ----------------------------------------ACTUAL LUNGE-----------------------------------------------------
		heading = heading * -1; // Invert the heading, we want to move towards out destination now
		while (Vector3.Distance(transform.position, destination) < lungeOvershoot // Keep lunging if we are close to our destination (This allows for the overshoot)
						|| Vector3.Angle((transform.position - destination), heading) >= 90) { // OR if we are pointing towards our destination (No longer pointing towards it once we pass it)

			transform.position = Vector3.MoveTowards(transform.position, transform.position + heading, lungeSpeed); // Do the charging
			yield return new WaitForFixedUpdate(); // Wait for a frame, basically fixedUpdate
		}
		// ---------------------------------------------------------------------------------------------
		movementDecisions.SetBusy(false); // We're done the lunge, get ready to do another movement
	}

	public IEnumerator Pursue(GameObject target, int duration) { // Follows target gameObject at a slow speed
		StopAllCoroutines(); // We don't want to be doing multiple movement routines at the same time, stop any active ones.
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, pursueSpeed); // Move toward the position of the player

		if (duration <= 0) { // If the duration of this move is zero (or somehow below zero)
			movementDecisions.SetBusy(false); // Then we're done here, set busy to false so a new move can start
		} else {
			yield return new WaitForFixedUpdate(); // Otherwise, wait a frame
			StartCoroutine(Pursue(target, duration - 1)); // And recurse, reducing duration by 1
		}
	}

	public IEnumerator Orbit(GameObject target, float distance, bool clockwise, int duration) { // Rotates around the target gameObject at a moderate speed
		StopAllCoroutines(); // We don't want to be doing multiple movement routines at the same time, stop any active ones.

		Vector3 heading = target.transform.position - transform.position; // Get the direction towards the player
		heading = heading.normalized; // Normalize that direction
		heading = Vector3.Cross(heading, Vector3.forward); // Move it paralell
		heading = heading * distance; // Multiply that by the orbiting distance
		if (clockwise) { // Flip this orbit distance to the other side depending on direction specified
			heading = heading * -1;
		}
		heading = target.transform.position + heading; // Take the players position and transform it by the value we just calculated
		transform.position = Vector3.MoveTowards(transform.position, heading, orbitSpeed); // Move toward that position
		if (duration <= 0) { // If the duration of this move is zero (or somehow below zero)
			movementDecisions.SetBusy(false); // Then we're done here, set busy to false so a new move can start
		} else {
			yield return new WaitForFixedUpdate(); // Otherwise, wait a frame
			StartCoroutine(Orbit(target, distance, clockwise, duration - 1)); // Wait for a frame, basically fixedUpdate
		}
	}
}
