using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class StackingOrder : MonoBehaviour
{
	//Prefab for create new image
	public Image _imgPrefab;
	//position in local canvas to appear
	float xpos = 15f;
	//user answer use static list
	static public List<string> UserAnswerInorder;
	static public int ListCount;
	public int ScoreGive=10;
	public busMovement busM;

	// Use this for initialization
	void Start ()
	{
		ListCount = 0;
		UserAnswerInorder = new List<string> ();

	}
	
	// Update is called once per frame
	public bool MakePersonBar (Sprite PersonSprite)
	{
		string name = PersonSprite.name.ToString ();
		//if true
		bool chk = CheckIsTempEqual (name);
		if (chk) {
			Image newPersonBar = Instantiate (_imgPrefab);
			newPersonBar.transform.SetParent(this.transform, true);
			newPersonBar.sprite = PersonSprite;

			//ใช้ localposition เพราะอ้างอิงจากตัว parent
			newPersonBar.GetComponent<RectTransform> ().localPosition = new Vector3 (xpos, -20f, 0f);
			xpos += 70f;
		}
		//		Debug.Log ("STK : " + name);
		return chk;
	}

	public bool CheckIsTempEqual (string name)
	{
		UserAnswerInorder.Add (name);
//		Debug.Log ("Adding " + name);
		string[] userAnswer = UserAnswerInorder.ToArray ();
		string[] Answer = busM.answer;
		int i = ListCount;
		bool res = false;
		if (userAnswer [i] == Answer [i]) {
			busM.bui.incScore (ScoreGive);
			ListCount++;
			res = true;
		} else {
			UserAnswerInorder.Remove (name);
			busM.bui.theHeart.LosingHeart ();
		}
		return res;
	}

	void Update ()
	{
	
	}

}
