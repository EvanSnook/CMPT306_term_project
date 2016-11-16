using UnityEngine;
using System.Collections;

public class ToBossRoom : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		SendMessage ("ChangeLevel");
	}
}
