using UnityEngine;
using System.Collections;

public class RandomSpawnPoint : MonoBehaviour {

	public GameObject PlayerSpawnPrefab;
	private GameObject[] Respawns;
	void Start() {
		if (Respawns == null) {
			Respawns = GameObject.FindGameObjectsWithTag ("Respawn");
		}

		int RNG = Random.Range(0, Respawns.Length);

		Instantiate(PlayerSpawnPrefab, Respawns[RNG].transform.position, Respawns[RNG].transform.rotation);
	}	
}
