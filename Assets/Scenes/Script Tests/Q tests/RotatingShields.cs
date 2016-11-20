using UnityEngine;
using System.Collections;

public class RotatingShields : MonoBehaviour {

    public GameObject ShieldPrefab;
    public float cooldownDuration;
    public float shieldRespawnTime;
    public float shieldSpeed;
    public float shieldRadius;
    public int numberOfShields;

    private GameObject[] shield;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private Vector3 shield2Pos;
    private Vector3 shield3Pos;
    private float degreeStep;
    private bool canShield;

    // Use this for initialization
    void Start()
    {
        canShield = false;

        shield = new GameObject[numberOfShields];

        //create the shields
        for (int i = 0; i < numberOfShields; i++)
        {
            shield[i] = Instantiate(ShieldPrefab, transform.position, transform.rotation) as GameObject;

            //positions the shields equally around the game object
            shield[i].transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, ((360 / numberOfShields) * i), transform.rotation.w);

            Debug.Log(((360 / numberOfShields) * i));
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < numberOfShields; i++)
        {
            if (shield[i] == null)
            {
                RefreshShield(i);
                //make invisible shield to follow

            }
            else
            {
                //reestablish the shieldss position around the player in a new relative position
                shield[i].transform.position = transform.position;

                //move the shieldss a radius away from the player
                shield[i].transform.Translate(shieldRadius, 0f, 0f);

                //set the shields new z rotation
                shield[i].transform.Rotate(0f, 0f, shieldSpeed);

            }
        }
    }

    void UseShield()
    {

        if (canShield)
        {
            canShield = false;

            getMousePosition();

            //start cooldowns
            StartCoroutine("RefreshOrbCooldown");
            StartCoroutine("OrbShoot");
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
        yield return new WaitForSeconds(cooldownDuration);
        canShield = true;
    }

    IEnumerator RefreshShield(int i)
    {
        yield return new WaitForSeconds(shieldRespawnTime);

        shield[i] = Instantiate(ShieldPrefab, transform.position, 
            new Quaternion(transform.rotation.x, transform.rotation.y,((360 / numberOfShields) * i), transform.rotation.w)) as GameObject;

    }
}
