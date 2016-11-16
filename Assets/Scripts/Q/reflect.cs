using UnityEngine;
using System.Collections;

public class reflect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "EnemyShot")
        {
            Debug.Log(col);
            Destroy(col);
            //col.transform.rotation = new Quaternion(col.transform.rotation.x, col.transform.rotation.y, col.transform.rotation.z + 180, col.transform.rotation.w);
        }
    }
}
