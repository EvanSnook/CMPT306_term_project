using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverGUIManager : MonoBehaviour {

	public GameObject SavedData; // This will hold a reference to the Saved data Object.

	public GameObject PlayerDeaths; // This will hold a reference to the Player Deaths Text Object.
	public GameObject PlayerDamageDone; // This will hold a reference to the Player Damage Done to Boss Text Object.
    public GameObject PlayerMeleeDMGDone;
    public GameObject PlayerRangedDMGDone;

	private Text PlayerDeathsText; // This is the text Component of the PlayerDeaths Text UI.
	private Text PlayerDamageDoneText; // This is the text Component of the PlayerDamageDone Text UI.
    private Text PlayerMeleeDMGDoneText;
    private Text PlayerRangedDMGDoneText;

	public GameObject BossDeaths; // This will hold a reference to the Boss Deaths Text Object.
	public GameObject BossDamageDone; // This will hold a reference to the Boss DamageDone to Plaer Text Object.
    public GameObject BossCollisionDMGDone;
    public GameObject BossMeleeDMGDone;
    public GameObject BossRangedDMGDone;

	private Text BossDeathsText; // This is the text Component of teh BossDeaths Text UI.
	private Text BossDamageDoneText; // This is the text component of the BossDamageDone Text UI.
    private Text BossCollisionDMGDoneText;
    private Text BossMeleeDMGDoneText;
    private Text BossRangedDMGDoneText;

	void Start () {
		SavedData = GameObject.Find ("SavedData"); // This gets a reference to the SavedData Object.

		PlayerDeaths = GameObject.Find ("PlayerNumberOfDeathsText"); // This gets a reference to the PlayerDeathsText GUI Object.
		PlayerDeathsText = PlayerDeaths.GetComponent<Text> (); // This gets the Text Component of the PlayerDeaths.
		PlayerDeathsText.text = "Number of Deaths: " + SavedData.GetComponent<PlayerSavedData> ().NumberOfDeaths; // This gets the Number of Deaths for the Player.

		PlayerDamageDone = GameObject.Find ("PlayerDMGDoneText"); // This gets a reference to the DamagerDoneToBossText GUI Object.
		PlayerDamageDoneText = PlayerDamageDone.GetComponent<Text> (); // This gets the Text Component of the PlayerDamageDone.
		PlayerDamageDoneText.text = "Damage Done to Boss: " + SavedData.GetComponent<PlayerSavedData> ().TotalDamageDoneToBoss(); // This gets the amount of damage done to the boss.

        PlayerMeleeDMGDone = GameObject.Find ("PlayerMeleeDMGDoneText");
        PlayerMeleeDMGDoneText = PlayerMeleeDMGDone.GetComponent<Text> ();
        PlayerMeleeDMGDoneText.text = "Melee Damage Done: " + SavedData.GetComponent<PlayerSavedData> ().MeleeDamageDone;

        PlayerRangedDMGDone = GameObject.Find ("PlayerRangedDMGDoneText");
        PlayerRangedDMGDoneText = PlayerMeleeDMGDone.GetComponent<Text> ();
        PlayerRangedDMGDoneText.text = "Ranged Damage Done: " + SavedData.GetComponent<PlayerSavedData> ().RangedDamageDone;


		BossDeaths = GameObject.Find ("BossNumberOfDeathsText"); // This gets a refernce to the BossDeathsText GUI Object.
		BossDeathsText = BossDeaths.GetComponent<Text>(); // This gets the Text Component of the Bossdeaths.
		BossDeathsText.text = "Number of Deaths: " + SavedData.GetComponent<BossSavedData> ().NumberOfDeaths; // This gets the NUmber of Deaths for the Boss.

		BossDamageDone = GameObject.Find ("BossDMGText"); // This gets a reference to the BossDamageText GUI Object.
		BossDamageDoneText = BossDamageDone.GetComponent<Text>(); // This gets the Text Component of the BossDamageDone.
		BossDamageDoneText.text = "Damage Done to Player: " + SavedData.GetComponent<BossSavedData> ().TotalDamageDoneToPlayer(); // This Gets the amount of damage done to the player.


	}
	
}
