using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string CurrentlyLoadedScene; // This holds the name of the currently loaded scene.
	private string LevelName; // This will hold the name of the scene that will be loaded if there needs to be a scene change.
    private GameObject savedData;// the save data object that holds all the data to be saved.

    // This gets the scene that is currently loaded.
    void Start () {
        savedData = GameObject.Find("SavedData"); // This gets a reference to the SavedData Object.
        CurrentlyLoadedScene = SceneManager.GetActiveScene().name; // This gets the name of the scene that is currently loaded.
	}


	// This is called when the game is over and will go to the game over screen.
	public void ChangeSceneGameOver() {
		LevelName = "GameOver"; // This is the level name that the scene will be changed to.
		StartCoroutine ("ChangeLevel"); // This is the call to change scene.
	}

    public void ChangeSceneControls () {
        LevelName = "Controls"; // This is the level name that the scene will be changed to.
        StartCoroutine ("ChangeLevel"); // This is the call to change scene.
    }

    // This looks at what the current scene is and then changes scene respectively.
    public void ChangeScene() {
        savedData = GameObject.Find("SavedData");// save data before changing the level.
        switch (CurrentlyLoadedScene)
        {
            case "Spawn_room"://if in the spawn room go to boss room
                {
                    LevelName = "boss_room-Redesign"; // This is the level name that the scene will be changed to.
                    StartCoroutine("ChangeLevel"); // This is the call to change scene.
                    break;
                }
            default://if in any other scene go to spawn room
                {
                    LevelName = "Spawn_room"; // This is the level name that the scene will be changed to.
			        StartCoroutine ("ChangeLevel"); // This is the call to change scene.
                    break;
                }
        }
	}


	// This changes the Scene to the Main Menu
	public void ChangeToMainMenu() {
		savedData.GetComponent<SavedData>().ResetSavedData(); // This resets the time Remaining to the Original time.
		LevelName = "MainMenu-Redesign";
		StartCoroutine ("ChangeLevel");
	}


	// This changes the Scene to the the spawn Room for starting a new game.
	public void StartGame() {
		LevelName = "Spawn_room";
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
}
