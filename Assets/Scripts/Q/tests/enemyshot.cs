using UnityEngine;
using System.Collections;

public class enemyshot : MonoBehaviour {

    private Vector2 Force;
	// Use this for initialization
	void Start () {
	    Force = new Vector2(-50f,0f);
        GetComponent<Rigidbody2D>().AddForce(Force);
    }
	
	// Update is called once per frame
	void Update () {

        
	}
}
