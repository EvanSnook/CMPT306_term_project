using UnityEngine;
using System.Collections;


public class BossAIBasic : MonoBehaviour {

	public GameObject ThePlayer;
	public GameObject SceneControllerObject;

	public GameObject BossSkillSelectionAI;

	public bool inBossRoom;


	void Start () {
		SceneControllerObject = GameObject.Find ("SceneManagerObject");

		if (SceneControllerObject.GetComponent<SceneController> ().CurrentlyLoadedScene == "BossAITest") {
			inBossRoom = true;
		}
		else {
			inBossRoom = false;


		}

	}



}
