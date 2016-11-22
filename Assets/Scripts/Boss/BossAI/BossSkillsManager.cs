using UnityEngine;
using System.Collections;

public class BossSkillsManager : MonoBehaviour {

	public float[] UnlockedMeleeSkills; // The Type of this is a place holder. It is an array that will hold all the skills that have been unlocked by the oss.
	public float[] UnlockedRangedSkills;

	public float[] AvailableMeleeSkills;

	public GameObject SavedDataObject; // This is a refernce to the SavedData Object which holds information that has been saved.

	public GameObject SceneControllerObject; // This is a reference to the Object that holds the scripts to controll Scenes.

	// Because this will only choose a skill when in the spawn room everything will be done in start so that it will only run one time when it loads in the spawn room.
	void Start () {



	}
	
}
