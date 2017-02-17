﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SortSelectionTutorial : MonoBehaviour
{

	public TextAsset TextFile;
	public Text TextObj;
	public GameObject[] tap;
	string[] tLine;
	int counter;

	// Use this for initialization
	void Start ()
	{
		if (TextFile != null) {
			tLine = (TextFile.text.Split ('\n'));
			TextObj.text = tLine [0];
			//			Debug.Log (Input.GetAxis ("Horizontal"));
			foreach (GameObject arr in tap) {
				arr.SetActive (false);
			}
		}
		tap [0].SetActive (true);
	}
	void Awake(){tap [0].SetActive (true);}

	// Update is called once per frame
	void Update ()
	{
		//input all time
		counter = MouseoverTray._curSortedValue;
		if (counter == 1) {
			if (Input.GetMouseButtonDown (0)) {
				Invoke ("ink1", 0.5f);
			}
		} else if (counter == 2) {
			TextObj.text = tLine [2];
			tap [1].SetActive (false);
			tap [2].SetActive (true);
		} else if (counter == 4) {
			TextObj.text = "";
			foreach (GameObject arr in tap) {
				arr.SetActive (false);
			}
		}

	}

	void changeText (int a)
	{
		TextObj.text = tLine [a];
	}

	void ink1 ()
	{
		changeText (1);
		tap [0].SetActive (false);
		tap [1].SetActive (true);

	}

}
