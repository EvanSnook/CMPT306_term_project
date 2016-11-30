using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject SceneController;
	public GameObject SavedData;

    void Start () {
        SceneController = GameObject.Find("SceneControllerObject");
		SavedData = GameObject.Find ("SavedData");
    }

    void PlayerDied () {
		SavedData.GetComponent<SavedData> ().SendMessage("SaveData");
        SceneController.SendMessage("ChangeScene");
    }
}
