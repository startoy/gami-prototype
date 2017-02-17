using UnityEngine;
using System.Collections;

public class MouseoverTray : MonoBehaviour
{
	public swapObject theSwap;
	public bool isSorted;
	public int _realValue;
	public static int _curSortedValue;
	//	public int score=50;

	int _tempValue, _score = 50;
	// Use this for initialization
	void Start ()
	{
//		_score = score;
	}

	void Awake ()
	{
		_curSortedValue = 1;
		isSorted = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!isSorted) {
			if (_tempValue == _realValue && _realValue == _curSortedValue) {
				increaseSort ();
			}
		}
		else 
		{
			this.GetComponent<SpriteRenderer> ().color = new Color32 (40, 255, 0, 255);

		}
		Debug.Log ("Current sorted value = " + _curSortedValue);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "sorting_orange") {
//			if (!isSorted) {
			//store the temp value from the orange
			_tempValue = other.GetComponent<orangeValue> ().value;
			if (_tempValue == _realValue && _realValue == _curSortedValue) {
//				Debug.Log ("IS TRUE -> IF");
//				Debug.Log ("_temp " + _tempValue + " == _realValue " + _realValue + " && _realValue " + _realValue + " == _curSortedValue " + _curSortedValue + " CurState = " + Control_sort_selection._selectionCurState);
//				Traylocked = true;
//				this.GetComponent<SpriteRenderer> ().color = new Color32 (40, 255, 0, 255);
				other.tag = "sorting_orange_sorted";
//				increaseSort ();

			} else {
//				Debug.Log ("Is ELSE");
//				theSwap.firstObj = null; 
			}
//			else if (Control_sort_selection._selectionCurState != 1 && !Traylocked) 
//			{
//				if (theSwap.noObj != null && theSwap.switchObj != null && !Traylocked) 
//				{
//					Debug.Log ("IS FALSE -> ELSE IF");
//					Debug.Log ("_temp " + _tempValue + " == _realValue " + _realValue + " && _realValue " + _realValue + " == _curSortedValue " + _curSortedValue +" CurState = "+ Control_sort_selection._selectionCurState);
//					theSwap.reverseDoSwitch ();
//					theSwap.theHeart.LosingHeart ();
//				}
//			}
//			else if (theSwap.noObj != null && theSwap.switchObj != null) 
//			{
//				if (Control_sort_selection._selectionCurState != 1 && _tempValue != _realValue && _realValue != _curSortedValue ) {
//					theSwap.reverseDoSwitch ();
//					theSwap.theHeart.LosingHeart ();
//				}
//			}
		}

		if (other.tag == "sorting_orange_sorted") {
			this.GetComponent<SpriteRenderer> ().color = new Color32 (40, 255, 0, 255);
		}
	}

//	void OnTriggerStay2D(Collider2D other)
//	{
//		if (other.tag == "sorting_orange") {
//			//			if (!isSorted) {
//			//store the temp value from the orange
//			_tempValue = other.GetComponent<orangeValue> ().value;
//			if (_tempValue == _realValue && _realValue == _curSortedValue && !Traylocked) {
//				Debug.Log ("IS TRUE -> IF");
//				Debug.Log ("_temp " + _tempValue + " == _realValue " + _realValue + " && _realValue " + _realValue + " == _curSortedValue " + _curSortedValue + " CurState = " + Control_sort_selection._selectionCurState);
//				Traylocked = true;
//				this.GetComponent<SpriteRenderer> ().color = new Color32 (40, 255, 0, 255);
//				other.tag = "sorting_orange_sorted";
//				increaseSort ();
//			} else {
//				Debug.Log ("Is ELSE");
//			}
//		}
//
//		if (other.tag == "sorting_orange_sorted") {
//			this.GetComponent<SpriteRenderer> ().color = new Color32 (40, 255, 0, 255);
//		}
//	}

	void increaseSort ()
	{
		isSorted = true;
		_curSortedValue += 1;
		increaseScore (_score);
//		Control_sort_selection._selectionCurState=1;
//		theSwap.firstObj = null;
//		theSwap.secondObj = null;
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (!isSorted) {
			if (other.tag == "sorting_orange") {
				this.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			
			} else if (other.tag == "sorting_orange_sorted") {
				this.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 1f);
			}
		}
	}

	void increaseScore (int score)
	{
		Control_sort_selection._selectionLevelCurScore += score;
	}
}
