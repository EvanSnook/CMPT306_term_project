using UnityEngine;
using System.Collections;

public class BasicRangedAttack : MonoBehaviour {

	private GameObject projectileLauncher; // This is the Projectile Launcher Object.
	private GameObject player; // This is the player that is being targeted.
    private GameObject projectile;
    private Vector3 futurePos;
    private Quaternion angleToPlayer;
    private bool canFire;

    public float futureTime;
    public GameObject ProjectilePrefab;
    public GameObject ProjectileLauncherPrefab;
    public float Speed;
    public float maxRange;
    public float minRange;
    public float Cooldown;
    public float DestroyAfter;

    void Start () {
        projectileLauncher = (Instantiate(ProjectileLauncherPrefab, transform.position, transform.rotation)) as GameObject;
        projectileLauncher.transform.parent = gameObject.transform;
        canFire = true;
    }


	void Update () {

        player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= maxRange && Vector3.Distance(player.transform.position, gameObject.transform.position) >= minRange)
        {
            if (canFire == true)
            {
                canFire = false;

                //calculate there the player is headed too with futureTime
                futurePos = new Vector3(player.transform.position.x + (player.GetComponent<Rigidbody2D>().velocity.x * futureTime), player.transform.position.y + (player.GetComponent<Rigidbody2D>().velocity.y * futureTime), player.transform.position.z);

                Quaternion angleToPlayer = Quaternion.FromToRotation(Vector3.right, player.transform.position - transform.position );
                Quaternion angleToFuture = Quaternion.FromToRotation(Vector3.right, futurePos - transform.position);

                projectileLauncher.transform.position = transform.position;
                projectileLauncher.transform.rotation = angleToPlayer;
                projectileLauncher.transform.Translate(new Vector3(gameObject.transform.localScale.x / 2, 0f, 0f));

                // Creates a new Rocket to fire
                projectile = (Instantiate(ProjectilePrefab, projectileLauncher.transform.position, projectileLauncher.transform.rotation)) as GameObject;
                projectile.transform.rotation = angleToFuture;

                // Launches the new Rocket forwards
                projectile.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(Speed, 0, 0)); 
                Destroy(projectile, DestroyAfter);
                StartCoroutine("RefreshProjectile");
            }
        }
    }

    IEnumerator RefreshProjectile()
    {
        yield return new WaitForSeconds(Cooldown);

        canFire = true;
    }
}
