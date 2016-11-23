using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string CurrentlyLoadedScene;
	private string LevelName;

	// This gets the scene that is currently loaded.
	void Start () {
		CurrentlyLoadedScene = SceneManager.GetActiveScene().name;
	}

	// This is called when the game is over and will go to the game over screen.
	public void ChangeSceneGameOver() {
		LevelName = "game_over";
		StartCoroutine ("ChangeLevel");
	}

	// This looks at what the current scene is and then changes scene respectively.
	public void ChangeScene() {
		if (CurrentlyLoadedScene == "boss_room") { // If the current scene is boss_room then change scene to the spawn_room else, change to the boss_room. 
			LevelName = "spawn_room";
			StartCoroutine ("ChangeLevel");
		} else {
			LevelName = "boss_room";
			StartCoroutine ("ChangeLevel");
		}
	}

	public void ChangeTestScene() {
		if (CurrentlyLoadedScene == "TestScene1") { // This is for testing the change scene. 
			LevelName = "TestScene2";
			StartCoroutine ("ChangeLevel");
		} else {
			LevelName = "TestScene1";
			StartCoroutine ("ChangeLevel");
		}
	}


	// This will change to the LevelName.
	IEnumerator ChangeLevel() {
		Debug.Log ("Begin Fadeing");
		float FadeTime = gameObject.GetComponent<SceneTransition>().BeginFade(1); // This begins the fade between scenes.
		yield return new WaitForSeconds (FadeTime);
		SceneManager.LoadScene (LevelName);
	}



}
