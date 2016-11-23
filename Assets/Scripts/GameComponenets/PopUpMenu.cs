using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour {

	public bool GamePaused;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { // If the Player Hits the Excape key pause the game and open a menu.
			TogglePauseGame();
		}
		if (GamePaused) {

		}
	}

	// This pauses and resumes the game by alternating the time scale between 1 and 0.
	public void TogglePauseGame() {
		if (Time.timeScale == 0f) {
			Time.timeScale = 1f;
			GamePaused = false;
		} else {
			Time.timeScale = 0f;
			GamePaused = true;
		}
	}

}
