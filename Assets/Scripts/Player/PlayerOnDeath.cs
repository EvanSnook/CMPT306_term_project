using UnityEngine;
using System.Collections;

public class PlayerOnDeath : MonoBehaviour {

	public GameObject SceneController; // Contains a reference to the Scene Controller Object

	void OnDestroy() {
		SceneController.SendMessage("ChangeLevel"); // When the player is killed, change the sene
	}

}
