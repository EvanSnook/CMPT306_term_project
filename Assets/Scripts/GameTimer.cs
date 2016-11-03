using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float GameCountdown; // This is the time in the Game Left before you fail.

	void Update () {
		if (GameCountdown > 0) { // If the timer is not 0 then Count down.
			GameCountdown -= Time.deltaTime;
		} else if (GameCountdown < 0) { // If the Timer is below 0 then just set it to 0.
			GameCountdown = 0;
		}
	}
}
