using UnityEngine;
using System.Collections;

public class BasicRangedAttack : MonoBehaviour {

	private GameObject ProjectileLauncher; // This is the Projectile Launcher Object.
	private GameObject player; // This is the player that is being targeted.
    private Vector3 futurePos;
    private Quaternion angleToPlayer;

	public float DistanceFromCenter; // This is how far away the Projectile Launcher is from the center of the boss.
    public float futureTime;

	void Start () {
		ProjectileLauncher = gameObject.transform.GetChild (0).gameObject; // This gets the child object which in this case is the projectile launcher.
        ProjectileLauncher.transform.parent = gameObject.transform;
	}

	void Update () {

        player = GameObject.FindGameObjectWithTag("Player");

        //calculate thwere the player is headed too with futureTime
        futurePos = new Vector3(player.transform.position.x + (player.GetComponent<Rigidbody2D>().velocity.x * futureTime), player.transform.position.y + (player.GetComponent<Rigidbody2D>().velocity.y * futureTime), player.transform.position.z);

        Quaternion angleToPlayer = Quaternion.FromToRotation(Vector3.right, player.transform.position - transform.position );
        Quaternion angleToFuture = Quaternion.FromToRotation(Vector3.right, futurePos - transform.position);

        ProjectileLauncher.transform.position = transform.position;
        ProjectileLauncher.transform.rotation = angleToPlayer;
        ProjectileLauncher.transform.Translate(new Vector3(gameObject.transform.localScale.x / 2, 0f, 0f));
    }

}
