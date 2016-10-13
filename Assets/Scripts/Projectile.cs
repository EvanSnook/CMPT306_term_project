using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	/*
	1. Create prjectile.
		
	2. Launch with force in direction of mouse
	3. If hit tag of platform/player/boss
	4. 

	 */

	public Rigidbody projectile;
	public float speed = 10f;

	void FireProjectile () {
		Rigidbody projectileClone = (Rigidbody) Instantiate(projectile, transform.position, transform.rotation);
		projectileClone.velocity = transform.forward * speed;

		// You can also acccess other components / scripts of the clone
		//		rocketClone.GetComponent<MyRocketScript>().DoSomething();
	}

	// Calls the fire method when holding down ctrl or mouse
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			FireProjectile();
		}
	}
}
