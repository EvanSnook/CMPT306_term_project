using UnityEngine;
using System.Collections;

public class enemyshot : MonoBehaviour {

    public Vector2 Force;

	void Start () {
	    //pushes the bullet in the direction of Force
        GetComponent<Rigidbody2D>().AddForce(Force);
    }

}
