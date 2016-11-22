using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string CurrentlyLoadedScene;

	// This gets the scene that is currently loaded.
	void Start () {
		CurrentlyLoadedScene = SceneManager.GetActiveScene().name;
	}

	// This is called when the game is over and will go to the game over screen.
	public void ChangeSceneGameOver() {
		ChangeLevel ("game_over");
	}

	// This looks at what the current scene is and then changes scene respectively.
	public void ChangeScene() {
		if (CurrentlyLoadedScene == "boss_room") { // If the current scene is boss_room then change scene to the spawn_room else, change to the boss_room. 
			ChangeLevel("spawn_room");
		} else {
			ChangeLevel("boss_room");
		}
	}


	// This will change to the LevelName.
	private IEnumerator ChangeLevel(string LevelName) {
		float FadeTime = gameObject.GetComponent<SceneTransition>().BeginFade (1); // This begins the fade between scenes.
		yield return new WaitForSeconds (FadeTime);
		SceneManager.LoadScene (LevelName);
	}

}
