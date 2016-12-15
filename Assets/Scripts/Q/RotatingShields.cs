using UnityEngine;
using System.Collections;

public class RotatingShields : MonoBehaviour {

    public GameObject orbitingShieldPrefab;
    public GameObject activeShieldPrefab;
    public GameObject empty;
    public float activeShieldDuration;
    public float activeShieldCooldown;
    public float activeShieldRadius;
    public float orbitShieldRespawnTime;
    public float orbitShieldSpeed;
    public float orbitShieldRadius;
    public int numberOfShields;

    private GameObject[] orbitingShield;
    private GameObject[] shieldHolder;
    private GameObject activeShield;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private bool canShield;
    private bool[] isRefreshing;

    // Use this for initialization
    void Start()
    {
        canShield = true;

        //the shields to be paired to the game objects
        orbitingShield = new GameObject[numberOfShields];

        //game objects to hold a transform
        shieldHolder = new GameObject[numberOfShields];

        //locks the refreshing function if a shield is already being refreshed
        isRefreshing = new bool[numberOfShields];

        //create the transforms and assign shields
        for (int i = 0; i < numberOfShields; i++)
        {
            //initialize all refreshing to false
            isRefreshing[i] = false;

            //create a transfrom object
            shieldHolder[i] = Instantiate(empty, transform.position, transform.rotation) as GameObject;

            //parent the object to the player
            shieldHolder[i].transform.parent = gameObject.transform;

            //positions the shields equally around the game object
            shieldHolder[i].transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, ((360f / numberOfShields) * i)));

            //create a shield object at the transform object
            orbitingShield[i] = Instantiate(orbitingShieldPrefab, shieldHolder[i].transform.position, shieldHolder[i].transform.rotation) as GameObject;

            //set the rotation to the transforms rotation
            orbitingShield[i].transform.rotation = shieldHolder[i].transform.rotation;

            //parent the object to the transform
            orbitingShield[i].transform.parent = shieldHolder[i].transform;
        }
    }

    public void SetNumOfOrbs(int num)
    {
        numberOfShields = num;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < numberOfShields; i++)
        {
            //check if the shield has been destroyed and a coroutine has not yet been started to refresh it
            if (orbitingShield[i] == null && isRefreshing[i] == false)
            {
                isRefreshing[i] = true;

                //start the cooldown to make a new shield
                StartCoroutine("RefreshOrbitShield", i);
            }

            //reestablish the shields position around the player in a new relative position
            shieldHolder[i].transform.position = transform.position;

            //move the shieldss a radius away from the player
            shieldHolder[i].transform.Translate(orbitShieldRadius, 0f, 0f);

            //set the shields new z rotation
            shieldHolder[i].transform.Rotate(0f, 0f, orbitShieldSpeed);
        }

        if (activeShield != null)
        {
            getMousePosition();

            //repositions the shield towards the mouse using the calculated position and angle of the mouse
            activeShield.transform.position = transform.position;
            activeShield.transform.rotation = angleToMouse;
            activeShield.transform.Translate(new Vector3(activeShieldRadius, 0f, 0f));
        }

    }

    IEnumerator RefreshOrbitShield(int i)
    {
        yield return new WaitForSeconds(orbitShieldRespawnTime);

        //create a shield object at the transform object
        orbitingShield[i] = Instantiate(orbitingShieldPrefab, shieldHolder[i].transform.position, shieldHolder[i].transform.rotation) as GameObject;

        //set the rotation to the transforms rotation
        orbitingShield[i].transform.rotation = shieldHolder[i].transform.rotation;

        //parent the object to the transform
        orbitingShield[i].transform.parent = shieldHolder[i].transform;

        isRefreshing[i] = false;
    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            gameObject.GetComponentInParent<PlayerController> ().startGlobalCooldown ();

            getMousePosition ();

            //make the shield at the characters position pointed towards the mouse
            activeShield = Instantiate(activeShieldPrefab, transform.position, angleToMouse) as GameObject;

            //make player the parent of the shield so that it follows the players transform
            activeShield.transform.parent = gameObject.transform;

            //start the cooldown to destroy the shield and to start the cooldown
            Destroy(activeShield, activeShieldDuration);
            StartCoroutine("RefreshShieldCooldown");
        }
    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(activeShieldCooldown);
        canShield = true;
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
}
