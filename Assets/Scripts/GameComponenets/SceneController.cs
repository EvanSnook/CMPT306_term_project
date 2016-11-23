using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string CurrentlyLoadedScene; // This holds the name of the currently loaded scene.
	private string LevelName; // This will hold the name of the scene that will be loaded if there needs to be a scene change.


	// This gets the scene that is currently loaded.
	void Start () {
		CurrentlyLoadedScene = SceneManager.GetActiveScene().name; // This gets the name of the scene that is currently loaded.
	}


	// This is called when the game is over and will go to the game over screen.
	public void ChangeSceneGameOver() {
		LevelName = "GameOver"; // This is the level name that the scene will be changed to.
		StartCoroutine ("ChangeLevel"); // This is the call to change scene.
	}


	// This looks at what the current scene is and then changes scene respectively.
	public void ChangeScene() {
		if (CurrentlyLoadedScene == "boss_room") { // If the current scene is boss_room then change scene to the spawn_room else, change to the boss_room. 
			LevelName = "spawn_room"; // This is the level name that the scene will be changed to.
			StartCoroutine ("ChangeLevel"); // This is the call to change scene.
		} else {
			LevelName = "boss_room"; // This is the level name that the scene will be changed to.
			StartCoroutine ("ChangeLevel"); // This is the call to change scene.
		}
	}


	// This changes the Scene to the Main Menu
	public void ChangeToMainMenu() {
		LevelName = "MainMenu";
		StartCoroutine ("ChangeLevel");
	}


	// This changes the Scene to the the spawn Room for starting a new game.
	public void StartGame() {
		LevelName = "spawn_room";
		StartCoroutine ("ChangeLevel");
	}


	// This changes the scene to the Scene called LevelName.
	IEnumerator ChangeLevel() {
		float FadeTime = gameObject.GetComponent<SceneTransition>().BeginFade(1); // This begins the fade between scenes.
		yield return new WaitForSeconds (FadeTime); // This makes it wait until it has fully faded out.
		SceneManager.LoadScene (LevelName); // This changes the scene.
	}


	// This Will Fade the Screen to black and Quit the game.
	public void ExitGame() {
		StartCoroutine ("QuitGame");
	}


	// This is called when quiting the game.
	IEnumerator QuitGame() {
		float FadeTime = gameObject.GetComponent<SceneTransition>().BeginFade(1); // This begins the fade between scenes.
		yield return new WaitForSeconds (FadeTime); // This makes it wait until it has fully faded out.
		Application.Quit(); // This Closes the application quiting the game.
	}




	// This is only used in the test scenes and will be removed in final product.
	public void ChangeTestScene() {
		if (CurrentlyLoadedScene == "TestScene1") { // This is for testing the change scene. 
			LevelName = "TestScene2";
			StartCoroutine ("ChangeLevel");
		} else {
			LevelName = "TestScene1";
			StartCoroutine ("ChangeLevel");
		}
	}

}
