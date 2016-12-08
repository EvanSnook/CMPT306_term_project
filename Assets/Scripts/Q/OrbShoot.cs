using UnityEngine;
using System.Collections;

public class OrbShoot : MonoBehaviour {

    public GameObject orbPrefab;
    public int numberOfOrbs;
    public float cooldownTimer;
    public float orbRotateSpeed;
    public float orbShootSpeed;
    public float orbShootTime;
    public float orbRadius;

    private GameObject[] orbs;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private bool canShoot;
    private bool orbShooting;

    // Use this for initialization
    void Start()
    {
        canShoot = true;
        orbShooting = false;

        //the orbs to be paired to the game objects
        orbs = new GameObject[numberOfOrbs];

        //create the transforms and assign shields
        for (int i = 0; i < numberOfOrbs; i++)
        {
            //create a transfrom object
            orbs[i] = Instantiate(orbPrefab, transform.position, transform.rotation) as GameObject;

            //parent the object to the player
            orbs[i].transform.parent = gameObject.transform;


            //positions the shields equally around the game object
            orbs[i].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, ((360f / numberOfOrbs) * i)));
        }
        gameObject.BroadcastMessage("SetOwner", gameObject.transform.parent.gameObject);
    }

    public void SetNumOfOrbs(int num)
    {
        numberOfOrbs = num;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < numberOfOrbs; i++)
        {
            if (orbs[i] != null)
            {
                if (orbShooting)
                {
                    //move the orbs a radius away from the player
                    orbs[i].transform.Translate(orbShootSpeed, 0f, 0f);
                }
                else
                {
                    //reestablish the shields position around the player in a new relative position
                    orbs[i].transform.position = gameObject.transform.position;

                    //move the shieldss a radius away from the player
                    orbs[i].transform.Translate(orbRadius, 0f, 0f);

                    //set the shields new z rotation based on whether the orbs are spinning fast or regular
                    orbs[i].transform.Rotate(0f, 0f, orbRotateSpeed);
                }
            }
        }

    }

    void UseShield()
    {
        if (canShoot)
        {
            canShoot = false;
            GetComponent<PlayerController> ().startGlobalCooldown();
            orbShooting = true;

            getMousePosition();
            for (int i = 0; i < numberOfOrbs; i++)
            {
                orbs[i].transform.rotation = angleToMouse;
                //unparent the shot orb.
                orbs[i].transform.parent = null;
                //start cooldowns
                Destroy(orbs[i], orbShootTime);
            }
            StartCoroutine("RefreshOrbCooldown");
            StartCoroutine("OrbShootTimer");
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

    IEnumerator RefreshOrbCooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        canShoot = true;
    }
    IEnumerator OrbShootTimer()
    {
        yield return new WaitForSeconds(orbShootTime);
        orbShooting = false;

        for (int i = 0; i < numberOfOrbs; i++)
        {
            //create a transfrom object
            orbs[i] = Instantiate(orbPrefab, transform.position, transform.rotation) as GameObject;

            //parent the object to the player
            orbs[i].transform.parent = gameObject.transform;


            //positions the shields equally around the game object
            orbs[i].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, ((360f / numberOfOrbs) * i)));
        }
    }
}
