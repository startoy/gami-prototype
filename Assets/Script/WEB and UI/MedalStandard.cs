using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MedalStandard : MonoBehaviour {
	//medal
//	public Image _Medal;
	public Sprite[] _Sprite;
	public Text _TextScore, _TextBestScore;
	public string LevelName;
//	public AudioClip audio_newHighScore, audio_gameOver;
	//should be GOLD  -> SILVER -> BRONZE
	public int scoreBronze, scoreSilver, scoreGold;

	// Use this for initialization
	void Start () {
//		if (audio_gameOver) {
//			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (audio_gameOver);
//		}
	}

	void Awake(){
//		if (audio_gameOver) {
//			this.gameObject.GetComponent<AudioSource> ().PlayOneShot (audio_gameOver);
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
