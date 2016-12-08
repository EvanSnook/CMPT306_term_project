using UnityEngine;
using System.Collections;

public class Directable : MonoBehaviour {

    public float cooldownTimer;
    public float despawnTimer;
    public float radius;
    public GameObject shieldPrefab;

    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private GameObject shield;
    private bool canShield;

    void Start()
    {
        canShield = true;
    }

    void Update()
    {
        //if a shield exists with 0 health - destroy it
        if (shield != null)
        {
            if (shield.GetComponent<Health>().HealthPoints <= 0)
            {
                Destroy(shield);
            }
        }
    }

    public void SetNumOfOrbs(int num)
    {
        //catch message
    }

    void FixedUpdate()
    {
        //if the player has a shield active
        if (shield != null)
        {
            getMousePosition();

            //repositions the shield towards the mouse using the calculated position and angle of the mouse
            shield.transform.position = transform.position;
            shield.transform.rotation = angleToMouse;
            shield.transform.Translate(new Vector3(radius, 0f, 0f));
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

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            GetComponent<PlayerController> ().startGlobalCooldown();

            getMousePosition();

            //make the shield at the characters position pointed towards the mouse
            shield = Instantiate(shieldPrefab, transform.position, angleToMouse) as GameObject;

            //make player the parent of the shield so that it follows the players transform
            shield.transform.parent = gameObject.transform;

            //start the cooldown to destroy the shield and to start the cooldown
            Destroy(shield, despawnTimer);
            StartCoroutine("RefreshShieldCooldown");
        }
    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(cooldownTimer);
        canShield = true;
    }
}
