using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIManager : MonoBehaviour {

	private GameObject HealthNumberGUI; // This is the Element that Holds how much Health the player has.
	private GameObject TimerGUI;

	private Text HealthNumber; // This is the Text for the TextGUI
	private Text Timer;

	void Start () {
		HealthNumberGUI = GameObject.Find ("HealthNumber"); // Find the Object that holds that HealthNumberGUI.
		TimerGUI = GameObject.Find("Timer");

		HealthNumber = HealthNumberGUI.GetComponent<Text> (); // This is the text of the GUI object.
		Timer = TimerGUI.GetComponent<Text>(); 
	}

	// Update all Parts of the GUI.
	void Update() {
		HealthNumber.text = "Health: " + gameObject.GetComponent<Health> ().HealthPoints;
		Timer.text = "Time Remaining: " + gameObject.GetComponent<GameTimer> ().GameCountdown;
	}


}
