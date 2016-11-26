using UnityEngine;
using System.Collections;

public class BossMelee : MonoBehaviour {

    public GameObject meleePrefab;
    public float meleeDistance;
    public float cooldownTimer;
    public float meleeDuration;
    public float meleeSpeed;
    public float startDistanceFromPlayer;

    private GameObject player;
    private GameObject meleeAttack;
    private bool isAttacking;
    private bool onCooldown;

	// Use this for initialization
	void Start () {
        isAttacking = false;
        onCooldown = false;
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= meleeDistance)
        {
            if (!onCooldown)
            {
                isAttacking = true;
                onCooldown = true;
                meleeAttack = Instantiate(meleePrefab, transform.position, transform.rotation) as GameObject;

                //parent the object to the boss
                meleeAttack.transform.parent = gameObject.transform;

                //positions the attack abit away from the player
                meleeAttack.transform.rotation = new Quaternion (player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y,0f,0f);

                StartCoroutine("MeleeDuration");
                StartCoroutine("CooldownTimer");
            }
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
