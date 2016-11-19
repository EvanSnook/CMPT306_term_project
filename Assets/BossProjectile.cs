using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

	public GameObject ProjectilePrefab;
	public float Speed;

	private GameObject Clone;


	void Update () {
		Clone = (Instantiate (ProjectilePrefab, transform.position, transform.rotation)) as GameObject; // Creates a new Rocket to fire forwards.
		Clone.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector3(0, Speed, 0)); // Launches the new Rocket forwards.

		Destroy (Clone, 2);

	}
}
