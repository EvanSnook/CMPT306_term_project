using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
            Debug.Log('a');
        }
    }
}
