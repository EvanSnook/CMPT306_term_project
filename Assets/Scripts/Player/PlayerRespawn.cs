using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject SceneController; // This will hold a reference to the SceneController Object.
	public GameObject SavedData; // This will hold a reference to the SavedData Object.

    void Start () {
        SceneController = GameObject.Find("SceneControllerObject"); // Get reference to the scene controller object.
		SavedData = GameObject.Find ("SavedData"); // Get reference to the saveddata object.
    }

    void PlayerDied () {
		SavedData.GetComponent<SavedData>().SendMessage("SaveData"); // Save data needed for when the Player dies
        SceneController.SendMessage("ChangeScene"); // Change Scene.
    }
}
