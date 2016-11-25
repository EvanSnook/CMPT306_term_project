using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour {

    public GameObject SceneController;

    void Awake()
    {
        SceneController = GameObject.Find("SceneControllerObject");
    }

    void Death()
    {
        SceneController.SendMessage("PlayerDied");
    }
}
