using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string CurrentlyLoadedScene;

	void Start () {
		CurrentlyLoadedScene = SceneManager.GetActiveScene().name;
	}

	public void ChangeSceneGameOver() {
		SceneManager.LoadScene ("game_over");
	}

	public void ChangeScene() {
		if (CurrentlyLoadedScene == "boss_room") {

			gameObject.GetComponent<SceneTransition> ().SendMessage ("ChangeLevel");

			SceneManager.LoadScene ("spawn_room");
		} else {
			SceneManager.LoadScene ("boss_room");
		}
	}
}
