using UnityEngine;
using System.Collections;

public class Stack_truckCollider : MonoBehaviour
{
	public MakeHeart heart;
	public int scoreWhenCarry = 10;
	public Stack_Controll stkControll;
	private float timeStick = 5f;
	public boxbomb[] boxbomb;
	private int boxbombLen;
	private int boxbombCounter;
	//this tag should attached to the obj with collider and Rigidbody
	private string[] boxTag = new string[]{ "BoxFruit"};
	bool isOver;


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		isOver = stkControll._gameControlOver;
		boxbombLen = stkControll.boxbombLen;
		boxbombCounter = stkControll.boxbombCounter;
//		Debug.Log("TRUCK 1 -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		foreach (string a in boxTag) {
			if (other.tag == a) { 
				Stack_Controll.stackScore += scoreWhenCarry;
			}
		}
		if(other.tag ==  "BoxBomb" ){

				

			if (boxbombCounter < boxbombLen) {
				heart.LosingHeart ();
				boxbomb [boxbombCounter]._isStop = true;
				boxbombCounter++;
				stkControll.boxbombCounter++;
			} else {
//				Debug.Log ("!!!!!boxbombCounter < boxbombLen");
			}
//			Debug.Log("TRUCK 2 -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (isOver) {
			return;
		}
		foreach (string a in boxTag) {
			if (other.tag == a) { 
				Stack_Controll.stackScore -= scoreWhenCarry;
			}
		}
		if(other.tag ==  "BoxBomb" ){
			heart.addHeart ();
			boxbombCounter--;
			stkControll.boxbombCounter--;
			boxbomb [boxbombCounter]._isStop = false;
//			Debug.Log("TRUCK 3 -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
		}
	}


}
