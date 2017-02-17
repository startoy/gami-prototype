using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class QueueControll : MonoBehaviour {


	// QueueControll.Draglock
	public static int curCar;
	public static int numCar;
	public static bool lostHeart;

	public MakeHeart heart;
	public TextTimer timer;
	public Canvas canvasGameOver;
	public bool _gameControlOver;
	public Text _TextScore;
	public Text _TextBestScore;
	public string LevelName;
	static public int score;

	//medal
	public Image _MedalCanvas;
	public Sprite[] _Sprite;
	public int scoreBronze, scoreSilver, scoreGold;

	int bestScore ;
	// Use this for initialization
	void Awake(){
		//the static
		curCar = 1;
		numCar = 0;
		lostHeart = false;
	}
	void Start () {

		score = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (heart._HeartgameOver || timer._isOver) {
			_gameControlOver = true;
			canvasGameOver.gameObject.SetActive (true);
		}
			
		bestScore = PlayerPrefs.GetInt (LevelName, 0);
		if (score > bestScore) {
			PlayerPrefs.SetInt (LevelName, score);
		}
		_TextScore.text = "SCORE : " + score;
		_TextBestScore.text = "BEST SCORE : " + PlayerPrefs.GetInt (LevelName, 0);

		if (score >= scoreGold) {
			_MedalCanvas.sprite = _Sprite [0];
		} else if (score >= scoreSilver) {
			_MedalCanvas.sprite = _Sprite [1];
		} else if (score >= scoreBronze) {
			_MedalCanvas.sprite = _Sprite [2];
		} else {
			_MedalCanvas.sprite = _Sprite [2];
		}

		if (lostHeart) {
			lostHeart = false;
			heart.LosingHeart ();
			Debug.Log ("Is in Lost Heart");
		}
	}

	void IncreaseScore (string LevelName,int Amount)
	{
		score += Amount;
		int bestScore = PlayerPrefs.GetInt (LevelName, 0);
		if (score > bestScore) {
			PlayerPrefs.SetInt (LevelName, score);
		}

		_TextScore.text = "SCORE : " + score;
		_TextBestScore.text = "BEST SCORE : " + PlayerPrefs.GetInt (LevelName, 0);

		if (score >= scoreGold) {
			_MedalCanvas.sprite = _Sprite [0];
		} else if (score >= scoreSilver) {
			_MedalCanvas.sprite = _Sprite [1];
		} else if (score >= scoreBronze) {
			_MedalCanvas.sprite = _Sprite [2];
		} else {
			_MedalCanvas.sprite = _Sprite [2];
		}

	}
}

