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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isShielding)
        {
            Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

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

            Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);
            shield = Instantiate(shieldPrefab, transform.position, AngleToMouse) as GameObject;


            shield.transform.parent = gameObject.transform;
            shield.transform.Translate(Vector3.right);

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
