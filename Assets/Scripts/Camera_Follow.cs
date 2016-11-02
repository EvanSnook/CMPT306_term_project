using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x,player.transform.position.y + 2.5f ,transform.position.z);
	}
}
