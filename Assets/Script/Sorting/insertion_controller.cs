using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class insertion_controller : MonoBehaviour
{
	/*
	 * 		FOR INSERTION SORTING
	 * 		SETUP PUT oranges[] in GameController
	 * 			  CHANGE each oranges[] swapNumber
	 * 			  SET first oranged[] TAG to "sorted"
	*/			  

	public int eachGiveScore;
	public bubble_ui thisUI;
	public Transform secondObj = null, firstObj = null;
	public static int curInsertionSortedVal;

	int tempValue = 0, swapValue = 0, prevValue = 0;
	bool isMoving = false, isObjMove = false;
	bool isMoveRightDone = false;

	//var for do moving motions
	private Vector3 Snode, curOr;
	public float stepSpd = 2f;
	public GameObject[] oranges;
	public List<GameObject> orangesSorted;
	public  GameObject firstOranges;
	//	List<int> testList;
	// Use this for initialization
	void Start ()
	{
		List<GameObject> orangesSorted = new List<GameObject> ();


	}

	void Awake ()
	{
		//initial for game
		curInsertionSortedVal = 2;
		orangesSorted.Add (firstOranges);
		thisUI.incScore (eachGiveScore);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(curInsertionSortedVal >= oranges.Length+1)
		{
			if (!isMoving&&!isObjMove) {
				thisUI.isGameUIOver = true;
				return;
			}
		}

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

	void setChildActive(Transform other,bool setTo)
	{
		GameObject ParticleObj = other.GetChild (0).gameObject;
		ParticleObj.gameObject.SetActive (setTo);
	}

	void clickObj ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit && hit.transform.tag=="unsort" || hit && hit.transform.tag=="sorted") {
				if (!firstObj) {
					firstObj = hit.transform;
					setChildActive (firstObj,true);
//					Fnode = firstObj.transform.position;
					//บังคับให้กดได้เฉพาะตัวปัจจุบันที่จะ sort
					if (firstObj.GetComponent <orangeValue> ().swapNum != curInsertionSortedVal) {
						setChildActive (firstObj,false);
						firstObj = null;
						return;
					}
					if (firstObj.tag == "unsort") {
						tempValue = firstObj.GetComponent <orangeValue> ().value;
//						Debug.Log ("firstObj = " + tempValue);
					} else {
						setChildActive (firstObj,false);
						firstObj = null;
						return;
					}
				} else if (firstObj != null) {
					secondObj = hit.transform;
					setChildActive (secondObj,true);
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
//						Debug.Log ("secondObj = " + swapValue);
						//foreach orange where tag == sorted / == secondObj --> value
						// firstTemp < value && firsttemp > valie[i-1]
						//DO IF ELSE SWAP BACK/No SWAP

						//หาค่าแรกที่พบว่ามากกว่าตัวแรกที่เราคลิก แสดงว่าจะแทนที่ตัวนั้น
						prevValue = findFirstMax ();
						bool isCorrect = false;
						if (prevValue == swapValue) { //แสดงว่า ถ้าตรวจสอบแล้วกดที่ตัวเดียวกัน จะให้ทำการเลื่อนไปหา
							if (!isCorrect) {
								firstObj.transform.tag = "sorted";
								curInsertionSortedVal++;
								thisUI.incScore (eachGiveScore);
								isMoving = true;
								isObjMove = true;
								isCorrect = true; //lock
							}
						} else { 
							//แต่ถ้ามันค่าไม่เท่ากัน !! แสดงว่าเรากดผิด ไม่ต้องสลับ
							//losing heart
							//set null
							thisUI.theHeart.LosingHeart ();
							setChildActive (firstObj,false);
							setChildActive (secondObj,false);
							firstObj = null;
							secondObj = null;
						}

						if (isMoving) {
							//ให้มันเลื่อนไปทางขวา เฉพาะตัวที่มันมากกว่า tempValue
							foreach (GameObject arr in orangesSorted) {
								if (arr.transform.tag == "sorted" && arr.GetComponent <orangeValue> ().value>tempValue) {
									curOr = arr.transform.position;
									arr.GetComponent <orangeValue> ().curPos = curOr;
									arr.GetComponent <orangeValue> ().ismoveToRight = true;
								}
							}
						}

					} else if (firstObj == secondObj) { //ถ้าไม่ได้ไปกดตัวที่จัดเรียงแล้ว แต่มากดตัวเดิม แสดงว่าจะทำให้ตัวนี้จัดเรียง
						//หาค่าที่มากที่สุดตัวแรกที่เจอ เทียบกับตัวแรกที่เรากด
						prevValue = findFirstMax ();
						bool isCorrect = false;
						if (prevValue == 0) { //แสดงว่าไม่เกมออบเจ็คพบตัวไหนทมีี่ค่ามากกว่า tempValue
							if (!isCorrect) {
								firstObj.transform.tag = "sorted";
								orangesSorted.Add (firstObj.gameObject);
								orangesSorted.Sort ((a,b) => (a.GetComponent <orangeValue>().value.CompareTo (b.GetComponent <orangeValue>().value)));
								curInsertionSortedVal++;
								thisUI.incScore (eachGiveScore);
								setChildActive (firstObj,false);
								setChildActive (secondObj,false);
								firstObj = null;
								secondObj = null;
								isCorrect = true; //lock
							}
						} else { 
							//แต่ถ้ามันมีค่า มากกว่า 0 แสดงว่ามันมีตัวที่มากกว่า tempValue อยู่ --> เราผิด !!
							//losing heart
							//set null
							thisUI.theHeart.LosingHeart ();
							setChildActive (firstObj,false);
							setChildActive (secondObj,false);
							firstObj = null;
							secondObj = null;
//							Debug.Log ("is wrong , Click 2 time because is more than all");
						}

					} else{ //if is not the actual fruits to click --> NULL !!
						setChildActive (secondObj,false);
						secondObj = null;

					}
				}
			}
		}
	}

	int findFirstMax ()
	{
		int res = 0;
		foreach (GameObject arr in orangesSorted) {
			if (arr.transform.tag == "sorted") {
				res = arr.GetComponent <orangeValue> ().value;
				if (res > tempValue) {
//					Debug.Log ("FOUND " + res + " > " + tempValue);
					break;
					//FOUND!! break --> exit the loop
				} else {
//					Debug.Log ("NOT FOUND res = 0 ");
					res = 0;
				}
			}
		}

		return res;
	}

	void moveToObjReplace ()
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (Snode.x, Snode.y, firstObj.transform.position.z);

		firstObj.transform.position = Vector3.MoveTowards (firstObj.transform.position, sTarget, step * 3f);

		if (firstObj.transform.position == sTarget) {
			
			orangesSorted.Add (firstObj.gameObject);
			orangesSorted.Sort ((a,b) => (a.GetComponent <orangeValue>().value.CompareTo (b.GetComponent <orangeValue>().value)));

			isMoving = false;
			isObjMove = false;
			setChildActive (firstObj,false);
			setChildActive (secondObj,false);
			firstObj = null;
			secondObj = null;
		}
	}
		

}
