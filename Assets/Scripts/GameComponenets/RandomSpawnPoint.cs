using UnityEngine;
using System.Collections;

public class RandomSpawnPoint : MonoBehaviour {

	public GameObject PlayerSpawnPrefab; // This is the prefab for the player that will be spawned.
	public GameObject CameraSpawnPrefab; // This is the prefab for the camera that will be spawned.

	private GameObject[] Respawns; // This is an array of all the different spawn points.
	private GameObject TheCamera; // This is the main camera that was spawned.

	void Start() {
		Respawns = GameObject.FindGameObjectsWithTag ("Respawn"); // This sets the array of Respawns to all the respawns.

		int RNG = Random.Range(0, Respawns.Length); // This generates a random int that picks one of the spawn points.

		Instantiate(PlayerSpawnPrefab, Respawns[RNG].transform.position, Respawns[RNG].transform.rotation); // This spawns the player at one of the random points.

		TheCamera = Instantiate (CameraSpawnPrefab, Respawns [RNG].transform.position, Respawns [RNG].transform.rotation) as GameObject; // This spawns the main camera that will follow the player.
		TheCamera.transform.position = new Vector3 (TheCamera.transform.position.x, TheCamera.transform.position.y, -10); // This moves the camera to where the player spawned.
	}	
}
