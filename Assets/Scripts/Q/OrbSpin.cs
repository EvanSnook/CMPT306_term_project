using UnityEngine;
using System.Collections;

public class OrbSpin : MonoBehaviour {

    public GameObject orbPrefab;
    public int numberOfOrbs;
    public float cooldownTimer;
    public float orbRotateSpeed;
    public float activeSpinSpeed;
    public float activeSpinTime;
    public float orbRadius;

    private GameObject[] orbs;
    private bool canSpin;
    private bool orbsSpinning;

    // Use this for initialization
    void Start()
    {

        canSpin = true;
        orbsSpinning = false;

        //the orbs to be paired to the game objects
        orbs = new GameObject[numberOfOrbs];

        orbsSpinning = false;
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

            //reestablish the shields position around the player in a new relative position
            orbs[i].transform.position = gameObject.transform.position;

            //move the shieldss a radius away from the player
            orbs[i].transform.Translate(orbRadius, 0f, 0f);

            //set the shields new z rotation based on whether the orbs are spinning fast or regular
            if (orbsSpinning)
            {
                orbs[i].transform.Rotate(0f, 0f, activeSpinSpeed);
            }
            else
            {
                orbs[i].transform.Rotate(0f, 0f, orbRotateSpeed);
            }
        }
    }

    void UseShield()
    {
        if (canSpin)
        {
            canSpin = false;
            GetComponent<PlayerController> ().startGlobalCooldown();
            orbsSpinning = true;

            //start cooldowns
            StartCoroutine("RefreshOrbCooldown");
            StartCoroutine("OrbFollow");
        }
    }

    IEnumerator RefreshOrbCooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        canSpin = true;
    }
    IEnumerator OrbFollow()
    {
        yield return new WaitForSeconds(activeSpinTime);
        orbsSpinning = false;
    }
}
