using UnityEngine;
using System.Collections;

public class BossDeath : MonoBehaviour {

	public GameObject SceneController;
	public GameObject SavedData;

	void Start () {
		SceneController = GameObject.Find("SceneControllerObject");
		SavedData = GameObject.Find ("SavedData");
	}

	public void BossDied() {
		SavedData.GetComponent<SavedData> ().SendMessage("SaveData");
		SceneController.SendMessage("ChangeScene");
	}
}
