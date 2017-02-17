using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Control_sort_selection : MonoBehaviour
{
	public static int _selectionLevelCurScore;

	// controller UI
	// put from Canvas
	// #1 Variable for all control game
	public TextTimer theTimer;
	public MakeHeart theHeart;
	public Canvas thecanvasGameOver;
	public MedalStandard theMedalSTD;
	public Image theMedal;

	private int _LevelScore;
	private bool newHighScore,updateLock;
	private bool playLastSoundLock;

	public AudioClip audio_newHighScore, audio_gameOver;
	// END #1

	public bool _gameControlOver;

	public int sortTotal;





	// Use this for initialization
	void Start ()
	{
		_gameControlOver = false;
	}

	void Awake ()
	{
		_selectionLevelCurScore = 0;
		_LevelScore = 0;
		playLastSoundLock = false;
		_gameControlOver = false;

		newHighScore = false;
		updateLock = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//get the Score from global variable all time
		_LevelScore = _selectionLevelCurScore;
		//control game
		if (theHeart._HeartgameOver || theTimer._isOver || MouseoverTray._curSortedValue==sortTotal+1) {
			//if in WE LOCK to not open this or set TRUE later in next game
			if (updateLock)
				return;
			
			//set all condition TRUE in coroutine -> use IE to delay the last fruits to move in tray completely
			updateLock = true;
			StartCoroutine(IEDelay2(1f));
//			Debug.Log ("now HEART = " + theHeart._HeartgameOver + " /Timer = " + theHeart._HeartgameOver);
			//active the Gameover Canvas
			Invoke ("openCanvasGameover", 0.5f);

		}

	}

	IEnumerator IEDelay(float sec) {
		//use with StartCoroutine(IEDelay(0.5f));
		yield return new WaitForSeconds(sec); //Wait 1 second
		//		gameObject.SetActive(!gameObject.activeSelf);
		this.gameObject.GetComponent<AudioSource>().PlayOneShot(audio_newHighScore);
	}

	IEnumerator IEDelay2(float sec) {
		//use with StartCoroutine(IEDelay(0.5f));
		yield return new WaitForSeconds(sec); //Wait 1 second
//		Debug.Log ("is in IEDelay2");
		_gameControlOver = true;
		theHeart._HeartgameOver = true;
		theTimer._isOver = true;
//		Debug.Log ("now HEART = " + theHeart._HeartgameOver + " /Timer = " + theHeart._HeartgameOver + " /curSorted = ");

	}

	void openCanvasGameover ()
	{
		updateScore ();
		thecanvasGameOver.gameObject.SetActive (true);
		playLastSound ();
	}

	void playLastSound(){
		if (!playLastSoundLock) {
			if (audio_newHighScore && newHighScore) {
//				Debug.Log ("WooHoo");
				StartCoroutine (IEDelay (1f));
			}
			if (audio_gameOver) {
				this.gameObject.GetComponent<AudioSource> ().PlayOneShot (audio_gameOver);
			}
			playLastSoundLock = true;
		}
	}

	void updateScore ()
	{
		int bestScore = PlayerPrefs.GetInt (theMedalSTD.LevelName, 0);
//		Debug.Log ("Level Score = " + _LevelScore);
//		Debug.Log ("Best Score = " + bestScore);

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
//		delete comment to reset score
//		PlayerPrefs.SetInt (theMedalSTD.LevelName, 0);
	}
}
