using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossGUIManager : MonoBehaviour {

	public GameObject BossHealthBar; // This holds a reference to the Boss' health bar.
	public GameObject BossHealthBarText; // This holds a reference to the Boss' health bar text.
	public GameObject Boss; // This holds a reference to the boss.

	public float PercentRemaining;
	private Text PercentText;

	void Start () {
		BossHealthBar = GameObject.Find ("BossHealthBarHealth");
		BossHealthBarText = GameObject.Find ("BossHealthBarPercentageText");
		Boss = GameObject.Find ("Boss");

		PercentText = BossHealthBarText.GetComponent<Text> ();
	}


	void Update() {
		PercentRemaining = Boss.GetComponent<BossHealth> ().FractionHealthRemaining();
		PercentText.text = PercentRemaining *100+ "%";
		BossHealthBar.GetComponent<RectTransform> ().localScale = new Vector2(PercentRemaining, 1);
	}

}
