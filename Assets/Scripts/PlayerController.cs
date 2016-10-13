using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		if (Input.GetAxisRaw("Horizontal") < -0.1) {
			this.SendMessage("MoveLeft", 5.0);
		} else if (Input.GetAxisRaw("Horizontal") > 0.1) {
			this.SendMessage("MoveRight", 5.0);
		}
		this.SendMessage("SlowMovement");
	}
}
