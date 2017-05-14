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
		isOver = stkControll.bui.isGameUIOver;
		boxbombLen = stkControll.boxbombLen;
		boxbombCounter = stkControll.boxbombCounter;
//		Debug.Log("TRUCK 1 -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//check if other assigned score already
		// default FALSE --> if TRUE return
//		print (other.gameObject.name);
		if (other.GetComponent <projectile> () == null)
			return;
		bool isOtherChecked = other.GetComponent <projectile> ().getBoxChecked ();
		if(isOtherChecked){
			return;
		}
		if (!other.GetComponent <projectile> ().isBoxSleep ())
			return;

//		print("in trigger2d enter");
		foreach (string a in boxTag) {
			if (other.tag == a) { 
//				print("score increase enter");
				stkControll.bui.incScore (scoreWhenCarry);
				//assign other to TRUE
				other.GetComponent <projectile> ().setBoxChecked ();
			}
		}
		if(other.tag ==  "BoxBomb" ){
			if (boxbombCounter < boxbombLen) {
				stkControll.bui.theHeart.LosingHeart ();
				boxbomb [boxbombCounter]._isStop = true;
				boxbombCounter++;
				stkControll.boxbombCounter++;
				other.GetComponent <projectile> ().setBoxChecked ();
			} else {
//				Debug.Log ("!!!!!boxbombCounter < boxbombLen");
			}
//			Debug.Log("TRUCK 2 -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.GetComponent <projectile> () == null)
			return;
		if (!other.GetComponent <projectile> ().isBoxSleep ()) {
//			print ("return stay");
			return;
		}

		//check if other assigned score already
		// default FALSE --> if TRUE return
		bool isOtherChecked = other.GetComponent <projectile> ().getBoxChecked ();
		if(isOtherChecked){
			return;
		}

//		print("in trigger2d stay");
		foreach (string a in boxTag) {
			if (other.tag == a) { 
//				print("score increase stay");
				stkControll.bui.incScore (scoreWhenCarry);
				print("score = " + stkControll.bui.getScore ());
				//assign other to TRUE
				other.GetComponent <projectile> ().setBoxChecked ();
			}
		}
		if(other.tag ==  "BoxBomb" ){
			if (boxbombCounter < boxbombLen) {
				stkControll.bui.theHeart.LosingHeart ();
				boxbomb [boxbombCounter]._isStop = true;
				boxbombCounter++;
				stkControll.boxbombCounter++;
				other.GetComponent <projectile> ().setBoxChecked ();
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

		if (other.GetComponent <projectile> () == null)
			return;
		
		//check if other assigned score already
		// default FALSE --> if TRUE return
		bool isOtherChecked = other.GetComponent <projectile> ().getBoxChecked ();
		if(isOtherChecked){
			return;
		}

		if (!other.GetComponent <projectile> ().isBoxSleep ())
			return;

		
		foreach (string a in boxTag) {
			if (other.tag == a) { 
//				print("score decrease");
				stkControll.bui.incScore (-scoreWhenCarry); 
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
