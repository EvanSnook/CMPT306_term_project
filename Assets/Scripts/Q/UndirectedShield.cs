using UnityEngine;
using System.Collections;

public class UndirectedShield : MonoBehaviour {

    public float cooldownDuration;
    public float despawnTime;
    public GameObject shieldPrefab;
    private GameObject shield;

    private bool canShield;
    private bool isShielding;

    void Start()
    {
        canShield = true;
        isShielding = false;
    }

    void Update()
    {
        if (shield.GetComponent<Health>().HealthPoints <= 0)
        {
            Destroy(shield);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShielding)
        {
            // Get the Mouse Position.
            Vector3 MousePosition = Input.mousePosition; 
            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            //getangleto the mouse
            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

            //repositions the shield towards the mouse
            shield.transform.position = transform.position;
            shield.transform.rotation =  AngleToMouse;
            shield.transform.Translate(Vector3.right);
        }
    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            isShielding = true;

            // Get the Mouse Position.
            Vector3 MousePosition = Input.mousePosition; 
            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            //get angle to mouse
            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

            //make the shield at the characters position pointed towards the mouse
            shield = Instantiate(shieldPrefab, transform.position, AngleToMouse) as GameObject;

            //make player the parent and movethe shield awayabit
            shield.transform.parent = gameObject.transform;
            shield.transform.Translate(Vector3.right);

            //start the cooldowns
            Destroy(shield, despawnTime);
            StartCoroutine("RefreshShield");
            StartCoroutine("RefreshShieldCooldown");
        }
    }

    IEnumerator RefreshShield()
    {
        yield return new WaitForSeconds(despawnTime);
        isShielding = false;
    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);

        canShield = true;
    }
}
