using UnityEngine;
using System.Collections;

public class swapObject : MonoBehaviour
{
	//just switching object
	//score increase in game control
	//increase sorting number in mouseovertray
	public MakeHeart theHeart;

	//include to check if game is over or not -> disabling to click/swap object
	public bubble_ui gameController;
	public float stepSpd = 1f;
	public Transform secondTempObj = null, secondObj = null;
	public Transform firstTempObj = null, firstObj = null;
	private Vector3 ftObj = Vector3.zero, stObj = Vector3.zero, lastFtObj = Vector3.zero, lastStObj = Vector3.zero;

	Animator firstObjAnim, secondObjAnim;
//	Vector3 tempObj;
	//	Vector3 noTempObj,switchTempObj;
	int firstValue, switchValue, tempValue;
	bool isOnMoving, isSwitch, moveAbove, moveLR, moveDown;
	GameObject firstParticleObj, secondParticleObj;

	public int _curSortedValue=1;
	public int _score;
	public GameObject[] Trays;
	//firstObj -> store the hit (second click)
	//secondObj
	//vector3 tempObj -> store Vector3 of hit position

	// Use this for initialization
	void Start ()
	{
		
	}

	void Awake ()
	{
		isSwitch = false;
		moveAbove = false;
		moveLR = false;
		moveDown = false;
		isOnMoving = false;
	}

	public void increaseScore()
	{
		//bubble ui
		gameController.incScore (_score);
	}

	// Update is called once per frame
	void Update ()
	{	

		if (gameController.isGameUIOver&&!isOnMoving) {
			//return if gameover = true
			return;
		}

		if(_curSortedValue > Trays.Length){
			gameController.isGameUIOver = true;
		}



		if (isSwitch) {
//			Debug.Log ("is in isSwitch");
			if (firstTempObj != null && secondTempObj != null) {
//				Debug.Log ("is in moving");
				if (!moveAbove) {
					moveToAbove ();
				} else if (!moveLR) {
					moveToLR ();
				} else if (!moveDown) {
					moveToDown ();
				} else if (moveDown) {
//					Debug.Log ("Do switch!");
					DoSwitch ();

				}
			} else {
//				Debug.Log ("ELSEEEEEEEEEEEEE");
			}
		} else {
//			Debug.Log ("SWITCH ELSEEEEEEEEEEEEE");
		}

		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (hit.transform.tag == "sorting_orange") {
					//					Debug.Log ("hi Ray");
					if (isOnMoving) {
						return;
					}

					if (!firstObj) {
						firstObj = hit.transform;
						firstTempObj = hit.transform;
						ftObj = firstTempObj.position;
//						firstTempObj.position = new Vector3 (firstObj.transform.position.x, -0.7f, firstObj.transform.position.z);
//						Control_sort_selection._selectionClickCounter++;
						//animation control
						if (hit.transform.GetComponent<Animator> ()) {
							firstParticleObj = hit.transform.GetChild (0).gameObject;
							firstParticleObj.gameObject.SetActive (true);
							firstObjAnim = hit.transform.GetComponent<Animator> ();
							firstObjAnim.SetBool ("isSelected", true);
							switchValue = hit.transform.GetComponent<orangeValue> ().switchValue;
							firstValue = hit.transform.GetComponent<orangeValue> ().value;
						} else {
							firstObjAnim = null;
						}
						//store first obj selected position to temp -> assign to 2nd clicked object
//						tempObj = firstObj.transform.position;

						//store the position if there is a reverse switching.
//						noTempObj = tempObj;

					} else if (firstObj != null) {

						//when 2nd clicked will come this condition -> now hit will be the 2nd object we want to swap
						//store 2nd transform
						secondObj = hit.transform;
						secondTempObj = hit.transform;
						stObj = secondTempObj.position;
//						Debug.Log ("second");
//						secondTempObj.position = new Vector3 (secondObj.transform.position.x, 1.5f, secondObj.transform.position.z);
//						Control_sort_selection._selectionClickCounter++;
						//handle if click 2 times with same obj -> cancel ??!
						if (firstObj == secondObj) {
							//Debug.Log ("Is SAME");
							firstObj = null;
							secondObj = null;
							firstTempObj = null;
							secondTempObj = null;
							//clear anim too
							setAnimFalse ();
							firstParticleObj.gameObject.SetActive (false);
							secondParticleObj.gameObject.SetActive (false);
							return;
						}
						//store the position if there is a reverse switching.
//						switchTempObj = secondObj.transform.position;
						//animation control
						if (hit.transform.GetComponent<Animator> ()) {
							//active particle
							secondParticleObj = hit.transform.GetChild (0).gameObject;
							secondParticleObj.gameObject.SetActive (true);
							secondObjAnim = hit.transform.GetComponent<Animator> ();
							secondObjAnim.SetBool ("isSelected", true);
							tempValue = hit.transform.GetComponent<orangeValue> ().value;
						} else {
							secondObjAnim = null;
						}

//						Debug.Log (switchValue + "switch = tempValue " + tempValue);
						if (switchValue == tempValue && this._curSortedValue == firstValue) {
							firstParticleObj.gameObject.SetActive (false);
							secondParticleObj.gameObject.SetActive (false);
//							DoSwitch ();
							isSwitch = true;
//							Debug.Log ("isSwitch = TRUEEEEEEEEEEEEE");
						} else {
//							Debug.Log ("IS WRONG");
							firstObj = null;
							secondObj = null;
							firstTempObj = null;
							secondTempObj = null;
							StartCoroutine (IEDelay (0.5f));
							theHeart.LosingHeart ();

						}
					}

				}
			}
		}	
	}


	IEnumerator IEDelay (float sec)
	{
		//use with StartCoroutine(IEDelay(0.5f));
		yield return new WaitForSeconds (sec); //Wait 1 second
//		gameObject.SetActive(!gameObject.activeSelf);
		setAnimFalse ();
		firstParticleObj.gameObject.SetActive (false);
		secondParticleObj.gameObject.SetActive (false);
	}

	void moveToAbove ()
	{
		
		isOnMoving = true;

		//first go above
		float step = stepSpd * Time.deltaTime;
		Vector3 fTarget = new Vector3 (ftObj.x, -0.7f, ftObj.z);
		Vector3 sTarget = new Vector3 (stObj.x, 1.5f, stObj.z);
		lastFtObj = ftObj;
		lastStObj = stObj;
		firstObj.transform.position = Vector3.MoveTowards (firstObj.transform.position, fTarget, step);
		secondObj.transform.position = Vector3.MoveTowards (secondObj.transform.position, sTarget, step * 1.5f);


		if (firstObj.transform.position == fTarget && secondObj.transform.position == sTarget) {
			ftObj = new Vector3 (ftObj.x, 1.5f, ftObj.z);
			stObj = new Vector3 (stObj.x, -0.7f, stObj.z);
//			Debug.Log ("moveAbove Success!");
			moveAbove = true;
		}
	}

	void moveToLR ()
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		Vector3 fTarget = ftObj;
		Vector3 sTarget = stObj;

		firstObj.transform.position = Vector3.MoveTowards (firstObj.transform.position, sTarget, step * 2.5f);
		secondObj.transform.position = Vector3.MoveTowards (secondObj.transform.position, fTarget, step * 2.5f);

		if (firstObj.transform.position == sTarget && secondObj.transform.position == fTarget) {
			ftObj = new Vector3 (ftObj.x, 1.5f, ftObj.z);
			stObj = new Vector3 (stObj.x, -0.7f, stObj.z);
//			Debug.Log ("moveLR Success!");
			moveLR = true;
		}
//		Debug.Log ("moveLR =" + moveLR);

	}

	void moveToDown ()
	{
		//third move down
		float step = stepSpd * Time.deltaTime;
		//get this from first temp
		Vector3 fTarget = lastFtObj;
		Vector3 sTarget = lastStObj;

		firstObj.transform.position = Vector3.MoveTowards (firstObj.transform.position, sTarget, step * 2.5f);
		secondObj.transform.position = Vector3.MoveTowards (secondObj.transform.position, fTarget, step * 2.5f);
		//			firstObj.transform.position = Vector3.MoveTowards (ftObj, new Vector3 (ftObj.x, -0.7f, ftObj.z), step);
		//			secondObj.transform.position = Vector3.MoveTowards (stObj, new Vector3 (stObj.x, 1.5f, stObj.z), step * 1.5f);


		if (firstObj.transform.position == sTarget && secondObj.transform.position == fTarget) {
//			Debug.Log ("moveDown Success!");
			moveDown = true;
		}
//		Debug.Log ("moveDown =" + moveLR);

	}

	public void DoSwitch ()
	{
//		Debug.Log ("SWITCHING OBJECTs!");
//		firstObj.transform.position = secondObj.transform.position;
//		secondObj.transform.position = tempObj;
		//clear animation
		this.gameObject.GetComponent<AudioSource> ().Play ();
		setAnimFalse ();

		//clear firstObj ready to make new -> change to clear in tray
//		firstObj = null;
		isSwitch = false;
		moveAbove = false;
		moveLR = false;
		moveDown = false;
		isOnMoving = false;


		firstObj = null;
		secondObj = null;
		firstTempObj = null;
		secondTempObj = null;
	}


		

	//	public void reverseDoSwitch()
	//	{
	//
	////		Debug.Log ("REVERSE SWITCHING OBJECTs!");
	////		Debug.Log ("noTempObj " + nohitValue + " = " + noTempObj);
	////		Debug.Log ("switchTempObj " + switchhitValue + " = "  + switchTempObj);
	////			if (noTempObj && switchTempObj) {
	//
	//		firstObj.transform.position = noTempObj;
	//		secondObj.transform.position = switchTempObj;
	//				//clear animation
	//				setAnimFalse ();
	//				//clear firstObj ready to make new
	//				firstObj = null;
	//
	//	}




	void setAnimFalse ()
	{
		if (secondObjAnim) {
			secondObjAnim.SetBool ("isSelected", false);
		}
		if (firstObjAnim) {
			firstObjAnim.SetBool ("isSelected", false);
		}
	}
}
