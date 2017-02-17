using UnityEngine;
using System.Collections;

public class insertion_controller : MonoBehaviour
{

	public Transform secondObj = null, firstObj = null;
	public static int curInsertionSortedVal;

	int tempValue = 0, swapValue = 0, prevValue = 0;
	bool isMoving = false, isObjMove = false;
	bool isMoveRightDone = false;

	//var for do moving motions
	private Vector3 Fnode, Snode,curOr;
	public float stepSpd = 2f;
	public GameObject[] oranges;
	// Use this for initialization
	void Start ()
	{
	
	}

	void Awake ()
	{
		curInsertionSortedVal = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isMoving) {
			if (firstObj != null && secondObj != null) {
				if (isObjMove) {
					//moveToObjSwitch ();
					//DO movement all
					moveToObjReplace ();
				} 
			}
		} else {
			clickObj ();
		}

	}

	void clickObj ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (!firstObj) {
					firstObj = hit.transform;
					Fnode = firstObj.transform.position;
					if(firstObj.GetComponent <orangeValue> ().swapNum!=curInsertionSortedVal)
					{
						firstObj = null;
						return;
					}
					if (firstObj.tag == "unsort") {
						tempValue = firstObj.GetComponent <orangeValue> ().value;
						Debug.Log ("firstObj = " + tempValue);
					}
					else{
						firstObj = null;
						return;
					}
				} else if (firstObj != null) {
					secondObj = hit.transform;
					Snode = secondObj.transform.position;

					/*
					 * // find LENGTH TEMPORARY SHOULD BE REMOVED WHEN DONE
					Vector3 relative = (firstObj.transform.position - secondObj.transform.position);
					//convert relative(vector3) to length
					float maggy = relative.magnitude;
					Debug.Log ("maggy=" + maggy + " relative=" + relative);
					//
					*/

					if (secondObj.tag == "sorted") {
						swapValue = secondObj.GetComponent <orangeValue> ().value;
						Debug.Log ("secondObj = " + swapValue);
						//foreach orange where tag == sorted / == secondObj --> value
						// firstTemp < value && firsttemp > valie[i-1]
						//DO IF ELSE SWAP BACK/No SWAP
						prevValue = 0;
						bool isCorrect=false;
						foreach(GameObject arr in oranges)
						{
							if(arr.transform.tag=="sorted")
							{
								if(arr.transform==secondObj)
								{
									if(tempValue < swapValue)
									{
										if (!isCorrect) {
											firstObj.transform.tag = "sorted";
											curInsertionSortedVal++;
											isMoving = true;
											isObjMove = true;
											isCorrect = true;
										}
									}else{
										//losing heart
									}
								}
								while(isMoving){
									curOr = arr.transform.position;
									moveToRight (arr);
								}
							}
						}


					} else if (firstObj == secondObj) {
						//DO NEXT SORT TRAY
					}
				}
			}
		}
	}

	void moveToObjReplace ()
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (Snode.x, Snode.y, firstObj.transform.position.z);

		firstObj.transform.position = Vector3.MoveTowards (firstObj.transform.position, sTarget, step * 2f);

		if (firstObj.transform.position == sTarget && isMoveRightDone) {
			isMoving = false;
			isObjMove = false;
			isMoveRightDone = false;
			firstObj = null;
			secondObj = null;
		}
	}

	void moveToRight(GameObject objToMove)
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (curOr.x + 2.2f, curOr.y, curOr.z);

		objToMove.transform.position = Vector3.MoveTowards (objToMove.transform.position, sTarget, step * 10);
		Debug.Log ("Hey z");
		if (objToMove.transform.position == sTarget) {
			isMoveRightDone = true;
			Debug.Log ("isMoveRightDone TRUE");
		}
	}

}
