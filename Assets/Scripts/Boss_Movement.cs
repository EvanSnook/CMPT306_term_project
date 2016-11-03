using UnityEngine;
using System.Collections;

public class Boss_Movement : MonoBehaviour {


	public float move_speed = 1f;
	public GameObject player;
	private float distance = 80f;
	private int decision;
	private Vector3 randomPoint;

	public float CooldownTimer = 10f; // How long until next decision
	private float Timer = 0; // This is the the clock that keeps track of how much of a cooldown is left.

	public bool randomBoolean(){
		if (Random.value >= 0.5){
			return true;
		}
		return false;
	}

	public int randomSign(){
		if (Random.value >= 0.5){
			return 1;
		}
		return -1;
	}

	public void MoveToMiddle(){
		transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, move_speed);
	}

	public void MoveAtPlayer(){
		player = GameObject.FindWithTag("player");
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, move_speed);
	}

	void doNothing(){
		
	}
	
	public void RandomWalk(){
		transform.position = Vector2.MoveTowards(transform.position,randomPoint, move_speed);
	}

	public void Retreat(){
		player = GameObject.FindWithTag("player");
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -move_speed);
	}

	// Use this for initialization
	void Start () {
		
	}

	// move to random 	0
	// move to Middle 	1
	// move at player 	2
	// idle 			3
	// retreat 			4
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
	void Update () {
		if (Timer <= 0) { // This Checks that the Cooldown Time has passed.
			Decision();
		} else {
			Timer -= Time.deltaTime; // If the Cooldown Time hasn't Passed Keep counting down.
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
