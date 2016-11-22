using UnityEngine;
using System.Collections;


public class BossAIBasic : MonoBehaviour {

	public GameObject ThePlayer;
	public GameObject SceneControllerObject;

	void Start () {
		if (gameObject.GetComponent<Health> ().isFullHealth ()) {

		}
	}



}
