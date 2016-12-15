using UnityEngine;
using System.Collections;

public class Unbreakable : MonoBehaviour
{

    public GameObject orbitingShieldPrefab;
    public GameObject empty;
    public float orbitShieldRespawnTime;
    public float orbitShieldSpeed;
    public float orbitShieldRadius;
    public float invulnDuration;
    public float invulnCooldown;
    public int numberOfShields;

    private GameObject[] orbitingShield;
    private GameObject[] shieldHolder;
    private bool canInvuln;
    private bool[] isRefreshing;

    // Use this for initialization
    void Start()
    {
        canInvuln = true;

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
            shieldHolder[i].transform.position = gameObject.transform.position;

            //move the shieldss a radius away from the player
            shieldHolder[i].transform.Translate(orbitShieldRadius, 0f, 0f);

            //set the shields new z rotation
            shieldHolder[i].transform.Rotate(0f, 0f, orbitShieldSpeed);
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
        if (canInvuln)
        {
            canInvuln = false;
            gameObject.GetComponentInParent<PlayerController> ().startGlobalCooldown ();

            for (int i = 0; i < numberOfShields; i++) {
                if (orbitingShield[i] != null) {
                    //change character color
                    orbitingShield[i].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f);

                    //disable health so that the player takes no damage
                    orbitingShield[i].GetComponent<Health>().enabled = false;
                }
            }

            //start cooldowns
            StartCoroutine("RefreshInvulnCooldown");
            StartCoroutine("RefreshInvuln");
        }
    }

    //refreshes invulnerability cooldown
    IEnumerator RefreshInvulnCooldown()
    {
        yield return new WaitForSeconds(invulnCooldown);
        canInvuln = true;
    }

    IEnumerator RefreshInvuln()
    {
        yield return new WaitForSeconds(invulnDuration);

        for (int i = 0; i < numberOfShields; i++)
        {
            if (orbitingShield[i] != null)
            {
                //change character color
                orbitingShield[i].GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0.804f, 1f);

                //disable health so that the player takes no damage
                orbitingShield[i].GetComponent<Health>().enabled = true;
            }
        }

    }

}
