using UnityEngine;
using System.Collections;

public class RespawnController : MonoBehaviour {

	public GameObject SceneController; // This will hold a reference to the SceneController Object.
	public GameObject SavedData; // This will hold a reference to the SavedData Object.

	void Start () {
		SceneController = GameObject.Find("SceneControllerObject"); // Get reference to the scene controller object.
		SavedData = GameObject.Find ("SavedData"); // Get reference to the saveddata object.
	}

	// This is called if either the boss or the player is killed.
	void PlayerOrBossDied () {
		SavedData.GetComponent<SavedData> ().SendMessage("SaveData"); // Save data needed for the boss and player respawn.
		SceneController.SendMessage("ChangeScene"); // Change Scene.
	}
}
