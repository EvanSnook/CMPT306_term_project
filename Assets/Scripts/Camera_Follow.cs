using UnityEngine;
using System.Collections;

public class Camera_Follow : MonoBehaviour {

	public GameObject player;
	public float dampeningFactor;

	private Vector3 velocity;

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		// Catch errors that may arrise from having the player die or disappear.
		if (player != null) {

			// Remove the Z axis from player position
			Vector3 destination = new  Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
			// SmoothDamp automatically smooths out motion between two points, given the pounts, velocity, and a dampeningFactor
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampeningFactor);
		}
	}
}
