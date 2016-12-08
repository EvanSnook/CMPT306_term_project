using UnityEngine;
using System.Collections;

public class MusicShuffler : MonoBehaviour {

	public AudioSource source;
	public AudioClip[] songs;

	private AudioClip currentSong;

	// Use this for initialization
	void Start () {
		PlayNextSong();
	}

	void PlayNextSong() {
		AudioClip song = null;
		if (currentSong == null) {
			song = songs[Random.Range(0, songs.Length)];
		} else {
			int randomNumber = Random.Range(0, songs.Length);
			song = songs[randomNumber];
			if (song == currentSong) {
				if (randomNumber == 0) {
					song = songs[songs.Length - 1];
				} else {
					song = songs[randomNumber - 1];
				}
			}
		}
		source.clip = song;
		source.Play();
		Invoke("PlayNextSong", song.length);
	}
}
