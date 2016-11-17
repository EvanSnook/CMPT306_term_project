using UnityEngine;
using System.Collections;

public class ReflectingShield : MonoBehaviour {

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

            // Get the Mouse Position.
            Vector3 MousePosition = Input.mousePosition;
            MousePosition.z = transform.position.z - Camera.main.transform.position.z;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

            //find angle to mouse
            Quaternion AngleToMouse = Quaternion.FromToRotation(Vector3.right, MousePosition - transform.position);

            //created shield at characters position angled towards the  mouse
            shield = Instantiate(shieldPrefab, transform.position, AngleToMouse) as GameObject;

            //parent the player to the shield
            shield.transform.parent = gameObject.transform;

            //move shield away from player
            shield.transform.Translate(Vector3.right);

            //destroythe shield in despawn time
            Destroy(shield, despawnTime);

            //startrefreshing the cooldown
            StartCoroutine("RefreshShield");
        }
    }

    IEnumerator RefreshShield()
    {
        yield return new WaitForSeconds(cooldownDuration);

        canShield = true;
    }

}
