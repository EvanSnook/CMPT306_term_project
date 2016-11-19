using UnityEngine;
using System.Collections;

public class ThreeOrbs : MonoBehaviour {

    public GameObject orbPrefab;
    public float cooldownDuration;
    public float orbSpeed;
    public float activeSpinSpeed;
    public float spinTime;
    public float orbRadius;

    private GameObject orb1;
    private GameObject orb2;
    private GameObject orb3;
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
        orb1.transform.Translate(orbRadius, 0f, 0f);
        orb2.transform.Translate(orbRadius, 0f, 0f);
        orb3.transform.Translate(orbRadius, 0f, 0f);
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
        orb1.transform.Translate(orbRadius, 0f, 0f);
        orb2.transform.Translate(orbRadius, 0f, 0f);
        orb3.transform.Translate(orbRadius, 0f, 0f);

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
