using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour {

	public bool GamePaused;
	public GameObject MainMenuButton;
	public GameObject QuitGameButton;

	void Start() {
		MainMenuButton = GameObject.Find ("MainMenuButton"); // This gets a reference to the MainMenuButton.
		QuitGameButton = GameObject.Find ("QuitGameButton"); // This gets a reference to the QuitGameButton.
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { // If the Player Hits the Excape key pause the game and open a menu.
			TogglePauseGame();
		}

		if (GamePaused) {
			MainMenuButton.SetActive (true);
			QuitGameButton.SetActive (true);
		} else {
			MainMenuButton.SetActive (false);
			QuitGameButton.SetActive (false);
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
