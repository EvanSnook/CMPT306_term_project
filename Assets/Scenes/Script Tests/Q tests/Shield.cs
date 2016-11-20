using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    public float cooldownDuration;
    public float despawnTime;
    public float radius;
    public GameObject shieldPrefab;

    private Vector3 mousePosition;
    private Quaternion angleToMouse;
    private GameObject shield;
    private bool canShield;

    void Start()
    {
        canShield = true;
    }

    // Update is called once per frame
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

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;

            getMousePosition();

            //created shield at characters position angled towards the  mouse
            shield = Instantiate(shieldPrefab, transform.position, angleToMouse) as GameObject;

            //parent the player to the shield
            shield.transform.parent = gameObject.transform;

            //move shield away from player
            shield.transform.Translate(new Vector3(radius, 0f, 0f));

            //destroythe shield in despawn time
            Destroy(shield, despawnTime);

            //startrefreshing the cooldown
            StartCoroutine("RefreshShield");
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

    IEnumerator RefreshShield()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canShield = true;
    }
}
