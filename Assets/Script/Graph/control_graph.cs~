using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class control_graph : MonoBehaviour {
	// controller UI
	// put from Canvas
	// #1 Variable for all control game
	public bubble_ui bui;

	public int _graph_levelScore;

	public bool resetLevelScore = false;

	private bool isGameOver = false;
	// END #1

	public graph_tool graphTool;


	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		isGameOver = false;

	}
	
	void Update ()
	{



	}

	public void checkAnswer()
	{
		if(graphTool.checkBoolAnswer ())
		{
			bui.incScore (_graph_levelScore);
			isGameOver = true;
			bui.isGameUIOver = true;

		}else{
			bui.theHeart.LosingHeart ();
		}
	}
}
