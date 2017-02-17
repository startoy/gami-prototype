using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class busMovement : MonoBehaviour
{
	//controll speed
	public string LevelScoreName;
	public float maxspeed;
	public float rotationSpeed;
	int ListCountPerson;
	static public bool _GameOver;
	public string[] answer;
	int score = 0;
	public Canvas _CanvasGameOver;
	public Canvas _CanvasGameOverTutorial;
	public Text _TextScore;
	public Text _TextBestScore;
	public Text _TextTime;
	Rigidbody2D TheBus;
	public TextTimer timer;
	public MakeHeart heart;

	//medal
	public Image _MedalCanvas;
	public Sprite[] _Sprite;
	public int scoreBronze, scoreSilver, scoreGold;

	// Use this for initialization
	void Start ()
	{
		if (LevelScoreName == null) {
			LevelScoreName = "empty";
			Debug.Log ("No assign Level score name");
		}
		_GameOver = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!_GameOver) {
			Debug.Log ("BUS IS MOVE - FALSE");
			BusMove ();
		} 
	}

	void BusMove ()
	{
		//Rotate the bus left right
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z; //grab z euler angle
		z -= Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z); //recreate the quaternion
		transform.rotation = rot; //apply to object bus

		Vector3 pos = new Vector3 (0, Input.GetAxis ("Vertical") * maxspeed * Time.deltaTime, 0);
		transform.Translate (pos);
	}

	void Update ()
	{
//		_GameOver = timer._isOver;
//		counting the array list
		ListCountPerson = StackingOrder.ListCount;
		score = StackingOrder.ScoreTemp;
		IncreaseScore ();
		if (_GameOver || ListCountPerson >= answer.Length || timer._isOver || heart._HeartgameOver) {
				Invoke ("OpenCanvasScore", 0.25f);
			_GameOver = true;
			//set this back to false for "RETRY" if not -> static -> still be 5 and not countdown
//			_GameOver = false;
		}
	}

	void OpenCanvasScore ()
	{
//		SetTextTime ();
		_GameOver = true;
		_CanvasGameOver.gameObject.SetActive (true);
//		if (TextReader.IsTutorial && _CanvasGameOverTutorial != null) {Invoke ("openCanvasTutorial", 0f);} 
	}

	void openCanvasTutorial()
	{
		_GameOver = true;
		_CanvasGameOverTutorial.gameObject.SetActive (true);
	}

	void IncreaseScore ()
	{
		int bestScore = PlayerPrefs.GetInt (LevelScoreName, 0);
		if (score > bestScore) {
			PlayerPrefs.SetInt (LevelScoreName, score);
		}
		_TextScore.text = "SCORE : " + score;
		_TextBestScore.text = "BEST SCORE : " + PlayerPrefs.GetInt (LevelScoreName, 0);

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

	void SetTextTime()
	{
//		_TextTime.text = "Time : " + Mathf.Round(_CTime._timeLeft);
	}




}
