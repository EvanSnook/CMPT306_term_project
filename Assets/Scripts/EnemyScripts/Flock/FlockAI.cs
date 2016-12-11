using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FlockAI : MonoBehaviour {

	public FlockSightManager cohesionRange;
	public FlockSightManager alignmentRange;
	public FlockSightManager separationRange;
	public float cohesionFactor;
	public float alignmentFactor;
	public float separationFactor;
	public float inertiaFactor;
	public float chaseFactor;
	public float speed;
	public float headingInterval;

	private Rigidbody2D rb;
	private GameObject player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
		InvokeRepeating("Realign", 0, headingInterval);
	}

	void FixedUpdate() {
		if (player == null) {
			player = GameObject.FindWithTag ("Player");
		}
	}

	// Update is called once per frame
	void Realign () {
		Vector2 velocity = rb.velocity;
		velocity += (inertiaFactor * rb.velocity) + (alignmentFactor * calcAlignment()) + (cohesionFactor * calcCohesion()) + (separationFactor * calcSeparation()) + (chaseFactor * chasePlayer());
		velocity.Normalize();
		rb.velocity = velocity * speed;
		transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90, Vector3.forward);
	}

	Vector2 calcCohesion() {
		Vector2 result = new Vector2(0f, 0f);
		if (cohesionRange.otherFlock.Count == 0) {
			return result;
		}
		foreach (GameObject other in cohesionRange.otherFlock) {
			result.x += other.GetComponent<Rigidbody2D>().velocity.x;
			result.y += other.GetComponent<Rigidbody2D>().velocity.y;
		}
		result.x /= cohesionRange.otherFlock.Count;
		result.y /= cohesionRange.otherFlock.Count;
		result.Normalize();
		return result;
	}

	Vector2 calcAlignment() {
		Vector2 result = new Vector2(0f, 0f);
		if (alignmentRange.otherFlock.Count == 0) {
			return result;
		}
		foreach (GameObject other in alignmentRange.otherFlock) {
			result.x += other.transform.position.x;
			result.y += other.transform.position.y;
		}
		result.x /= alignmentRange.otherFlock.Count;
		result.y /= alignmentRange.otherFlock.Count;
		result = new Vector2(result.x - transform.position.x, result.y - transform.position.y);
		result.Normalize();
		return result;
	}

	Vector2 calcSeparation() {
		Vector2 result = new Vector2(0f, 0f);
		if (separationRange.otherFlock.Count == 0) {
			return result;
		}
		foreach (GameObject other in separationRange.otherFlock) {
			result.x += other.transform.position.x - transform.position.x;
			result.y += other.transform.position.y - transform.position.y;
		}
		result.x /= separationRange.otherFlock.Count;
		result.y /= separationRange.otherFlock.Count;
		result.x *= -1;
		result.y *= -1;
		//result = new Vector2(result.x - transform.position.x, result.y - transform.position.y);
		result.Normalize();
		return result;
	}

	Vector2 chasePlayer() {
		Vector2 result = new Vector2(0f, 0f);
		if (player != null) {
			result.x = player.transform.position.x - transform.position.x;
			result.y = player.transform.position.y - transform.position.y;
		}
		result.Normalize();
		return result;
	}
}
