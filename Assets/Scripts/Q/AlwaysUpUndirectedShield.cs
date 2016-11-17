using UnityEngine;
using System.Collections;

public class AlwaysUpUndirectedShield : MonoBehaviour {

    public GameObject shieldPrefab;
    public GameObject omniShieldPrefab;
    private GameObject shield;
    private GameObject omniShield;
    public float despawnTime;

    public float cooldownDuration;
    private bool canShield;
    // Use this for initialization
    void Start () {
        canShield = true;
        // Get the Mouse Position.
        Vector3 MousePosition = Input.mousePosition; 
        MousePosition.z = transform.position.z - Camera.main.transform.position.z;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        //get angle to mouse
        Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

        //make shield rotatedtowards player
        shield = Instantiate(shieldPrefab, transform.position, AngleToMouse) as GameObject;

        //parent the player to the shield and move the shield away a  bit
        shield.transform.parent = gameObject.transform;
        shield.transform.Translate(Vector3.right);
    }

    void Update()
    {
        if (shield.GetComponent<Health>().HealthPoints <= 0)
        {
            DestroyShield();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        // Get the Mouse Position.
        Vector3 MousePosition = Input.mousePosition; 
        MousePosition.z = transform.position.z - Camera.main.transform.position.z;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
            
        //get angle to mouse
        Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

        //reestablish the shields position towards the mouse
        shield.transform.position = transform.position;
        shield.transform.rotation = AngleToMouse;
        shield.transform.Translate(Vector3.right);
    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            //create shield and destroy it after the despawn time
            omniShield = Instantiate(omniShieldPrefab, transform.position, transform.rotation) as GameObject;
            omniShield.transform.parent = gameObject.transform;
            Destroy(omniShield, despawnTime);
            //refresh cooldown
            StartCoroutine("RefreshShieldCooldown");
        }
    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);

        canShield = true;
    }

    IEnumerator shieldCooldown()
    {
        yield return new WaitForSeconds(despawnTime);
        createShield();
    }

    void createShield()
    {
        shield = Instantiate(shieldPrefab, transform.position, transform.rotation) as GameObject;
        shield.transform.parent = gameObject.transform;
    }

    void DestroyShield()
    {
        Destroy(shield);
        StartCoroutine("shieldCooldown");


    }
}
