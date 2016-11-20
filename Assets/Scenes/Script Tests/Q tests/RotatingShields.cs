using UnityEngine;
using System.Collections;

public class RotatingShields : MonoBehaviour {

    public GameObject ShieldPrefab;
    public GameObject empty;
    public float cooldownDuration;
    public float shieldRespawnTime;
    public float shieldSpeed;
    public float shieldRadius;
    public int numberOfShields;

    private GameObject[] shield;
    private GameObject[] shieldHolder;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private Vector3 shield2Pos;
    private Vector3 shield3Pos;
    private float degreeStep;
    private bool canShield;
    private bool[] isRefreshing;

    // Use this for initialization
    void Start()
    {
        canShield = false;

        //the shields to be paired to the game objects
        shield = new GameObject[numberOfShields];

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
            shield[i] = Instantiate(ShieldPrefab, shieldHolder[i].transform.position, shieldHolder[i].transform.rotation) as GameObject;

            //set the rotation to the transforms rotation
            shield[i].transform.rotation = shieldHolder[i].transform.rotation;

            //parent the object to the transform
            shield[i].transform.parent = shieldHolder[i].transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < numberOfShields; i++)
        {
            //check if the shield has been destroyed and a coroutine has not yet been started to refresh it
            if (shield[i] == null && isRefreshing[i] == false)
            {
                isRefreshing[i] = true;

                //start the cooldown to make a new shield
                StartCoroutine("RefreshShield", i);
            }

            //reestablish the shields position around the player in a new relative position
            shieldHolder[i].transform.position = transform.position;

            //move the shieldss a radius away from the player
            shieldHolder[i].transform.Translate(shieldRadius, 0f, 0f);

            //set the shields new z rotation
            shieldHolder[i].transform.Rotate(0f, 0f, shieldSpeed);
        }
        
    }

    IEnumerator RefreshShield(int i)
    {
        yield return new WaitForSeconds(shieldRespawnTime);

        //create a shield object at the transform object
        shield[i] = Instantiate(ShieldPrefab, shieldHolder[i].transform.position, shieldHolder[i].transform.rotation) as GameObject;

        //set the rotation to the transforms rotation
        shield[i].transform.rotation = shieldHolder[i].transform.rotation;

        //parent the object to the transform
        shield[i].transform.parent = shieldHolder[i].transform;

        isRefreshing[i] = false;
    }
}
