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

	public addScore addScore;
	private string medalId;

	private int _LevelScore;
	private bool newHighScore,updateLock;
	private bool playLastSoundLock;

	public bool isGameUIOver = false;
	public bool resetLevelScore = false;
	public AudioClip audio_newHighScore, audio_gameOver;

	public AudioClip audio_youWin, audioEnding;

	public Image endingGameImageSprite;
	public Sprite _endingGameSprite;
	public Sprite _spriteGameOver,_spriteYouWin; //0 game over, 1 you win
	// END #1


	// Use this for initialization
	void Start () {

	}

	void Awake()
	{
		audioEnding = audio_youWin;
		_endingGameSprite = _spriteYouWin;
		isGameUIOver = false;
		newHighScore = false;
		updateLock = false;
		_LevelScore = 0;
	}

	void Update ()
	{
//		print ("now " + _LevelScore);
		//control game
		if (theHeart._HeartgameOver || theTimer._isOver || isGameUIOver) {
			//if in WE LOCK to not open this or set TRUE later in next game
			if (updateLock)
				return;
			
			if(theHeart._HeartgameOver){audioEnding = audio_gameOver; _endingGameSprite = _spriteGameOver;}
			else{audioEnding = audio_youWin; _endingGameSprite = _spriteYouWin;}
			endingGameImageSprite.sprite = _endingGameSprite;



			//set all condition TRUE in coroutine -> use IE to delay the last fruits to move in tray completely
			updateLock = true;
			StartCoroutine(IEDelay2(1f));

			//active the Gameover Canvas
			Invoke ("openCanvasGameover", 0.5f);

		}

	}

	public void incScore(int score)
	{
//		print (_LevelScore + " + " + score);
		_LevelScore += score;
	}

	public int getScore(){
		return _LevelScore;
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
		addScore.addScoreWWW (_LevelScore, medalId);
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
			if (audioEnding) {
				//if exist audio
				//play gameover audio (no delay)
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (audioEnding);
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
			

		} else if (_LevelScore >= theMedalSTD.scoreSilver) {
			

		} else if (_LevelScore >= theMedalSTD.scoreBronze) {
			

		} else {
			

		}

		int HeartNum = theHeart.getHeartNum ();
		print (HeartNum);
		if(HeartNum >= 3){
			medalId = "1";
			theMedal.sprite = theMedalSTD._Sprite [0];
		}else if(HeartNum >= 2 && HeartNum < 3){
			medalId = "2";
			theMedal.sprite = theMedalSTD._Sprite [1];
		}else if(HeartNum >= 1 && HeartNum < 2){
			medalId = "3";
			theMedal.sprite = theMedalSTD._Sprite [2];
		}else{
			medalId = "0";
			theMedal.sprite = theMedalSTD._Sprite [2];
		}
		//CHECK BOOLEAN AND PLAY ONCE TO RESET THE SCORE (by Level Name)
		if (resetLevelScore) {
			PlayerPrefs.SetInt (theMedalSTD.LevelName, 0);
		}
	}
}
