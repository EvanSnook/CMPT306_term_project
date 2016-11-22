using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public int HealthPoints; // This is the total number of Health this Object Has.

	public GameObject SavedDataObject; // This is the object that Holds the Scripts that Hold saved Data.
	


	void Start() {
		SavedDataObject = GameObject.Find ("SavedDataObject");
		HealthPoints = SavedDataObject.GetComponent<BossSavedData> ().BossCurrentHealth;
	}


	void Update() {
		if (HealthPoints <= 0) { // If health is 0 or less SendMessage that the Boss Died.
			gameObject.GetComponent<BossAIBasic>().SendMessage("BossDeath");
		}
	}

	// Apply damage to this object.
	public void ApplyDMG(int DMG) {
		HealthPoints -= DMG;
	}



}
