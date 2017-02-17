using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stack_Controll : MonoBehaviour {
	
	public TextTimer timer;
	public MakeHeart heart;
	public Canvas canvasGameOver;
	public bool _gameControlOver;
	public Text _TextScore;
	public Text _TextBestScore;

	public string LevelName;
	private int bestScore;

	public boxGroupControl boxGroup;
	public int scoreWhenFall=10;
	public int scoreWhenCarry = 10;
	//check this if stage is tutorial
	public bool isTutorial = false;
	public boxbomb[] boxbomb;
	private bool isBombed;
	public int boxbombLen;
	public int boxbombCounter;

	//medal
	public Image _Medal;
	public Sprite[] _Sprite;
	public int scoreBronze, scoreSilver, scoreGold;

	static public int stackScore;

	private string[] boxTag = new string[]{"BoxFruit"};
	// Use this for initialization
	void Start () {
		
		//static score for stack
		stackScore = 0;
		_gameControlOver = false;
		heart._HeartgameOver = false;
		timer._isOver = false;
		boxGroup._isBoxEmpty = false;
		isBombed = false;

		_TextScore.text = "TUTORIAL MODE";
		_TextBestScore.text = "";

		boxbombLen = boxbomb.Length;
		boxbombCounter = 0;
	}

	// Update is called once per frame
	void Update () {
		
//		Debug.Log ("BB LEN = "+boxbombLen);
		for (int i = 0; i < boxbombLen; i++) {
//			Debug.Log ("boxbomed is true ?");
			if (boxbomb [i]._isBombed) {
				isBombed = true;
//				Debug.Log ("isTRUE BOMBED !!!");
			}
		}
		if (heart._HeartgameOver || timer._isOver || boxGroup._isBoxEmpty || isBombed) {
			//set all condition TRUE


			_gameControlOver = true;
			heart._HeartgameOver = true;
			timer._isOver = true;
			boxGroup._isBoxEmpty = true;
			isBombed = true;

			//active the Gameover Canvas
			Invoke("openCanvasGameover",3f);
		}
		if (!isTutorial) {
			updateScore ();
		}

	}

	void updateScore(){
		Debug.Log ("update score !!" + stackScore);
		bestScore = PlayerPrefs.GetInt (LevelName, 0);
		if (stackScore > bestScore) {
			PlayerPrefs.SetInt (LevelName, stackScore);
		}
		_TextScore.text = "SCORE : " + stackScore;
		_TextBestScore.text = "BEST SCORE : " + PlayerPrefs.GetInt (LevelName, 0);

		if (stackScore >= scoreGold) {
			_Medal.sprite = _Sprite [0];
		} else if (stackScore >= scoreSilver) {
			_Medal.sprite = _Sprite [1];
		} else if (stackScore >= scoreBronze) {
			_Medal.sprite = _Sprite [2];
		} else {
			_Medal.sprite = _Sprite [2];
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (isBombed) {
			return;
		}
		foreach(string a in boxTag){
			if(other.tag == a)
			{ 
//				stackScore -= scoreWhenFall;
				if (stackScore < 0) {
					stackScore = 0;
				}
				Debug.Log ("is In ur foot");
			}
		}
		if(other.tag ==  "BoxBomb" ){

			if (boxbombCounter < boxbombLen) {
				stackScore += scoreWhenCarry;
				boxbomb [boxbombCounter]._isStop = true;
				boxbombCounter++;
			} else {
				Debug.Log ("BOOM");
			}
//			Debug.Log("STACK -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (isBombed) {
			return;
		}
		if(other.tag ==  "BoxBomb" ){
			stackScore -= scoreWhenCarry;
			boxbombCounter--;
			boxbomb [boxbombCounter]._isStop = false;
//			Debug.Log("STACK 2 -> boxbombLen= "+ boxbombLen +" boxbombCounter = "+ boxbombCounter);
		}
	}

	void openCanvasGameover()
	{
		canvasGameOver.gameObject.SetActive (true);
	}
}
