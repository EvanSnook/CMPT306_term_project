using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float ProjectileSpeed; // Movement Speed of the projectile.
	public GameObject ProjectilePrefab; // The Projectile that will be fired.
	private GameObject Clone; // The fired Projectile.

	public float CooldownTimer; // How long until can fire again.
	public float DestroyProjectileAfter; // How long until the shot projectile is automatically destroyed.

	private float Timer; // This is the the clock that keeps track of how much of a cooldown is left.
	private bool CanFire; // This keeps track of if you can fire or not.


	// Calls the fire method when holding down ctrl or mouse
	void FixedUpdate () {
		if (Timer <= 0) { // This Checks that the Cooldown Time has passed.
			CanFire = true;
		} else {
			Timer -= Time.deltaTime; // If the Cooldown Time hasn't Passed Keep counting down.
		}
	}


	// This Finds the Mouse and Fires a Projectile in the Mouses Direction.
	private void FireProjectileAtMouse() {
		if (CanFire) { // If Fire1 pressed and CanFire then FireProjectileAtMouse.
			CanFire = false;

			Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
			MousePosition.z = transform.position.z - Camera.main.transform.position.z;
			MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

			Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.up, MousePosition - transform.position);
			Clone = Instantiate(ProjectilePrefab, transform.position, AngleToMouse) as GameObject;
			Clone.GetComponent<Rigidbody2D>().AddForce(Clone.transform.up * ProjectileSpeed); // Launch Projectile forward to Mouse.
			Destroy (Clone, DestroyProjectileAfter); // Destroy Projectile after a certain time.

			Timer = CooldownTimer; // Set Cooldown Timer.
		}

	}

}
