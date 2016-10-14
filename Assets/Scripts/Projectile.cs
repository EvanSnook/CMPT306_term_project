using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public GameObject projectilePrefab; // This is the projectile that will be fired.
	public float speed = 10f; // This is the speed of the projectile.
	public GameObject clone; // This is the cloned Object.

	/* This method creates a projectile and fires it at the mouse Position.
	 * 
	 * Current Problem: Only creates object at mouse position, does not fire projectile at mouse position.
	 */
	void FireProjectileAtMouse () {
		Vector3 MouseInWorld = Camera.main.ScreenToWorldPoint (Input.mousePosition); // This get the position of the mouse in the worlds coordinates.

		Instantiate(projectilePrefab, MouseInWorld, Quaternion.Euler(MouseInWorld)); // Creates ProjectilePrefab at mouse position. 
	}


	// Calls the fire method when holding down ctrl or mouse
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			FireProjectileAtMouse();
		}
	}
}
