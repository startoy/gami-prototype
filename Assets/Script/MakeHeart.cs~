using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MakeHeart : MonoBehaviour
{

	public Image _HeartPrefab;
	public int MaxHeart;
	//use this for condition heart
	public bool _HeartgameOver;
	public int _CurHeart;
	int _ChildX;
	float xpos = 590f;
	Animator AnimLastChild;
	Transform Child;

	public GameObject heartObj;

	// Use this for initialization
	void Start ()
	{
		_ChildX = 1;
		_CurHeart = MaxHeart;

		//making heart by number of maxheart
		for (int i = 0; i < MaxHeart; i++) {
			MakingHeart ();
		}

	}

	void Awake()
	{
		_HeartgameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		Debug.Log ("Cur Heart"+_CurHeart);
		busMovement._GameOver = _HeartgameOver;
	}

	void MakingHeart ()
	{
		Image newHeart = Instantiate (_HeartPrefab); 
		newHeart.transform.SetParent (this.transform, true);
		newHeart.GetComponent<RectTransform> ().localPosition = new Vector3 (xpos, 310f, 0f);
		xpos -= 60f;
	}



	public void LosingHeart ()
	{
		
		//get number of child (heart)
		int _ChildNumber = this.transform.childCount;
		//if more than 0 and not outbound 4 -> because we can use last heart to play (heart = 0)
		if (_ChildNumber > 0 && _ChildX <= _ChildNumber + 1) {
			//check again to notoutbound of child
			if (_ChildX <= _ChildNumber) {
				AnimLastChild = this.transform.GetChild (_ChildNumber - _ChildX).gameObject.GetComponent<Animator> ();
				AnimLastChild.SetBool ("LostHeart", true);

//				Debug.Log ("xxxxxxxxxxxxxxx"+_CurHeart);
			}
			//decrease the current heart and increase the ChilX for minus with number of child
			_CurHeart--;
			_ChildX++;
//			Debug.Log ("Curheart = "+_CurHeart);
//			Debug.Log ("ChildX = "+_ChildX);
			//if current heart -1 then gameover
			if (heartObj != null) {
				showLosingHeart ();
			}

			if (_CurHeart < 1) {
				_HeartgameOver = true;
			}
		}
	}

	void showLosingHeart()
	{
		heartObj.SetActive(true);
		heartObj.gameObject.GetComponent<Animator> ().SetBool("LostHeart", true);
		StartCoroutine(IEDelay (1f));
	}

	IEnumerator IEDelay(float sec) {
		yield return new WaitForSeconds(sec); //Wait 1 second
		//		gameObject.SetActive(!gameObject.activeSelf);

		heartObj.gameObject.GetComponent<Animator> ().SetBool("LostHeart", false);
		heartObj.SetActive(false);
//		Debug.Log ("U R LOSING HEART ?");
	}

	public void addHeart ()
	{
		//this function restore the lost one

		//get number of child (heart)
		int _ChildNumber = this.transform.childCount;
		//if more than 0 and not outbound 4 -> because we can use last heart to play (heart = 0)
		if (_ChildNumber > 0 && _ChildX <= _ChildNumber + 1) {
			_CurHeart--;
			_ChildX--;
			//check again to notoutbound of child
			if (_ChildX <= _ChildNumber) {
//				Debug.Log ("Welcome a new Heart !");
				//number of child - childnum + 1 -> ex. 3 - 1 = 2 -> hear2 (ตัวสุดท้าย)
				AnimLastChild = this.transform.GetChild (_ChildNumber - _ChildX).gameObject.GetComponent<Animator> ();
				AnimLastChild.SetBool ("LostHeart", false);
				//				Debug.Log ("xxxxxxxxxxxxxxx"+_CurHeart);
			}
			//decrease the current heart and increase the ChilX for minus with number of child

			//			Debug.Log ("000000000000000"+_CurHeart);

			//if current heart -1 then gameover
			// 11/30/2016 -> change to < 1 -> the real is 0
			if (_CurHeart < 1) {
				_HeartgameOver = true;
			}
		}
	}
}
