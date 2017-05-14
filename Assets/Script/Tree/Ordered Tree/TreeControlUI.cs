using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TreeControlUI : MonoBehaviour {
	// controller UI
	// put from Canvas
	// #1 Variable for all control game
	public bubble_ui bui;
	public int scoreGive;
	// END #1

	public TreeChkAnswer chkAsnwer;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{

	}
	// Update is called once per frame
	void Update () {

	}

	public void checkAnswer()
	{
		if(chkAsnwer.chkBoolTreeAnswer ())
		{
			bui.incScore (scoreGive);
			bui.isGameUIOver = true;
		}else{
			bui.theHeart.LosingHeart ();
		}
	}

}
