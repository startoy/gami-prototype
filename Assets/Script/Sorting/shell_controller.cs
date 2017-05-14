using UnityEngine;
using System.Collections;

public class shell_controller : MonoBehaviour
{
	


	public bubble_ui bui;
	public AudioClip switchSound;

	///* SHELL SORT VAR */
	int gap;
	int curRight;
	int curLeft;
	bool sortLock = false;
	bool animateLock = false;
//	bool animateTran = false;
	bool tempLock = false;
	bool firstNodeLock = false;
	GameObject temp = null;
	Vector3 Pos = Vector3.zero, Pos2 = Vector3.zero, Pos3 = Vector3.zero;
	Vector3 RightMostTemp = Vector3.zero;
	public GameObject[] oranges;

	// Use this for initialization
	void Start ()
	{
		gap = oranges.Length / 2;
		curRight = gap; //i
		curLeft = curRight - gap; //j

	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (sortLock) {
			return;
		}
		if (gap > 0) {
			if (curRight >= oranges.Length) {
				gap = gap / 2;
				curRight = gap; //i
				curLeft = curRight - gap; //j
			}

			if (gap <= 1 && curRight <= 0) {
				StartCoroutine (IEDelay (2f));
//				Debug.Log ("setTag 52 --oranges.Length="+oranges.Length+" curRight="+curRight+" gap"+ gap);
				setTagArray ("sorted", oranges.Length-1, 1);
			} else {
				ShellSort ();
			}
		} else {
			return;
		}
	}

	void PlaySound(AudioClip sound){	
		this.gameObject.GetComponent<AudioSource> ().PlayOneShot (sound);
	}
		

	IEnumerator IEDelay(float sec) {
		//play Audio "new high score" once

		//use with StartCoroutine(IEDelay(0.5f));
		yield return new WaitForSeconds(sec); //Wait 1 second

		sortLock = true;
		bui.isGameUIOver = true;
	}

	void setTagArray (string tag, int cr, int gap)
	{
		for (int i = cr; i >= 0; i -= gap) {
			oranges [i].transform.tag = tag;
//			Debug.Log ("i="+i+" tag="+tag);
		}
	}

	Vector3 getVector3 (GameObject obj)
	{
		return  obj.transform.position;
	}

	void ShellSort ()
	{

		bool lockL = false, lockR = false;

		if (!tempLock) {
			temp = oranges [curRight];
			tempLock = true;
//			Debug.Log (curRight + "temp = "+temp.GetComponent <orangeValue> ().value);
		}
		//กดที่ตัวซ้าย เพื่อสลับ
		lockL = clickLeft ();
		//กดที่ตัวขวาที่ยก เพื่อข้าม
		lockR = clickRight ();

//		ทำตัวขวาสุดลอยขึ้นข้างบนก่อน ONCE !!
		if (!animateLock) {
			//เก็บตำแหน่งขวาสุดไว้
			RightMostTemp = getVector3 (oranges [curRight]);
			Pos = getVector3 (oranges [curRight]);
			oranges [curRight].GetComponent <orangeValue> ().curPos = Pos;
			oranges [curRight].GetComponent <orangeValue> ().ismoveUP = true;
			animateLock = true;
			firstNodeLock = true;
		}

//		Debug.Log ("setTag 115 --CurRight="+curRight+" gap"+ gap);
		setTagArray ("onsort", curRight, gap);
		oranges [curLeft].transform.tag = "pairsort";
		if (oranges [curLeft].GetComponent <orangeValue> ().value > temp.GetComponent <orangeValue> ().value) {
			if (lockL) {
				// UI
				bui.incScore (25);
				PlaySound(switchSound);
				//
				Pos = getVector3 (oranges [curLeft]);
				//เลื่อนซ้ายไปแทนขวา
				Pos2 = getVector3 (oranges [curLeft]);
				oranges [curLeft + gap] = oranges [curLeft];
				oranges [curLeft].GetComponent <orangeValue> ().curPos = RightMostTemp;
				oranges [curLeft].GetComponent <orangeValue> ().ismoveLR = true;
				curLeft -= gap;

				if (curLeft < 0) {
					//เลื่อนขวาที่ยกสูงไปแทนคัวทางซ้ายล่าสุด
					oranges [curLeft + gap] = temp;
					oranges [curLeft + gap].GetComponent <orangeValue> ().curPos = Pos;
					oranges [curLeft + gap].GetComponent <orangeValue> ().ismoveLR = true;
					animateLock = false;
					tempLock = false;
//					Debug.Log ("setTag 139 unsort -curRight="+curRight+" gap"+ gap);
					setTagArray ("unsort", curRight, gap);
					curRight++; //i
					curLeft = curRight - gap; //j
				} else {
					if (firstNodeLock) {
						oranges [curLeft + gap].GetComponent <orangeValue> ().curPos = RightMostTemp;
						firstNodeLock = false;
					} else {
						Pos2 = getVector3 (oranges [curLeft + gap]);
						oranges [curLeft + gap].GetComponent <orangeValue> ().curPos = Pos3;
					}

					oranges [curLeft + gap].GetComponent <orangeValue> ().ismoveLR = true;
					oranges [curLeft + gap] = temp;
					Pos3 = Pos2;

//					animateLock = false;
				}
			}else if (lockR){
				//decrease
				bui.theHeart.LosingHeart ();
			}
		} else {
			if (lockR) {
				PlaySound(switchSound);
				bui.incScore (25);
				if (animateLock) {

					if (firstNodeLock) {
						//ถ้าตัวแรกตรวจสอบ แล้วไม่ได้จะสลับ ให้เลื่อนลงธรรมดาๆ
						Pos = getVector3 (oranges [curRight]);
						oranges [curRight].GetComponent <orangeValue> ().curPos = Pos;
						oranges [curRight].GetComponent <orangeValue> ().ismoveDown = true;
						firstNodeLock = false;
					} else {
						oranges [curLeft + gap].GetComponent <orangeValue> ().curPos = Pos2;
						oranges [curLeft + gap].GetComponent <orangeValue> ().ismoveLR = true;
					}

					animateLock = false;
					firstNodeLock = false;
				}
				tempLock = false;
//				Debug.Log ("setTag 181 -curRight="+curRight+" gap"+ gap);
				setTagArray ("unsort", curRight, gap);
				curRight++; //i
				curLeft = curRight - gap; //j
			}else if (lockL){
				//decrease
				bui.theHeart.LosingHeart ();
			}

		}
			


	}



	bool clickLeft ()
	{
		
		bool res = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit.transform.tag == "pairsort" && hit.transform == oranges [curLeft].transform) {
				res = true;
			}
		}
		return res;
	}

	bool clickRight ()
	{

		bool res = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit.transform.tag == "onsort" && hit.transform == oranges [curLeft+gap].transform) {
				res = true;
			}
		}
		return res;
	}


	/*
	void shellSort (int[] A, int n)
	{
		// i --> ตัวขวา, ตัวตั้งต้นก่อนที่ j จะเอาลดลงไปตาม gap ไปเรื่อยๆ  4 -> 0 -> -4
		int gap, i, j;
		int temp;
		gap = n / 2;
		while (gap > 0) {
			if (gap < 0) {
				return;
			}
			for (i = gap; i < n; i++) {
				temp = A [i];    // Current item to be inserted
//				Debug.Log ("i = " + i + " A[" + i + "] = " + temp+"\ngap "+gap);
				for (j = i - gap; j >= 0; j = j - gap) {
//					Debug.Log ("j = " + j + " A[" + j + "] = " + A [j]);
					if (A [j] > temp) {
//						Debug.Log ("A["+j+"] "+A[j] + " > temp" + temp);
						A [j + gap] = A [j];
					} else {
						break;
					}       
				}
				A [j + gap] = temp;
			}
			//
			gap = gap / 2;
		}
	}﻿*/

	void showText (int[] numbers)
	{
		//Display Array Content
		IEnumerator sorted = numbers.GetEnumerator ();
		while (sorted.MoveNext ()) {
			Debug.Log (sorted.Current);
		}
	}

	/*
	 * void ShellSort (GameObject[] array)
	{
		int n = array.Length; 
		int gap = n / 2; 
		GameObject temp;
		bool clicgap1 = false, clicgap2 = false;

		while (gap > 0) { 
			for (int i = 0; i + gap < n; i++) {
				int j = i + gap;
				temp = array [j]; 
				array [j].transform.tag = "onsort";
				while (j - gap >= 0 && temp.GetComponent <orangeValue> ().value < array [j - gap].GetComponent <orangeValue> ().value) { 
					array [j - gap].transform.tag = "onsort";
					array [j] = array [j - gap];
					j -= gap;
				}
				array [j] = temp;
			}

			gap = gap / 2;

		}
	}
	*/

	/*	
 * void ShellSort (int[] array)
	{
		showText (array);
		int n = array.Length;
		int gap = n / 2;
		int temp;

		while (gap > 0) {
			for (int i = 0; i + gap < n; i++) {
				int j = i + gap;
				temp = array [j];
				Debug.Log ("i="+i+" gap="+gap+" temp = array ["+j+"] = " + temp + "\n j-gap="+(j-gap)+">=0 && " + temp + "<" + array[j-gap] );
				while (j - gap >= 0 && temp < array [j - gap]) {
					Debug.Log ("then array["+j+"]=" + array [j] + " || array["+(j-gap)+"]=" + array [j - gap]);
					array [j] = array [j - gap];
					j -= gap; //after assign j-gap to f --> then now we assign j-gap to j and assign temp to
					Debug.Log ("j=j-gap = "+j+"\nwhile new j-gap="+(j-gap));
				}
				array [j] = temp;
				Debug.Log ("exit while loop\narray["+j+"] = temp = " + array [j]);
			}

			gap = gap / 2;
		}
		showText (array);
	}*/




}