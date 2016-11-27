﻿using UnityEngine;
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
    private Quaternion angleToPlayer;
    private Vector3 startAngleFromPlayer;
    private float edgeAt45DegOut;
    private int attackDirection;

    // Use this for initialization
    void Start () {
        isAttacking = false;
        onCooldown = false;
        setRadiusAt45();

        startAngleFromPlayer = new Vector3(startDistanceFromPlayer, startDistanceFromPlayer, 0f);
    }
	
    //creates a float thats on the edge of the boss 45 degrees out
    void setRadiusAt45()
    {
        float radius = transform.localScale.x / 2;
        edgeAt45DegOut = radius * Mathf.Cos(45 * Mathf.PI / 180);
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

                FindAngleOfAttack();

                meleeAttack = Instantiate(meleePrefab, transform.position, angleToPlayer) as GameObject;

                //parent the object to the boss
                meleeAttack.transform.parent = gameObject.transform;
                
                StartCoroutine("MeleeDuration");
                StartCoroutine("CooldownTimer");
            }
        }
        if(meleeAttack != null )
        {
            if (attackDirection != 0)
            {
                meleeAttack.transform.Rotate(0f, 0f, meleeSpeed * attackDirection);
            }
            else
            {
                //JAB
            }
        }
    }

    private void FindAngleOfAttack()
    {
        //top x works
        //bottom x distance too far
        //right y distance too close
        //left y works?
        if      ((player.transform.position.x > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y > 0) ||
                 (player.transform.position.x < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y < 0) ||
                 (player.transform.position.y > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x < 0) ||
                 (player.transform.position.y < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x > 0))
        {
            startAngleFromPlayer = new Vector3(startDistanceFromPlayer, startDistanceFromPlayer, 0f);
            angleToPlayer = Quaternion.FromToRotation(Vector3.zero, player.transform.position - transform.position + startAngleFromPlayer);
            attackDirection = -1;
        }
        else if ((player.transform.position.x > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y < 0) ||
                 (player.transform.position.x < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.y > 0) ||
                 (player.transform.position.y > gameObject.transform.position.x + edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x > 0) ||
                 (player.transform.position.y < gameObject.transform.position.x - edgeAt45DegOut && player.GetComponent<Rigidbody2D>().velocity.x < 0))
        {
            startAngleFromPlayer = new Vector3(-startDistanceFromPlayer, -startDistanceFromPlayer, 0f);
            angleToPlayer = Quaternion.FromToRotation(-Vector3.right, player.transform.position - transform.position - startAngleFromPlayer);
            attackDirection = 1;
        }

        else {
            angleToPlayer = Quaternion.FromToRotation(Vector3.right, player.transform.position - transform.position);
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
