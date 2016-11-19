using UnityEngine;
using System.Collections;

public class ThreeOrbs : MonoBehaviour {


    public GameObject orbPrefab;
    public float cooldownDuration;
    public float orbSpeed;
    public float activeSpinSpeed;
    public float spinTime;
    public float orbDistance;

    private GameObject orb1;
    private GameObject orb2;
    private GameObject orb3;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private Vector3 orb2pos;
    private Vector3 orb3pos;
    private bool canShield;
    private bool orbsSpinning;

    // Use this for initialization
    void Start()
    {
        canShield = true;
        orbsSpinning = false;

        //create an orb
        orb1 = Instantiate(orbPrefab, transform.position, transform.rotation) as GameObject;
        orb2 = Instantiate(orbPrefab, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + (2f * 3.14f / 3f), transform.rotation.w)) as GameObject;
        orb3 = Instantiate(orbPrefab, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - (2f * 3.14f / 3f), transform.rotation.w)) as GameObject;

        //move the orbs a radius away from the player
        orb1.transform.Translate(orbDistance, 0f, 0f);
        orb2.transform.Translate(orbDistance, 0f, 0f);
        orb3.transform.Translate(orbDistance, 0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (orbFollowing){        }

        //reestablish the orbs position around the player in a new relative position
        orb1.transform.position = transform.position;
        orb2.transform.position = transform.position;
        orb3.transform.position = transform.position;
        
        //move the orbs a radius away from the player
        orb1.transform.Translate(orbDistance, 0f, 0f);
        orb2.transform.Translate(orbDistance, 0f, 0f);
        orb3.transform.Translate(orbDistance, 0f, 0f);

        if (orbsSpinning)
        {
            orb1.transform.Rotate(0f, 0f, activeSpinSpeed);
            orb2.transform.Rotate(0f, 0f, activeSpinSpeed);
            orb3.transform.Rotate(0f, 0f, activeSpinSpeed);
        }
        else
        {
            orb1.transform.Rotate(0f, 0f, orbSpeed);
            orb2.transform.Rotate(0f, 0f, orbSpeed);
            orb3.transform.Rotate(0f, 0f, orbSpeed);
        }

    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            orbsSpinning = true;

            //start cooldowns
            StartCoroutine("RefreshOrbCooldown");
            StartCoroutine("OrbFollow");
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
        yield return new WaitForSeconds(cooldownDuration);
        canShield = true;
    }
    IEnumerator OrbFollow()
    {
        yield return new WaitForSeconds(spinTime);
        orbsSpinning = false;
    }

}
