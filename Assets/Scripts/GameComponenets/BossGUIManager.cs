using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossGUIManager : MonoBehaviour {

	public GameObject BossHealthBar; // This holds a reference to the Boss' health bar.
	public GameObject BossHealthBarText; // This holds a reference to the Boss' health bar text.
	public GameObject Boss; // This holds a reference to the boss.

	public float PercentRemaining; // This is the percentRemaining of the bosses health. (In a decimal format)
	private Text PercentText; // This is the text that that displays the percent of the boss' health.

	void Start () {
		BossHealthBar = GameObject.Find ("BossHealthBarHealth"); // This gets a reference to the boss' health bar GUI object.
		BossHealthBarText = GameObject.Find ("BossHealthBarPercentageText"); // This gets a reference to the boss' health bar GUI text.
		Boss = GameObject.Find ("Boss"); // This gets a reference to the boss.

		PercentText = BossHealthBarText.GetComponent<Text> (); // This gets the text component of the Boss' health bar Text GUI.
	}


	void Update() {
		PercentRemaining = Boss.GetComponent<BossHealth> ().FractionHealthRemaining(); // This calls a function that returns a fraction of the health remaining.
		PercentText.text = PercentRemaining *100+ "%"; // This sets the text to show the percentage of the health remaining.
		BossHealthBar.GetComponent<RectTransform> ().localScale = new Vector2(PercentRemaining, 1); // This scales the health bar to the decimal value of the boss' health remaining.
	}

}
