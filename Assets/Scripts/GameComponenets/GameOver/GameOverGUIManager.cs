using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverGUIManager : MonoBehaviour {

	public GameObject SavedData; // This will hold a reference to the Saved data Object.

	public GameObject PlayerDeaths; // This will hold a reference to the Player Deaths Text Object.
	public GameObject PlayerDamageDone; // This will hold a reference to the Player Damage Done to Boss Text Object.

	private Text PlayerDeathsText; // This is the text Component of the PlayerDeaths Text UI.
	private Text PlayerDamageDoneText; // This is the text Component of the PlayerDamageDone Text UI.


	public GameObject BossDeaths; // This will hold a reference to the Boss Deaths Text Object.
	public GameObject BossDamageDone; // This will hold a reference to the Boss DamageDone to Plaer Text Object.

	private Text BossDeathsText; // This is the text Component of teh BossDeaths Text UI.
	private Text BossDamageDoneText; // This is the text component of the BossDamageDone Text UI.


	void Start () {
		SavedData = GameObject.Find ("SavedData"); // This gets a reference to the SavedData Object.

		PlayerDeaths = GameObject.Find ("PlayerNumberOfDeathsText"); // This gets a reference to the PlayerDeathsText GUI Object.
		PlayerDeathsText = PlayerDeaths.GetComponent<Text> (); // This gets the Text Component of the PlayerDeaths.
//		PlayerDeathsText = SavedData.GetComponent<PlayerSavedData>().PlayerNumberofDeaths; // This gets the Number of Deaths for the Player.

		PlayerDamageDone = GameObject.Find ("DamageDoneToBossText"); // This gets a reference to the DamagerDoneToBossText GUI Object.
		PlayerDamageDoneText = PlayerDamageDone.GetComponent<Text> (); // This gets the Text Component of the PlayerDamageDone.
//		PlayerDamageDoneText = SavedData.GetComponent<PlayerSavedData> ().DamageDoneToBoss; // This gets the amount of damage done to the boss.

		BossDeaths = GameObject.Find ("BossNumberOfDeathsText"); // This gets a refernce to the BossDeathsText GUI Object.
		BossDeathsText = BossDeaths.GetComponent<Text>(); // This gets the Text Component of the Bossdeaths.
//		BossDeathsText = SavedData.GetComponent<BossSavedData> ().BossNumberOfDeaths; // This gets the NUmber of Deaths for the Boss.

		BossDamageDone = GameObject.Find ("DamageDoneToPlayerText"); // This gets a reference to the DamageDonetoPlayer GUI Object.
		BossDamageDoneText = BossDamageDone.GetComponent<Text>(); // This gets the Text Component of the BossDamageDone.
//		BossDamageDoneText = SavedData.GetComponent<BossSavedData>().BossDamageDone; // This Gets the amount of damage done to the player.


	}
	
}
