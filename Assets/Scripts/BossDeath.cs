using UnityEngine;
using System.Collections;

public class BossDeath : MonoBehaviour {

	public GameObject SceneController; // This will hold a reference to the SceneController Object.
	public GameObject SavedData; // This will hold a reference to the SavedData Object.

	void Start () {
		SceneController = GameObject.Find("SceneControllerObject"); // Get a Reference to the scene controller Object.
		SavedData = GameObject.Find ("SavedData"); // Get a Referecne to the SavedData Object.
	}

    // This is called when the boss Dies.
	public void BossDied() {
		SavedData.GetComponent<SavedData>().SendMessage("SaveData"); // If the boss has Died send a message to save data.
		SceneController.SendMessage("ChangeScene"); // If the boss has died Sence a message to change the scene.
	}
}
