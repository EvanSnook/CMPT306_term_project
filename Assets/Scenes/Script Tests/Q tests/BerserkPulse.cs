using UnityEngine;
using System.Collections;

public class BerserkPulse : MonoBehaviour {

    public float cooldownDuration;
    public float despawnTime;
    public float pulseDespawnTime;
    public float growthRate;
    public int damageMultiplier;
    public GameObject pulsePrefab;
    
    private GameObject pulse;
    private bool canInvuln;
    private bool isInvuln;
    private SpriteRenderer render;

    // Use this for initialization
    void Start()
    {
        canInvuln = true;
        isInvuln = false;

        //get the renderer for the object
        render = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (pulse != null)
        {
            //make the shield and collider grow 
            pulse.transform.localScale += new Vector3(growthRate, growthRate, 0);
            Destroy(pulse, pulseDespawnTime);
        }
        else
        {
            //create the shield at players position
            pulse = Instantiate(pulsePrefab, transform.position, transform.rotation) as GameObject;

            //change the shields color and transparency based on the players state
            if (isInvuln)
            {
                pulse.GetComponent<SpriteRenderer>().material.color = new Color(0.5f, 0.2f, 0.5f, 0.3f);
            }
            else
            {
                pulse.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0.1f);
                pulse.GetComponent<DMG>().DMGDone *= damageMultiplier;
            }

            //parent the player to the shield
            pulse.transform.parent = gameObject.transform;

            //start cooldowns
            
            StartCoroutine("RefreshCooldown");
        }

    }

    void UseShield()
    {
        if (canInvuln)
        {
            canInvuln = false;
            isInvuln = true;
            //change character color
            render.color = new Color(1f, 0f, 0.804f, 1f);
            
            //disable health so that the player takes no damage
            GetComponent<Health>().enabled = false;

            //start cooldowns
            StartCoroutine("RefreshInvuln");
            StartCoroutine("RefreshCooldown");
        }
    }

    IEnumerator RefreshCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canInvuln = true;

    }

    IEnumerator RefreshInvuln()
    {
        yield return new WaitForSeconds(despawnTime);
        isInvuln = false;

        //return the players color to normal
        render.color = new Color(0.56f, 0f, 0.56f, 1f);

        //enable health so the player can take damage again
        GetComponent<Health>().enabled = true;
    }
}
