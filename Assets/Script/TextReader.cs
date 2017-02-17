using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextReader : MonoBehaviour {

	public TextAsset TextFile;
	public Text Text1;
	string[] dLine;
	bool l1,l2 =false;
	public GameObject[] arrow;
	int count=0;
	static public bool IsTutorial;
	public busMovement busM;


	// Use this for initialization
	void Start () {
		IsTutorial = true;

		if (TextFile != null) {
			dLine = (TextFile.text.Split('\n'));
			Text1.text = dLine [0];
//			Debug.Log (Input.GetAxis ("Horizontal"));
		}

	}
	
	// Update is called once per frame
	void Update () {
		count = StackingOrder.ListCount;
		Debug.Log ("BUS ANS LENGTH = "+busM.answer.Length + " || COUNT = "+count);
		if (!l1) {
			if (Input.GetAxis ("Horizontal") == 1f || Input.GetAxis ("Vertical") == 1f) {
				Invoke ("changeText1", 1f);
//				Debug.Log ("Come in !!");
				l1 = true;
			}
		}
		if (l2) {
			if (count != null && count <= busM.answer.Length) {
				if (count < arrow.Length) {

				arrow [count].SetActive (true);
				if (count > 0) {
					arrow [count - 1].SetActive (false);
				}
				}
				if (count == 3) {
					arrow [count-1].SetActive (false);
				}
			}
		}
	}
	void changeText1(){
		Text1.text = dLine [1];
		l2 = true;
		Invoke ("changeText2", 4f);
//		Debug.Log (count);
	}
	void changeText2(){
		Text1.text = dLine [2];
	}

}
