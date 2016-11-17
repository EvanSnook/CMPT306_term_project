using UnityEngine;
using System.Collections;

public class Reflecter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "EnemyShot")
        {
            //reverses velocity
            col.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(col.gameObject.GetComponent<Rigidbody2D>().velocity.x * -1, col.gameObject.GetComponent<Rigidbody2D>().velocity.y * -1);

        }
    }
}
