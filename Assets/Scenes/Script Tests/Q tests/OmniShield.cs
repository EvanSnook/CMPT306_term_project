using UnityEngine;
using System.Collections;

public class OmniShield : MonoBehaviour {

    public GameObject shieldPrefab;
    public GameObject omniShieldPrefab;
    public float cooldownDuration;
    public float despawnTime;
    public float radius;

    private GameObject shield;
    private GameObject omniShield;
    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private bool canShield;

    // Use this for initialization
    void Start()
    {
        canShield = true;

        getMousePosition();

        //make shield and rotate it towards mouse
        shield = Instantiate(shieldPrefab, transform.position, angleToMouse) as GameObject;

        //parent the player to the shield and move the shield away a  bit
        shield.transform.parent = gameObject.transform;
    }

    void Update()
    {
        //if a shield exists with 0 health - destroy it
        if (shield != null)
        {
            if (shield.GetComponent<Health>().HealthPoints <= 0)
            {
                DestroyShield();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shield != null)
        {
            getMousePosition();

            //reestablish the shields position towards the mouse
            shield.transform.position = transform.position;
            shield.transform.rotation = angleToMouse;
            shield.transform.Translate(new Vector3(radius, 0f, 0f));
        }
    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;

            //create shield 
            omniShield = Instantiate(omniShieldPrefab, transform.position, transform.rotation) as GameObject;

            //parent the shield to the player so that it follows the players transofrm
            omniShield.transform.parent = gameObject.transform;

            //destroy it after the despawn time
            Destroy(omniShield, despawnTime);

            StartCoroutine("RefreshShieldCooldown");
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

    IEnumerator ShieldCooldown()
    {
        //Wait for cooldown then create a shield
        yield return new WaitForSeconds(despawnTime);
        createShield();
    }

    void createShield()
    {
        //make shield and parent it to the player
        shield = Instantiate(shieldPrefab, transform.position, transform.rotation) as GameObject;
        shield.transform.parent = gameObject.transform;
    }

    void DestroyShield()
    {
        //destroy shield and put it on cooldown
        Destroy(shield);
        StartCoroutine("ShieldCooldown");
    }
}
