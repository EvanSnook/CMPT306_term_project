using UnityEngine;
using System.Collections;

public class BossMelee : MonoBehaviour {

    public GameObject meleePrefab;
    public float meleeDistance;
    public float coolDownTimer;
    public float meleeDuration;
    public float meleeSpeed;

    private GameObject player;
    private GameObject meleeAttack;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= meleeDistance)
        {
            meleeAttack = Instantiate(meleePrefab, transform.position, transform.rotation) as GameObject;
        }
    }
}
