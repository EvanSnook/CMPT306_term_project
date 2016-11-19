using UnityEngine;
using System.Collections;

public class BasicRangedAttack : MonoBehaviour {

	private GameObject ProjectileLauncher; // This is the Projectile Launcher Object.
	public GameObject Player; // This is the player that is being targeted.
	public float DistanceFromCenter; // This is how far away the Projectile Launcher is from the center of the boss.
//	private GameObject Clone;

	void Start () {
		ProjectileLauncher = gameObject.transform.GetChild (0).gameObject; // This gets the child object which in this case is the projectile launcher.
	}

	void Update () {
		Vector3 PlayerPosition = Player.transform.position;

		Quaternion AngleToPlayer = Quaternion.FromToRotation(Vector3.up, PlayerPosition - transform.position );
//		Clone = Instantiate(ProjectileLauncher, transform.position, AngleToPlayer) as GameObject;

		ProjectileLauncher.transform.rotation = AngleToPlayer;
		ProjectileLauncher.transform.parent = gameObject.transform;
//		ProjectileLauncher.transform.Translate(new Vector3 (DistanceFromCenter, 0, 0));

//		Destroy(Clone, 2);
	}

}
