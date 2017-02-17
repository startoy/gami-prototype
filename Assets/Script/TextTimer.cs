using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextTimer : MonoBehaviour
{
	public float _timeLeft;
	public Text _timerText;
	//specific to bus (binary)
	public bool _TimegameOver;
	//for use
	public bool _isOver;

	// Use this for initialization
	void Start ()
	{
		_TimegameOver = false;
		_isOver = false;
	}

	void Awake(){
		_TimegameOver = false;
		_isOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//recieve the boolean from other script -> for bus condition timer stop
		_TimegameOver = busMovement._GameOver;
		_TimerCountdown ();

	}

	void _TimerCountdown ()
	{
		if (_timeLeft <= 0) {
			busMovement._GameOver = true;
			_isOver = true;
			_timeLeft = 0;
		}

		//if use or || will not move
		if (!_TimegameOver && !_isOver) {
			_timeLeft -= Time.deltaTime;


//				Debug.Log (_timeLeft);

		}

		_timerText.text = "Time : " + Mathf.Round (_timeLeft).ToString ();

	}

}
