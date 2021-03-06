﻿using UnityEngine;
using System.Collections;

public class SmallPulse : MonoBehaviour {

    public float cooldownTimer;
    public float shieldRespawnTime;
    public float pulseDespawnTime;
    public float pulseGrowthRate;
    public GameObject shieldPrefab;
    public GameObject pulsePrefab;

    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private GameObject pulse;
    private GameObject shield;
    private bool canShield;

    // Use this for initialization
    void Start()
    {
        canShield = true;

        getMousePosition();

        //make shield and rotate it towards mouse
        shield = Instantiate(shieldPrefab, transform.position, angleToMouse) as GameObject;

        //parent the player to the shield and move the shield away a  bit
        shield.transform.parent = gameObject.transform;
        shield.transform.Translate(Vector3.right);
    }

    public void SetNumOfOrbs(int num)
    {
        //catch message
    }

    void Update()
    {
        //if a shield exists with 0 health - destroy it
        if (shield != null)
        {
            if (shield.GetComponent<Health>().HealthPoints <= 0)
            {
                DestroyShield();
            }
        }
    }

    void FixedUpdate()
    {

        if (pulse != null)
        {
            //make the shield and collider grow
            pulse.transform.localScale += new Vector3(pulseGrowthRate, pulseGrowthRate, 0);

        }

        if (shield != null)
        {
            getMousePosition();

            //reestablish the shields position towards the mouse
            shield.transform.position = transform.position;
            shield.transform.rotation = angleToMouse;
            shield.transform.Translate(Vector3.right);
        }
    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            gameObject.GetComponentInParent<PlayerController> ().startGlobalCooldown();

            //create the shield at players position
            pulse = Instantiate(pulsePrefab, transform.position, transform.rotation) as GameObject;
            pulse.SendMessage("SetOwner", gameObject.transform.parent.gameObject);
            //change the shields transparency so that other objects can be seen infront and behindit
            pulse.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);

            //start cooldowns
            Destroy(pulse, pulseDespawnTime);
            StartCoroutine("RefreshShieldCooldown");
        }
    }

    void getMousePosition()
    {
        // Get the Mouse Position on the screen
        mousePosition = Input.mousePosition;

        // subtract the cameras z axisfrom the mouse position to put the vecctor on the same plane as the game
        mousePosition.z = transform.position.z - Camera.main.transform.position.z;

        //change the cooridinate type from screen position of the computer to the world position within the game
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //get angle to the mouse from the gameObject
        angleToMouse = Quaternion.FromToRotation(Vector3.right, mousePosition - transform.position);
    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        canShield = true; ;
    }

    IEnumerator ShieldCooldown()
    {
        //Wait for cooldown then create a shield
        yield return new WaitForSeconds(shieldRespawnTime);
        createShield();
    }

    void createShield()
    {
        //make shield and parent it to the player
        shield = Instantiate(shieldPrefab, transform.position, transform.rotation) as GameObject;
        shield.transform.parent = gameObject.transform;
    }

    void DestroyShield()
    {
        //destroy shield and put it on cooldown
        Destroy(shield);
        StartCoroutine("ShieldCooldown");
    }
}
