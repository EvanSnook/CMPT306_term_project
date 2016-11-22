using UnityEngine;
using System.Collections;

public class ToBossRoom : MonoBehaviour {

	public GameObject SceneControllerObject; // This is the object that holds the transition scripts for changeing scenes.

	void Start() {
		SceneControllerObject = GameObject.Find ("SceneControllerObject");
	}

	// When the Player collides with this gameobject then go to the Boss_room.
	void OnTriggerEnter2D(Collider2D other) {
		SceneControllerObject.GetComponent<SceneController>().SendMessage ("ChangeScene");
	}
}
