using UnityEngine;
using System.Collections;

public class PlayerOnDeath : MonoBehaviour {

	public GameObject SceneController; // Contains a reference to the Scene Controller Object
	public GameObject SavedData; // Contains a reference to the Saved Data Object.

	void Start() {
		SceneController = GameObject.Find ("SceneControllerObject"); // This gets a reference to the Scene Controller Object.
		SavedData = GameObject.Find("SavdDataObject");
	}

	void OnDestroy() {
		// On player death we need to send a message to save all the information needed for next time you go to the boss room. such as: BossHealth, Timer, etc.
		SceneController.SendMessage("ChangeLevel"); // When the player is killed, change the sene
	}

}
