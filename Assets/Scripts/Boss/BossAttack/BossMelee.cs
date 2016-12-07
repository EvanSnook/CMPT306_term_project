using UnityEngine;
using System.Collections;

public class BossMelee : MonoBehaviour {

    public GameObject meleePrefab;
    public float meleeDistance;
    public float cooldownTimer;
    public float meleeDuration;
    public float meleeSpeed;
    public float futureTime;
    public float swingRadius;
    public float jabSpeed;

	public float MeleeLengthScale; // This will scale the length of the melee's attack.
	public float MeleeWidthScale; // This will scale the width of the melee's attack.

    private GameObject player;
    private GameObject meleeAttack;
    private bool isAttacking;
    private bool onCooldown;
    private Quaternion angleToFuture;
    private float edgeAt45DegOut;
    private float radius;
    private Vector3 futurePos;
    private int attackDirection;

    // Use this for initialization
    void Start () {
        isAttacking = false;
        onCooldown = false;
    }
	
    //creates a float thats on the edge of the boss 45 degrees out
    void setRadiusAt45()
    {
        radius = transform.localScale.x / 2;
        edgeAt45DegOut = radius * Mathf.Cos(45 * Mathf.PI / 180);
    }

	// Update is called once per frame
	void FixedUpdate () {

		if (player == null) { // If the player hasn't been found look for the player.
			player = GameObject.FindGameObjectWithTag ("Player"); // Find the Player and set the player to it.
		} else {

			//relocate the boss and player
			setRadiusAt45 ();

			if (Vector3.Distance (player.transform.position, gameObject.transform.position) <= meleeDistance) {
				if (!onCooldown) {
					isAttacking = true;
					onCooldown = true;
                
					FindAngleOfAttack ();

                    //make a new attack
                    meleeAttack = Instantiate(meleePrefab, new Vector3(transform.position.x, transform.position.y, 0f), angleToFuture) as GameObject;
					meleeAttack.GetComponent<DMG> ().Owner = this.gameObject; // Set the owner of the melee attack to the boss so it won't attack itself.

					meleeAttack.transform.localScale = new Vector3 (MeleeLengthScale, MeleeWidthScale, 0); // This will scale the meleeAttack to the scale input.

					//parent the object to the boss
					meleeAttack.transform.parent = gameObject.transform;
                
					//start cooldowns
					StartCoroutine ("MeleeDuration");
					StartCoroutine ("CooldownTimer");
				}
			}
			if (meleeAttack != null) {
				if (attackDirection != 0) {
					//reposition the attack to follow the boss
					meleeAttack.transform.position = gameObject.transform.position;

					//rotate the asttack to move it abit
					meleeAttack.transform.Rotate (0f, 0f, meleeSpeed * attackDirection);

					//translate the attack back out a ways
					meleeAttack.transform.Translate (swingRadius, 0f, 0f);
				} else {
					//translate the attack outward to stab at player
					meleeAttack.transform.Translate (jabSpeed, 0f, 0f);
				}
			}
		}
    }

    //find the players location around the boss and check where the player is headed too
    private void FindAngleOfAttack()
    {
        //calculate thwere the player is headed too with futureTime
        futurePos = new Vector3(player.transform.position.x + (player.GetComponent<Rigidbody2D>().velocity.x * futureTime), player.transform.position.y + (player.GetComponent<Rigidbody2D>().velocity.y * futureTime), player.transform.position.z);

        //check what quadrant the player is in aroynd the boss and what its velocity is
        if      ((player.transform.position.x > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y > 0) ||
                 (player.transform.position.x < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y < 0) ||
                 (player.transform.position.y > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x < 0) ||
                 (player.transform.position.y < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x > 0))
        {
            //assign the angle to the players future position
            angleToFuture = Quaternion.FromToRotation(Vector3.right, futurePos - transform.position);

            //in these cases the boss needs to swing in the negative direction of degrees
            attackDirection = -1;
        }
        //check what quadrant the player is in aroynd the boss and what its velocity is
        else if ((player.transform.position.x > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y < 0) ||
                 (player.transform.position.x < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y > 0) ||
                 (player.transform.position.y > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x > 0) ||
                 (player.transform.position.y < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x < 0))
        {
            //assign the angle to the players future position
            angleToFuture = Quaternion.FromToRotation(Vector3.right, futurePos - transform.position);

            //in these cases the boss needs to swing in the negative direction of degrees
            attackDirection = 1;
        }

        else {
            //assign the angle to the players current position
            angleToFuture = Quaternion.FromToRotation(Vector3.right, player.transform.position - transform.position);

            //the melee does not rotate because this is the jab attack
            attackDirection = 0;
        }
        

    }
    IEnumerator MeleeDuration()
    {
        yield return new WaitForSeconds(meleeDuration);
        Destroy(meleeAttack);
        isAttacking = false;
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTimer);
        onCooldown = false;
    }
}
