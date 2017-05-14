using UnityEngine;
using System.Collections;

public class TestScript : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

//	void ShellSort ()
//	{
//
//		bool lock1 = false, lock2 = false;
//
//		if (!tempLock) {
//			temp = oranges [curRight];
//			tempLock = true;
//			//			Debug.Log (curRight + "temp = "+temp.GetComponent <orangeValue> ().value);
//		}
//		lock1 = click1 ();
//
//		//		ทำตัวขวาสุดลอยขึ้นข้างบนก่อน ONCE !!
//		if (!animateLock) {
//			//เก็บตำแหน่งขวาสุดไว้
//			RightMostTemp = getVector3 (oranges [curRight]);
//			Pos = getVector3 (oranges [curRight]);
//			oranges [curRight].GetComponent <orangeValue> ().curPos = Pos;
//			oranges [curRight].GetComponent <orangeValue> ().ismoveUP = true;
//			animateLock = true;
//			firstNodeLock = true;
//		}
//
//		setTagArray ("onsort", curRight, gap);
//		if (oranges [curLeft].GetComponent <orangeValue> ().value > temp.GetComponent <orangeValue> ().value) {
//			if (lock1) {
//				Pos = getVector3 (oranges [curLeft]);
//				Debug.Log ("curLeft > temp -- swap");
//				//เลื่อนซ้ายไปแทนขวา
//				Pos2 = getVector3 (oranges [curLeft]);
//				Debug.Log ("Pos2 of" + oranges [curLeft].GetComponent<orangeValue> ().value);
//				oranges [curLeft + gap] = oranges [curLeft];
//				oranges [curLeft].GetComponent <orangeValue> ().curPos = RightMostTemp;
//				oranges [curLeft].GetComponent <orangeValue> ().ismoveLR = true;
//				curLeft -= gap;
//
//				if (curLeft< 0) {
//					//เลื่อนขวาที่ยกสูงไปแทนคัวทางซ้ายล่าสุด
//					Debug.Log ("curleft < 0");
//
//					oranges [curLeft + gap] = temp;
//					oranges [curLeft + gap].GetComponent <orangeValue> ().curPos = Pos;
//					oranges [curLeft + gap].GetComponent <orangeValue> ().ismoveLR = true;
//					Debug.Log (oranges [curLeft + gap].GetComponent<orangeValue> ().value);
//					animateLock = false;
//					setTagArray ("unsort", curRight, gap);
//					tempLock = false;
//					curRight++; //i
//					curLeft = curRight - gap; //j
//				} else {
//					Debug.Log ("curleft > 0");
//					Debug.Log ("firstcurleft + gap = " + oranges [curLeft + gap].GetComponent<orangeValue> ().value);
//					if(firstNodeLock){
//						oranges [curLeft+gap].GetComponent <orangeValue> ().curPos = RightMostTemp;
//						Debug.Log ("swap with RightPosTemp");
//						firstNodeLock = false;
//					}else{
//						oranges [curLeft+gap].GetComponent <orangeValue> ().curPos = Pos2;
//						Debug.Log ("swap with Pos2 ABOVE");
//					}
//
//					oranges [curLeft+gap].GetComponent <orangeValue> ().ismoveLR = true;
//					oranges [curLeft+gap] = temp;
//					Debug.Log ("now curleft + gap = " + oranges [curLeft + gap].GetComponent<orangeValue> ().value);
//					//					animateLock = false;
//				}
//			}
//		} else {
//			if (lock1) {
//
//
//
//				curLeft -= gap;
//				if (curLeft< 0) {
//					if (animateLock) {
//
//						if(firstNodeLock){
//							Pos = getVector3 (oranges [curRight]);
//							oranges [curRight].GetComponent <orangeValue> ().curPos = Pos;
//							oranges [curRight].GetComponent <orangeValue> ().ismoveDown = true;
//							firstNodeLock = false;
//						}else{
//							oranges [curRight - gap].GetComponent <orangeValue> ().curPos = Pos2;
//							oranges [curRight - gap].GetComponent <orangeValue> ().ismoveLR = true;
//							Debug.Log ("swap with Pos2 BOTTOM");
//						}
//
//						Debug.Log ("else animate LOCK");
//						Debug.Log (oranges [curLeft + gap].GetComponent<orangeValue> ().value);
//						Debug.Log (oranges [curRight - gap].GetComponent<orangeValue> ().value);
//						Debug.Log (oranges [curRight].GetComponent<orangeValue> ().value);
//
//						Debug.Log("END ");
//						//						Pos = getVector3 (oranges [curRight]);
//						//						oranges [curRight].GetComponent <orangeValue> ().curPos = Pos;
//						//						oranges [curRight].GetComponent <orangeValue> ().ismoveDown = true;
//						animateLock = false;
//						firstNodeLock = false;
//					}
//					setTagArray ("unsort", curRight, gap);
//					tempLock = false;
//					curRight++; //i
//					curLeft = curRight - gap; //j
//				}
//			}
//		}
//
//
//		if (gap <= 1 && curRight == 7 && curLeft == 0) {
//			setTagArray ("sorted", curRight, gap);
//			sortLock = true;
//		}
//	}
}

