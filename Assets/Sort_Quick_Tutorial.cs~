using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sort_Quick_Tutorial : MonoBehaviour {
	public TextAsset TextFile;
	public Text TextObj;
	public GameObject[] tap;
	//	public GameObject[] clickedObjArray;
	string[] tLine;
	int counter = 0;

	// Use this for initialization
	void Start ()
	{
		if (TextFile != null) {
			tLine = (TextFile.text.Split ('\n'));
			TextObj.text = tLine [0];
			setTapActiveOnce (999);
		}
	}

	void Awake ()
	{
		//show text line 1
		Invoke ("ink1", 3f);
	}

	// Update is called once per frame
	void Update ()
	{
		//input all time
		print (counter);

		//input all time
		Debug.Log (counter);
		if (counter == 1) {
			if (clicked ()) {
				changeText (3);
				setTapActiveOnce (1);
				counter = 2;
			}
		} else if (counter == 2) {
			if (clicked ()) {
				changeText (4);
				setTapActiveOnce (999);
				counter = 3;
				Invoke ("ink3",10.0f);
			}
		}




	}

	void ink1 ()
	{
		changeText (1);
		Invoke ("ink2",3f);
	}

	void ink2(){
		changeText (2);
		setTapActiveOnce (0);
		counter = 1;
	}

	void ink3(){
		changeText (999);
		setTapActiveOnce (999);
	}

	void changeText (int a)
	{
		if (a == 999) {
			TextObj.text = "";
		} else {
			TextObj.text = tLine [a];
		}
	}

	void setTapActiveOnce (int num)
	{
		//num 999 --> all tap FALSE
		if (num == 999) {
			foreach (GameObject arr in tap) {
				arr.SetActive (false);
			}
		} else { 
			//if num is any number --> show only one num
			foreach (GameObject arr in tap) {
				arr.SetActive (false);
			}
			tap [num].SetActive ((true));
		}

	}


	bool clicked ()
	{
		bool res = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit && hit.transform.tag == "unsort" || hit && hit.transform.tag == "sorted" || hit && hit.transform.tag == "onsort") {
				res = true;
			}
		}
		return res;
	}
}
