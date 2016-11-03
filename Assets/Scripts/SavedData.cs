using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

	public float BossHealth;
	public int SkillPoints;

	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
}
