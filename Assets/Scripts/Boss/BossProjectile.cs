using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

	public GameObject ProjectilePrefab;
	public float Speed;

	public float Cooldown;
	public float DestroyAfter;

	private GameObject Clone;
	private bool canFire;

	void Start() {
		canFire = true;
	}


	void Update () {

		if (canFire == true) {
			canFire = false;
			Clone = (Instantiate (ProjectilePrefab, transform.position, transform.rotation)) as GameObject; // Creates a new Rocket to fire forwards.
			Clone.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector3 (0, Speed, 0)); // Launches the new Rocket forwards.

			Destroy (Clone, DestroyAfter);
			StartCoroutine ("RefreshShield");
		}
	}

	IEnumerator RefreshShield()
	{
		yield return new WaitForSeconds(Cooldown);

		canFire = true;
	}

}
