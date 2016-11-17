using UnityEngine;
using System.Collections;

public class BasicRangedAttack : MonoBehaviour {

	private GameObject ProjectileLauncher; // This is the Projectile Launcher Object.
	public GameObject Player; // This is the player that is being targeted.
	public float DistanceFromCenter; // This is how far away the Projectile Launcher is from the center of the boss.

	void Start () {
		ProjectileLauncher = gameObject.transform.GetChild (0).gameObject; // This gets the child object which in this case is the projectile launcher.
	}

	void Update () {
		Vector3 PlayerPosition = Player.transform.position; // Get the Mouse Position.

		PlayerPosition.z = transform.position.z - Camera.main.transform.position.z;
		PlayerPosition = Camera.main.ScreenToWorldPoint(PlayerPosition);

		Quaternion AngleToPlayer = Quaternion.FromToRotation(Vector3.right, PlayerPosition - transform.position);

		ProjectileLauncher.transform.rotation = AngleToPlayer;
		// Current Problem is it is not rotating properly.
	}

}
