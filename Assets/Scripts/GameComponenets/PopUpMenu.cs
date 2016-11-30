using UnityEngine;
using System.Collections;

public class PopUpMenu : MonoBehaviour {

	public bool GamePaused; // This is set to true if the game time is set to 0 so the game is paused.
	public GameObject MainMenuButton; // This is a reference to the MainMenu Button.
	public GameObject QuitGameButton; // This is a reference to the QuitGame Button.
	public GameObject GamePausedText; // This is a reference to the GamePaused Text.

	public GameObject SceneControllerObject; // This is holds a reference to the scene controller object.

	void Start() {
		GamePausedText = GameObject.Find ("GamePausedText"); // This gets a reference to the GamePausedText.
		MainMenuButton = GameObject.Find ("MainMenuButton"); // This gets a reference to the MainMenuButton.
		QuitGameButton = GameObject.Find ("QuitGameButton"); // This gets a reference to the QuitGameButton.
		SceneControllerObject = GameObject.Find("SceneControllerObject"); // This gets a reference to the SceneControllerObject.
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) { // If the Player Hits the Excape key pause the game and open a menu.
			TogglePauseGame();
		}

		if (GamePaused) { // IF the game is paused then make the menu visible.
			GamePausedText.SetActive (true);
			MainMenuButton.SetActive (true); 
			QuitGameButton.SetActive (true);
		} else { // If the game is not paused make the menu not visible.
			GamePausedText.SetActive (false);
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

	// This unpauses the game and changes the scene to the menu.
	public void PopUpGoToMainMenu() {
		TogglePauseGame ();
		SceneControllerObject.GetComponent<SceneController> ().ChangeToMainMenu ();
	}

	// This unpauses the game and quits the game.
	public void PopUpQuitGame() {
		TogglePauseGame ();
		SceneControllerObject.GetComponent<SceneController> ().ExitGame ();
	}

}
