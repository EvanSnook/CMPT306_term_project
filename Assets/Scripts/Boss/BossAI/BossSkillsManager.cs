using UnityEngine;
using System.Collections;

public class BossSkillsManager : MonoBehaviour {

	public bool Initialized;

	public float[] UnlockedMeleeSkills; // The Type of this is a place holder. It is an array that will hold all the Melee skills that have been unlocked by the Boss.
	public float[] UnlockedRangedSkills; // The Type of this is a place holder. It is an array that will hold all the Ranged skills that have been unlocked by the Boss.

	public float[] AvailableMeleeSkills; // The Type of this is a place holder. It is an array that will hold all the Melee Skills that are available to be unlocked.
	public float[] AvailableRangedSkills; // The Type of this is a place holder. It is an array that will hold all the Ranged Skills that are available to be unlocked.

	public GameObject SavedDataObject; // This is a refernce to the SavedData Object which holds information that has been saved.

	public GameObject SceneControllerObject; // This is a reference to the Object that holds the scripts to controll Scenes.

	// Because this will only choose a skill when in the spawn room everything will be done in start so that it will only run one time when it loads in the spawn room.
	void Start () {

		Initialized = SavedDataObject.GetComponent<BossSavedData> ().BossSkillsInitialized; // This gets the Initialized status from the BossSavedData.

		if (Initialized == false) { // If the skills havent Been Initialized then Initialize them.
			Initialized = true;
			MeleeSkillsInitialization ();
			RangedSkillsInitialization();
		} else {
			MeleeSkillsUpgrade ();
			RangedSkillsInitialization ();
		}
			
	}

	// This initializes the melee skills for the first load of the boss.
	private void MeleeSkillsInitialization() {

	}

	// This initializes the ranged skills for the first load of the boss.
	private void RangedSkillsInitialization() {

	}

	// This is where it decides what to upgrade for melee Skills.
	private void MeleeSkillsUpgrade() {

	}

	// This is where it decides for upgrading Ranged Skills
	private void RangedSkillsUpgrade() {

	}

	
}
