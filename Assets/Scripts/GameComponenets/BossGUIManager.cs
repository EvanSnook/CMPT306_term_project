using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossGUIManager : MonoBehaviour {

	public GameObject BossHealthBar; // This holds a reference to the Boss' health bar.
	public GameObject BossHealthBarText; // This holds a reference to the Boss' health bar text.
	public GameObject Boss; // This holds a reference to the boss.

	private float PercentRemaining;
	private Text PercentText;

	void Start () {
		BossHealthBar = GameObject.Find ("BossHealthBar");
		BossHealthBarText = GameObject.Find ("BossHealthBarPercentageText");
		Boss = GameObject.Find ("Boss");

		PercentText = BossHealthBarText.GetComponent<Text> ();
	}


	void Update() {
		PercentRemaining = Boss.GetComponent<BossHealth> ().PercentHealthRemaining();
		PercentText.text = PercentRemaining + "%";
		BossHealthBar.GetComponent<RectTransform> ().sizeDelta = new Vector2(PercentRemaining, 15);;
	}

}
