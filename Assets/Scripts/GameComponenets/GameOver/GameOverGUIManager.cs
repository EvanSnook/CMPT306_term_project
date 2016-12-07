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

		PlayerDamageDone = GameObject.Find ("PlayerTotalDMGDoneText"); // This gets a reference to the DamagerDoneToBossText GUI Object.
		PlayerDamageDoneText = PlayerDamageDone.GetComponent<Text> (); // This gets the Text Component of the PlayerDamageDone.
		PlayerDamageDoneText.text = "Total Damage to Boss: " + SavedData.GetComponent<PlayerSavedData> ().TotalDamageDoneToBoss(); // This gets the amount of damage done to the boss.

        PlayerMeleeDMGDone = GameObject.Find ("PlayerMeleeDMGDoneText");
        PlayerMeleeDMGDoneText = PlayerMeleeDMGDone.GetComponent<Text> ();
        PlayerMeleeDMGDoneText.text = "Melee Damage: " + SavedData.GetComponent<PlayerSavedData> ().MeleeDamageDone;

        PlayerRangedDMGDone = GameObject.Find ("PlayerRangedDMGDoneText");
        PlayerRangedDMGDoneText = PlayerRangedDMGDone.GetComponent<Text> ();
        PlayerRangedDMGDoneText.text = "Ranged Damage: " + SavedData.GetComponent<PlayerSavedData> ().RangedDamageDone;


		BossDeaths = GameObject.Find ("BossNumberOfDeathsText"); // This gets a refernce to the BossDeathsText GUI Object.
		BossDeathsText = BossDeaths.GetComponent<Text>(); // This gets the Text Component of the Bossdeaths.
		BossDeathsText.text = "Number of Deaths: " + SavedData.GetComponent<BossSavedData> ().NumberOfDeaths; // This gets the NUmber of Deaths for the Boss.

		BossDamageDone = GameObject.Find ("BossTotalDMGDoneText"); // This gets a reference to the BossDamageText GUI Object.
		BossDamageDoneText = BossDamageDone.GetComponent<Text>(); // This gets the Text Component of the BossDamageDone.
		BossDamageDoneText.text = "Total Damage to Player: " + SavedData.GetComponent<BossSavedData> ().TotalDamageDoneToPlayer(); // This Gets the amount of damage done to the player.

        BossCollisionDMGDone = GameObject.Find ("BossCollisionDMGDoneText");
        BossCollisionDMGDoneText = BossCollisionDMGDone.GetComponent<Text> ();
        BossCollisionDMGDoneText.text = "Collision Damage: " + SavedData.GetComponent<BossSavedData> ().BossCollisionDamage;

        BossMeleeDMGDone = GameObject.Find ("BossMeleeDMGDoneText");
        BossMeleeDMGDoneText = BossMeleeDMGDone.GetComponent<Text> ();
        BossMeleeDMGDoneText.text = "Melee Damage: " + SavedData.GetComponent<BossSavedData> ().BossMeleeDamage;

        BossRangedDMGDone = GameObject.Find ("BossRangedDMGDoneText");
        BossRangedDMGDoneText = BossRangedDMGDone.GetComponent<Text> ();
        BossRangedDMGDoneText.text = "Ranged Damage: " + SavedData.GetComponent<BossSavedData> ().BossRangedDamage;

	}
	
}
