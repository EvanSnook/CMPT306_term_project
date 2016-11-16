using UnityEngine;
using System.Collections;

public class ScreenClearingPulse : MonoBehaviour {

    public float cooldownDuration;
    public float despawnTime;
    public GameObject shieldPrefab;

    private GameObject shield;
    private bool canShield;

    // Use this for initialization
    void Start () {
        canShield = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if(shield != null)
        {
            shield.transform.localScale += new Vector3(1f,1f,0); 
        }
	}

    void UseShield()
    {
        if (canShield)
        {
            canShield = false;
            shield = Instantiate(shieldPrefab, transform.position, transform.rotation) as GameObject;
            shield.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.5f);
            Destroy(shield,despawnTime);
            StartCoroutine("shieldCooldown");
        }
    }


    IEnumerator shieldCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canShield = true; ;
    }
}
