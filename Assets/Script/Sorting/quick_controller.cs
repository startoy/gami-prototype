using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class quick_controller : MonoBehaviour
{

	bool chooseLeft = false, chooseRight = false;
	int left, right, pivot;

	public bubble_ui bui;
	// L > p , R < p
	// L moving to Right , R moving to Left
	public indicator_LRP[] indicator;
	// 0 = pivot, 1 = left, 2 = right
	public GameObject[] oranges;
	// Use this for initialization
	void Start ()
	{
		left = 0;
		right = oranges.Length - 2;
		pivot = oranges.Length - 1;
		chooseLeft = true;
		currentPointing ();
//		Debug.Log ("Left" + left + " Right" + right+" Pivot"+pivot);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(bui.isGameUIOver){return;}
		Debug.Log ("Left" + left + " Right" + right + " Pivot" + pivot + "\nchooseLeft="+chooseLeft+" chooseRight="+chooseRight);


		if (chooseLeft) {
			indicatorActive ('L');
			Debug.Log ("chooseLeft");
			if (oranges [left].GetComponent <orangeValue> ().value >= oranges [pivot].GetComponent <orangeValue> ().value) {
				if (clickDetech (left)) {
					bui.incScore (25);
					oranges [left].transform.tag = "onsort";
					currentPointing (); //moving LRP
					chooseLeft = false;
					indicatorActive ('A'); //active or deactive
					chooseRight = true;
				}else if(clickDetechFalse(left)){
					bui.theHeart.LosingHeart ();
				}
			} else {
				if(left==0 && right == 5 && pivot ==6){
					oranges [pivot].transform.tag = "sorted";
					bui.isGameUIOver = true;
					left = 6;
					right = 6;
					pivot = 6;
					indicatorActive ('A'); //active or deactive
					currentPointing ();
					}
				if(left==1 && right == 1 && pivot ==2){
//					StartCoroutine (leftPlusDelay (1f));
					if (clickDetech (left+1)) {
						bui.incScore (25);
						// if click left + 1
						left++;
						oranges [left].transform.tag = "onsort";
						currentPointing (); //moving LRP
						chooseLeft = false;
						indicatorActive ('A'); //active or deactive
						chooseRight = true;
					}else if(clickDetechFalse(left+1)){
						bui.theHeart.LosingHeart ();
					}
				}else{
					left++;
				}
			}
		} else if (chooseRight) {
			if (right == left) {
				Debug.Log ("right == left");
				indicatorActive ('R');
				if (clickDetech (right)) {
					bui.incScore (25);
					Debug.Log ("right >= left");
					swapOrangePos (left, pivot);
					GameObject temp = oranges [left];
					oranges [left] = oranges [pivot];
					oranges [pivot] = temp;
					StartCoroutine (curPositionDelay (2f));
					if (left == 0 && right == 0 && pivot == 2) {
						chooseRight = false;
						chooseLeft = true;
					}
					oranges [left].transform.tag = "sorted";
					right--;
					oranges [pivot].transform.tag = "unsort";
					pivot = right;
					left = 0;
					right--;
					if(right<0 && pivot <0)
					{
						left = 1;
						right = 1;
						pivot = 2;
						StartCoroutine (curPositionDelay (2f));
					}

				}else if(clickDetechFalse(right)){
					bui.theHeart.LosingHeart ();
				}
			} else {
				if (right < left) {
					Debug.Log ("right < left");
					indicatorActive ('R');
					if (clickDetech (right)) {
						bui.incScore (25);
						oranges [right].transform.tag = "onsort";
						indicatorActive ('A'); //active or deactive
						oranges [pivot].transform.tag = "sorted";
						StartCoroutine (curPositionDelay (0.5f));
						oranges [right].transform.tag = "unsort";
						pivot = right;
						Debug.Log ("before right " + right);
						right--;

						Debug.Log ("right-- " + right);
						left = 0;
						if(left==0 && right==1 && pivot==2){
						chooseRight = false;
						chooseLeft = true;
						}else if(left==0 && right == 0 && pivot== 1){
							oranges [right].transform.tag = "sorted";
							oranges [1].transform.tag = "sorted";
							pivot = 7;
							right = 6;
							left = 6;

						}
					}else if(clickDetechFalse(right)){
						bui.theHeart.LosingHeart ();
					}
				} else {
					Debug.Log ("ELSE R != L ");
					indicatorActive ('R');
					if (oranges [right].GetComponent <orangeValue> ().value <= oranges [pivot].GetComponent <orangeValue> ().value) {
						if (clickDetech (right)) {
							bui.incScore (25);
							oranges [right].transform.tag = "onsort";
							currentPointing (); //moving LRP
							StartCoroutine (chooseLRDelay (1f, 'R')); //set chooseRight to FALSE 1sec
							indicatorActive ('A'); //active or deactive
						}else if(clickDetechFalse(right)){
							bui.theHeart.LosingHeart ();
						}
					} else {
						right--;
					}
				}
			}
		}

		if (!chooseLeft && !chooseRight) {
			if (oranges [left].GetComponent <orangeValue> ().value > oranges [right].GetComponent <orangeValue> ().value) {
				swapOrangePos (left, right);
				GameObject temp = oranges [left];
				oranges [left] = oranges [right];
				oranges [right] = temp;
				//swap left and right
				oranges[left].transform.tag="unsort";
				oranges[right].transform.tag="unsort";
				StartCoroutine (chooseLRDelay (0.6f, 'L')); //set chooseLeft to TRUE 1sec
			} else {
			
			}
		}

	}
	IEnumerator leftPlusDelay (float sec)
	{
		yield return new WaitForSeconds (sec);
		left++;
	}

	IEnumerator curPositionDelay (float sec)
	{
		yield return new WaitForSeconds (sec);
		indicatorActive ('A');
		currentPointing ();
		chooseRight = false;
		chooseLeft = true;
	}

	IEnumerator chooseLRDelay (float sec, char mode)
	{
		yield return new WaitForSeconds (sec);
		switch (mode) {
		case 'L':
			chooseLeft = true;
			break;
		case 'R':
			chooseRight = false;
			break;
		}
	}

	void QuickSort ()
	{
		
	}

	bool clickDetech (int number)
	{
		bool res = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (hit.transform == oranges [number].transform && hit.transform.tag == "unsort" || hit.transform.tag == "onsort") {
					res = true;
				}
			}
		}
		return res;
	}

	bool clickDetechFalse (int number)
	{
		bool res = false;
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (hit.transform != oranges [number].transform && hit.transform.tag == "unsort" || hit.transform.tag == "onsort") {
					res = true;
				}
			}
		}
		return res;
	}

	void swapOrangePos (int left, int right)
	{
		Vector3 LPosTemp = oranges [left].transform.position;
		oranges [left].GetComponent <orangeValue> ().nextPos = oranges [right].transform.position;
		oranges [left].GetComponent <orangeValue> ().finishChain = false;
		oranges [left].GetComponent <orangeValue> ().ChainMove = true;
		oranges [right].GetComponent <orangeValue> ().nextPos = LPosTemp;
		oranges [right].GetComponent <orangeValue> ().finishChain = false;
		oranges [right].GetComponent <orangeValue> ().ChainMove = true;
		if(oranges [left].GetComponent <orangeValue> ().finishChain && oranges [right].GetComponent <orangeValue> ().finishChain)
		{
			Debug.Log ("orange moving finish");
		}
	}

	void currentPointing ()
	{
		indicatorPoint ('L', oranges [left]);
		indicatorPoint ('R', oranges [right]);
		indicatorPoint ('P', oranges [pivot]);
	}

	void indicatorActive (char LRP)
	{
		//swutch case only use with CHAR and INT !!
		switch (LRP) {
		case 'P':
			indicator [0].isActive = true;
			indicator [1].isActive = false;
			indicator [2].isActive = false;
			break;
		case 'L':
			indicator [0].isActive = false;
			indicator [1].isActive = true;
			indicator [2].isActive = false;
			break;
		case 'R':
			indicator [0].isActive = false;
			indicator [1].isActive = false;
			indicator [2].isActive = true;
			break;
		case 'A':
			indicator [0].isActive = false;
			indicator [1].isActive = false;
			indicator [2].isActive = false;
			break;
		}
	}

	void indicatorPoint (char LRP, GameObject point)
	{
		//swutch case only use with CHAR and INT !!
		switch (LRP) {
		case 'P':
			indicator [0].setToMoving (true, point);
			break;
		case 'L':
			indicator [1].setToMoving (true, point);
			break;
		case 'R':
			indicator [2].setToMoving (true, point);
			break;
		}
	}

	int QPartition (int[] numbers, int left, int right)
	{
		int pivot = numbers [left];
		while (true) {
			while (numbers [left] < pivot)
				left++;

			while (numbers [right] > pivot)
				right--;

			if (left < right) {
				int temp = numbers [right];
				numbers [right] = numbers [left];
				numbers [left] = temp;
			} else {
				return right;
			}
		}
	}

	void QQuickSort_Recursive (int[] arr, int left, int right)
	{
		// For Recusrion
		if (left < right) {
			int pivot = QPartition (arr, left, right);

			if (pivot > 1)
				QQuickSort_Recursive (arr, left, pivot - 1);

			if (pivot + 1 < right)
				QQuickSort_Recursive (arr, pivot + 1, right);
		}
	}
		
}
