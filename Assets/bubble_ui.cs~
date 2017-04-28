using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bubble_ui : MonoBehaviour {

	// controller UI
	// put from Canvas
	// #1 Variable for all control game
	public TextTimer theTimer;
	public MakeHeart theHeart;
	public Canvas thecanvasGameOver;
	public MedalStandard theMedalSTD;
	public Image theMedal; //don't forget to include UI --> using UnityEngine.UI;

	private int _LevelScore;
	private bool newHighScore,updateLock;
	private bool playLastSoundLock;

	public bool isGameUIOver;
	public bool resetLevelScore = false;
	public AudioClip audio_newHighScore, audio_gameOver;
	// END #1


	// Use this for initialization
	void Start () {

	}

	void Awake()
	{
		isGameUIOver = false;
		newHighScore = false;
		updateLock = false;
		_LevelScore = 0;
	}

	void Update ()
	{
		//control game
		if (theHeart._HeartgameOver || theTimer._isOver || isGameUIOver) {
			//if in WE LOCK to not open this or set TRUE later in next game
			if (updateLock)
				return;

			//set all condition TRUE in coroutine -> use IE to delay the last fruits to move in tray completely
			updateLock = true;
			StartCoroutine(IEDelay2(1f));

			//active the Gameover Canvas
			Invoke ("openCanvasGameover", 0.5f);

		}

	}

	public void incScore(int score)
	{
		_LevelScore += score;
	}

	IEnumerator IEDelay(float sec) {
		//play Audio "new high score" once

		//use with StartCoroutine(IEDelay(0.5f));
		yield return new WaitForSeconds(sec); //Wait 1 second
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(audio_newHighScore);
	}

	IEnumerator IEDelay2(float sec) {
		yield return new WaitForSeconds(sec); //Wait 1 second
		theHeart._HeartgameOver = true;
		theTimer._isOver = true;
		isGameUIOver = true;

	}

	void openCanvasGameover ()
	{
		updateScore ();
		thecanvasGameOver.gameObject.SetActive (true);
		playLastSound ();
	}

	void playLastSound(){
		//check to play once
		if (!playLastSoundLock) {
			if (audio_newHighScore && newHighScore) {
				//if exists audio and new high score = true
				//play new high score audio (delay 1f sec after play gameover audio
				StartCoroutine (IEDelay (1f));
			}
			if (audio_gameOver) {
				//if exist audio
				//play gameover audio (no delay)
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (audio_gameOver);
			}
			playLastSoundLock = true;
		}
	}

	void updateScore ()
	{
		int bestScore = PlayerPrefs.GetInt (theMedalSTD.LevelName, 0);

		if (_LevelScore > bestScore) {
			PlayerPrefs.SetInt (theMedalSTD.LevelName, _LevelScore);
			newHighScore = true;
		}
		theMedalSTD._TextScore.text = "SCORE : " + _LevelScore;
		theMedalSTD._TextBestScore.text = "BEST SCORE : " + PlayerPrefs.GetInt (theMedalSTD.LevelName, 0);

		if (_LevelScore >= theMedalSTD.scoreGold) {
			theMedal.sprite = theMedalSTD._Sprite [0];
		} else if (_LevelScore >= theMedalSTD.scoreSilver) {
			theMedal.sprite = theMedalSTD._Sprite [1];
		} else if (_LevelScore >= theMedalSTD.scoreBronze) {
			theMedal.sprite = theMedalSTD._Sprite [2];
		} else {
			theMedal.sprite = theMedalSTD._Sprite [2];
		}

		//CHECK BOOLEAN AND PLAY ONCE TO RESET THE SCORE (by Level Name)
		if (resetLevelScore) {
			PlayerPrefs.SetInt (theMedalSTD.LevelName, 0);
		}
	}
}
