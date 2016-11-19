using UnityEngine;
using System.Collections;

public class DamagingOrb : MonoBehaviour {

    public GameObject orbPrefab;
    public float cooldownDuration;
    public float orbSpeed;
    public float orbFollowTime;
    public float orbRadius;

    private GameObject orb;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private bool canShield;
    private bool orbFollowing;

    // Use this for initialization
    void Start()
    {
        canShield = true;
        orbFollowing = false;

        //create an orb
        orb = Instantiate(orbPrefab, transform.position, transform.rotation) as GameObject;

        //parent the player to the orb and move the orb away a bit
        orb.transform.parent = gameObject.transform;
        orb.transform.Translate(Vector3.right);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (orbFollowing)
        {
            getMousePosition();

            //reestablish the shields position towards the mouse
            orb.transform.position = transform.position;
            orb.transform.rotation = angleToMouse;
            orb.transform.Translate(orbRadius, 0f, 0f);

        }
        else if (orb != null)
        {

            //reestablish the orbs position around the player in a new relative position
            orb.transform.position = transform.position;
            orb.transform.Translate(orbRadius,0f,0f);
            orb.transform.Rotate(0f, 0f, orbSpeed);
        }
    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            orbFollowing = true;

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
        yield return new WaitForSeconds(orbFollowTime);
        orbFollowing = false;
    }

}
