using UnityEngine;
using System.Collections;

public class Boss_Movement_Decisions : MonoBehaviour {

	public void MoveToMiddle(){
		transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, move_speed);
	}

	public void MoveAtPlayer(){
		if (player != null) {
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, move_speed);
		}
	}

	void doNothing(){

	}

	public void RandomWalk(){
		transform.position = Vector2.MoveTowards(transform.position,randomPoint, move_speed);
	}

	public void Retreat(){
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -move_speed);
	}

	public void Decision(){
		float tempRand = Random.value;
		if (tempRand <= 0.2){
			decision = 0;
			randomPoint = new Vector2(Random.value * distance * randomSign(), Random.value * distance * randomSign());
		}
		else if (tempRand <= 0.4){
			decision = 1;
		}
		else if (tempRand <= 0.6){
			decision = 2;
		}
		else if (tempRand <= 0.8){
			decision = 3;
		}
		else if (tempRand <= 1.0){
			decision = 4;
		}
		Timer = CooldownTimer; // Set Cooldown Timer.

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Timer <= 0) { // This Checks that the Cooldown Time has passed.
			Decision();
		} else {
			Timer -= Time.deltaTime; // If the Cooldown Time hasn't Passed Keep counting down.
		}

		if (player == null) { // This is because when the scene loads it wont find the player since it has to be instantiated in and so if it hasn't been found yet then find it but once found you don't need to find it anymore.
			player = GameObject.FindWithTag ("Player"); // This finds the player and gets a reference to it.
		} else {
			DistanceToPlayer = Vector2.Distance (gameObject.transform.position, player.transform.position); // This will find the distance between the player and the boss. It is in the else statement because if we don't have a player reference then no point in trying to find the distance between them.
			if (DistanceToPlayer > MaxDistanceFromPlayer) { // If the distandce is greated than the max distance from player then move towards the player.
				decision = 2;
			}
		}



		if(decision == 0){
			RandomWalk();
		}
		else if(decision == 1){
			MoveToMiddle();
		}
		else if(decision == 2){
			MoveAtPlayer();
		}
		else if(decision == 3){
			doNothing();
		}
		else if(decision == 4){
			Retreat();
		}
	}

}
