using UnityEngine;
using System.Collections;

public class UndirectedShield : MonoBehaviour {

    public float cooldownDuration;
    public float despawnTime;
    public GameObject shieldPrefab;

    private Quaternion angleToMouse;
    private Vector3 mousePosition;
    private GameObject shield;
    private bool canShield; // used for cooldownDuration to tel the player if it can UseShield

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

    void FixedUpdate()
    {
        //if the player has a shield active
        if (shield != null)
        {
            getMousePosition();

            //repositions the shield towards the mouse using the calculated position and angle of the mouse
            shield.transform.position = transform.position;
            shield.transform.rotation =  angleToMouse;
            shield.transform.Translate(Vector3.right);
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

            getMousePosition();
            
            //make the shield at the characters position pointed towards the mouse
            shield = Instantiate(shieldPrefab, transform.position, angleToMouse) as GameObject;

            //make player the parent of the shield so that it follows the players transform 
            shield.transform.parent = gameObject.transform;

            //start the cooldown to destroy the shield and to start the cooldown
            Destroy(shield, despawnTime);
            StartCoroutine("RefreshShieldCooldown");
        }
    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canShield = true;
    }
}
