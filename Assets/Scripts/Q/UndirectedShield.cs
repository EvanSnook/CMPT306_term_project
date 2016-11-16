using UnityEngine;
using System.Collections;

public class UndirectedShield : MonoBehaviour {

    public float cooldownDuration;
    public float despawnTime;
    public GameObject shieldPrefab;
    private GameObject shield;

    private bool canShield;

    void Start()
    {
        canShield = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;

            Vector3 MousePosition = Input.mousePosition; // Get the Mouse Position.

            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);
            shield = Instantiate(shieldPrefab, transform.position, AngleToMouse) as GameObject;


            shield.transform.parent = gameObject.transform;
            shield.transform.Translate(Vector3.right);

            Destroy(shield, despawnTime);
            StartCoroutine("RefreshShield");
        }
    }

    IEnumerator RefreshShield()
    {
        yield return new WaitForSeconds(cooldownDuration);

        canShield = true;
    }
}
