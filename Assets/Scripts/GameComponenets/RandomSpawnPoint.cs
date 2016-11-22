using UnityEngine;
using System.Collections;

public class RandomSpawnPoint : MonoBehaviour {

	public GameObject PlayerSpawnPrefab;
	public GameObject CameraSpawnPrefab;

	private GameObject[] Respawns;
	private GameObject TheCamera;

	void Start() {
		if (Respawns == null) {
			Respawns = GameObject.FindGameObjectsWithTag ("Respawn");
		}

		int RNG = Random.Range(0, Respawns.Length);

		Instantiate(PlayerSpawnPrefab, Respawns[RNG].transform.position, Respawns[RNG].transform.rotation);
		TheCamera = Instantiate (CameraSpawnPrefab, Respawns [RNG].transform.position, Respawns [RNG].transform.rotation) as GameObject;
		TheCamera.transform.position = new Vector3 (TheCamera.transform.position.x, TheCamera.transform.position.y, -10);
	}	
}
