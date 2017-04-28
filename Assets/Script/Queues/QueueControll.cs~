using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QueueControll : MonoBehaviour {


	// QueueControll.Draglock
	public static int curCar;
	public static int numCar;
	public static bool lostHeartQueue;
	public static bool givingScoreQueue;	
	public static bool queueGameOver;

	public int scoreGive;

	public bubble_ui bui;

	public bool _gameControlOver;

	static public int Qscor;


	// Use this for initialization
	void Awake(){
		//the static
		curCar = 1;
		numCar = 0;
		lostHeartQueue = false;
	}
	void Start () {

		Qscor = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (bui.isGameUIOver || _gameControlOver) {
			_gameControlOver = true;
			bui.isGameUIOver = true;
		}
			


		if (lostHeartQueue) {
			lostHeartQueue = !lostHeartQueue;
			bui.theHeart.LosingHeart ();
		}

		if(givingScoreQueue){
			givingScoreQueue = !givingScoreQueue;
			bui.incScore (scoreGive);
		}
	}
		
		
}

