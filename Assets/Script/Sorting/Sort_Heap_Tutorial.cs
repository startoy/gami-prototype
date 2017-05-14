using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sort_Heap_Tutorial : MonoBehaviour
{

	public TextAsset TextFile;
	public Text TextObj;
	public GameObject[] tap;
	string[] tLine;
	int counter = 0;

	int txtLine;
	int tapNum;
	int setCounter;

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

	void setLineArray ()
	{
		if (TextFile != null) {
			tLine = (TextFile.text.Split ('\n'));
			TextObj.text = tLine [0];
		}
	}

	// Use this for initialization
	void Start ()
	{
		setLineArray ();

	}

	void Awake ()
	{
		setTapActiveOnce (0);
	}

	// Update is called once per frame
	void Update ()
	{
		


		//input all time
		Debug.Log (counter);
		if (counter == 0) {
			if (clicked ()) {
				changeText (1);
				setTapActiveOnce (1);
				counter = 1;
			}
		}
		else if (counter == 1) {
			
			if (clicked ()) {
				changeText (2);
				txtLine = 3;
				tapNum = 2;
				setCounter = 2;
				Invoke ("invokeText",4f);
				setTapActiveOnce (999);
			}
		} else if (counter == 2) {
			if (clicked ("graph_arrow")) {
				changeText (4);
				setTapActiveOnce (3);
				counter = 3;
			}

		} else if (counter == 3) {
			print ("counter 3");
			if (clicked ()) {
				changeText (999);
				setTapActiveOnce (999);
				counter = 4;
//				txtLine = 6;
//				tapNum = 4;
//				setCounter = 4;
//				Invoke ("invokeText",4f);
			}
		} else if (counter == 4) {
			if(heap_controller._heapSortReverseMode==2){
				changeText (5);
				setTapActiveOnce (5);
				if (clicked ("graph_arrow")) {
				changeText (6);
				setTapActiveOnce (4);
				counter = 5;

			}
			}
		} else if (counter == 5) {
			if (clicked ()) {
				changeText (7);
				setTapActiveOnce (999);
				counter = 6;
			}
		} 
		else if (counter == 6) {
			changeText (999);
			if (clicked ()) {
				counter = 7;
			}
		} 
//		else if (counter == 7) {
//			if (clicked ()) {
//				changeText (4);
//				setTapActiveOnce (2);
//				counter = 8;
//			}
//		} else if (counter == 8) {
//			if (clicked ()) {
//				changeText (999);
//				setTapActiveOnce (999);
//				counter = 8;
//			}
//		}


	}

	void invokeText(){
		changeText (txtLine);
		setTapActiveOnce (tapNum);
		counter = setCounter;
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


	bool clicked (string tagNames)
	{
		string[] tagName = new string[3];
		tagName[0] = "";
		if (tagNames == null) {
			tagName [0] = "unsort";
			tagName [1] = "sorted";
			tagName [2] = "onsort";
		} else {
			tagName [0] = tagNames;
		}

		bool res = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			foreach (string str in tagName) {
				if (hit && hit.transform.tag == str) {
					res = true;
				}
			}
		}
		return res;
	}
}
