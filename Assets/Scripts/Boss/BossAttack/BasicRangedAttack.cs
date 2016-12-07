using UnityEngine;
using System.Collections;

public class BasicRangedAttack : MonoBehaviour {

	private GameObject projectileLauncher;
	private GameObject player;
    private GameObject projectile;
    private Vector3 futurePos;
    private Quaternion angleToPlayer;
    private bool canFire;

    public float futureTime;
    public GameObject ProjectilePrefab;
    public GameObject ProjectileLauncherPrefab;
    public float maxShootAngle;
    public float projectileSpeed;
    public float maxRange;
    public float minRange;
    public float Cooldown;
    public float DestroyAfter;

    void Start () {

        canFire = true;

        //creating the projectile launcer and parenting the boss to it
        projectileLauncher = (Instantiate(ProjectileLauncherPrefab, new Vector3(transform.position.x, transform.position.y, 0f), transform.rotation)) as GameObject;
        projectileLauncher.transform.parent = gameObject.transform;
    }


	void Update () {
		if (player == null) { // This checks to see if the player has been found. 
			player = GameObject.FindGameObjectWithTag ("Player"); // Find the player if not found already.
		} else {
			//if the player is withing the max and min range
			if (Vector3.Distance (player.transform.position, gameObject.transform.position) <= maxRange && Vector3.Distance (player.transform.position, gameObject.transform.position) >= minRange) {
				if (canFire == true) {
					canFire = false;

					//calculate where the player is headed too with futureTime
					futurePos = new Vector3 (player.transform.position.x + (player.GetComponent<Rigidbody2D> ().velocity.x * futureTime), player.transform.position.y + (player.GetComponent<Rigidbody2D> ().velocity.y * futureTime), player.transform.position.z);

					//finding the current angle to the player and the angle to where the player is going
					Quaternion angleToPlayer = Quaternion.FromToRotation (Vector3.right, player.transform.position - transform.position);
					Quaternion angleToFuture = Quaternion.FromToRotation (Vector3.right, futurePos - transform.position);

					//transforming the launcher to be nearby the player and around the outside of the boss
					projectileLauncher.transform.position = transform.position;
					projectileLauncher.transform.rotation = angleToPlayer;
					projectileLauncher.transform.Translate (new Vector3 (gameObject.transform.localScale.x / 2, 0f, 0f));

					// Creates a new projectile to fire and rotating it towards where the player is going
					projectile = (Instantiate (ProjectilePrefab, projectileLauncher.transform.position, projectileLauncher.transform.rotation)) as GameObject;
					projectile.transform.rotation = angleToFuture;
					projectile.GetComponent<DMG> ().Owner = this.gameObject; // Set the Owner of the projectile to the boss so it wont damage itself.

					// Launches the new projectile forwards
					projectile.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector3 (projectileSpeed, 0, 0)); 
					Destroy (projectile, DestroyAfter);
					StartCoroutine ("RefreshProjectile");
				}
			}
		}
    }

    IEnumerator RefreshProjectile()
    {
        yield return new WaitForSeconds(Cooldown);

        canFire = true;
    }
}
