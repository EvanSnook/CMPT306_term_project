using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject SceneController;
	public GameObject SavedData;

    void Awake() {
        SceneController = GameObject.Find("SceneControllerObject");
		SavedData = GameObject.Find ("SavedData");
    }

    void Death() {
		SavedData.GetComponent<BossSavedData> ().SendMessage("PlayerDeathSaveBoss");
        SceneController.SendMessage("PlayerDied");
    }
}
