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
        Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
        MousePosition.z = transform.position.z - Camera.main.transform.position.z;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);
        shield = Instantiate(shieldPrefab, transform.position, AngleToMouse) as GameObject;


        shield.transform.parent = gameObject.transform;
        shield.transform.Translate(Vector3.right);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

            Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.
            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

            shield.transform.position = transform.position;
            shield.transform.rotation = AngleToMouse;

            shield.transform.Translate(Vector3.right);
    }

    void UseShield()
    {
        canShield = false;

        omniShield = Instantiate(omniShieldPrefab, transform.position, transform.rotation) as GameObject;

        omniShield.transform.parent = gameObject.transform;

        Destroy(omniShield, despawnTime);
        StartCoroutine("RefreshShieldCooldown");

    }

    IEnumerator RefreshShieldCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);

        canShield = true;
    }
}
