using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	public string CurrentlyLoadedScene;

	void Start () {
		CurrentlyLoadedScene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
