using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	[HideInInspector] public float GameCountdown; // This is the time in the Game Left before you fail. It is set from the Saved data object.
	public float TimePerSkillPoint; // This is how often the player will recieve a skill point for time.
	public int SkillPointGain; // This is how many skill points are gained at each time point.
	public GameObject SavedData; // This is a reference to the saved data that will hold any information that is needed to not be lost. 

	public GameObject SceneControllerObject; // This is a reference to the onject that changes scenes.

	void Start() {
		SavedData = GameObject.Find("SavedData"); // This finds and sets the Saved Data to the Saved Data Object.
		InvokeRepeating("SendSkillPoint", TimePerSkillPoint, TimePerSkillPoint); // This will repeatedly send skillpoints to the saved data.

		GameCountdown = SavedData.GetComponent<SavedData>().TimeRemaining; // This gets and sets the Time Remaining from the saved data.

		SceneControllerObject = GameObject.Find ("SceneControllerObject"); // This gets the reference to the sceneControllerObject.
	}

	// This runs to countdown and if it hits zero then it is game over.
	void Update () {
		if (GameCountdown > 0) { // If the timer is not 0 then Count down.
			GameCountdown -= Time.deltaTime;
		} else if (GameCountdown < 0) { // If the Timer is below 0 then load game over screen.
			SceneControllerObject.GetComponent<SceneController>().SendMessage("ChangeSceneGameOver"); // This sends a message to that the game is over.
		}
	}

	/*
		This is the helper function that sends the number of skill points to the saved data.
	 */
	public void SendSkillPoint() {
		SavedData.GetComponent<PlayerSavedData>().SendMessage ("AddSkillPoints", SkillPointGain);

	}

}
