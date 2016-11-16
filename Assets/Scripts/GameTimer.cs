using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

	public float GameCountdown; // This is the time in the Game Left before you fail.
	public float TimePerSkillPoint; // This is how often the player will recieve a skill point for time.
	public int SkillPointGain; // This is how many skill points are gained at each time point.
	public GameObject SavedData; // This is a reference to the saved data that will hold any information that is needed to not be lost. 


	void Start() {
		InvokeRepeating("SendSkillPoint", TimePerSkillPoint, TimePerSkillPoint); // This will repeatedly send skillpoints to the saved data.
		SavedData = GameObject.Find("SavedData"); // This finds and sets the Saved Data to the Saved Data Object.
	}

	void Update () {
		if (GameCountdown > 0) { // If the timer is not 0 then Count down.
			GameCountdown -= Time.deltaTime;
		} else if (GameCountdown < 0) { // If the Timer is below 0 then load game over screen.
			SceneManager.LoadScene("GameOver"); // Load the Game Over scene.
		}
	}

	/*
		This is the helper function that sends the number of skill points to the saved data.
	 */
	public void SendSkillPoint() {
		SavedData.SendMessage ("AddSkillPoints", SkillPointGain);

	}

}
