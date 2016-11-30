﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerGUIManager : MonoBehaviour {

	public GameObject Player; // This is the Player where you can get the Health.
	public GameObject TimerObject; // This is the TimerObject where you can get the Time remaining.

	public GameObject HealthNumberGUI; // This is the Element that Holds how much Health the player has.
	public GameObject TimerGUI;

	private Text HealthNumber; // This is the Text for the TextGUI that holds the HealthNumber.
	private Text Timer; // This is the Text for the TextGUI that holds the Timer.

	void Start () {
		HealthNumber = HealthNumberGUI.GetComponent<Text> (); // This is the text of the GUI object.
		Timer = TimerGUI.GetComponent<Text>(); // This is the text of the GUI object for the Timer.
	}

	// Update all Parts of the GUI.
	void Update() {
		if (Player == null) {
			Player = GameObject.FindGameObjectWithTag ("Player"); // This gets a reference to the player if this has not be found.
		} else {
			HealthNumber.text = "Health: " + Player.GetComponent<PlayerHealth> ().HealthPoints; // This gets the current Health Component and sets the GUI object to it.
			Timer.text = "Time Remaining: " + TimerObject.GetComponent<GameTimer> ().GameCountdown.ToString("N0"); // This gets the current TimeRemaining and sets the GUI object to it.
		}
	}


}
