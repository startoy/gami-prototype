using UnityEngine;
using System.Collections;

public class heap_controller : MonoBehaviour
{
	public heap_index h_index;
	Transform clickObj;
	public bubble_ui bui;
	int IncreaseNum = 0;
	public static int _heapSortReverseMode = 1;
	public bool isMaxHeapOnce = false;

	//for move to balloon
	bool isOrangeMoving = false;
	public GameObject[] heap_balloon;
	public GameObject[] trays;
	public GameObject[] oranges; //set switch value
	// Use this for initialization
	void Start ()
	{
	}

	void Awake(){
		_heapSortReverseMode = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(bui.isGameUIOver){return;}
		if(h_index.heap_index_moving){return;}
		bool _isMaxheap = chk_isMaxheap_balloon ();
		if (_isMaxheap && IncreaseNum >= trays.Length) 
		{
			IncreaseNum = trays.Length - 1;
			_heapSortReverseMode = 2;
		} else if(_isMaxheap && IncreaseNum<0){
			IncreaseNum = 0;
			bui.isGameUIOver = true;
		}

		if(_isMaxheap){
			if(_heapSortReverseMode==1)
			h_index.changeIndexColor ("green");
			else 
			h_index.changeIndexColor ("normal");
		}else{
			h_index.changeIndexColor ("red");
		}

		if (IncreaseNum >= trays.Length)
			//set to last
			h_index.moveToObj (trays [trays.Length - 1]);

		else if (IncreaseNum < 0){
			//set to first
			h_index.moveToObj (trays [0]);
		}
		else {
			h_index.moveToObj (trays [IncreaseNum]);
		}




		if (_heapSortReverseMode == 1) {
			// get current index to use for input orange to balloon
			if (isOrangeMoving) {
				if(moveToObjReplace ("onsort")) {
					clickObj = null;
					isOrangeMoving = false;
				}
			} else {
				char input = clickTomove ();
				if(input=='1'){
//					Debug.Log ("1 is correct");
					bui.incScore (25);

				}else if(input =='2'){
//					Debug.Log ("2 is incorrect");
					bui.theHeart.LosingHeart ();
				}
			}

			_isMaxheap = chk_isMaxheap_balloon ();
			if (_isMaxheap) {
				if (isMaxHeapOnce) {
					isMaxHeapOnce = !isMaxHeapOnce;
					IncreaseNum++;
				}
			}

		} else {
			//reverse mode 2
			if (_isMaxheap) {
				if (isMaxHeapOnce) {
					isMaxHeapOnce = !isMaxHeapOnce;
					IncreaseNum--;
				}
			}

			if (isOrangeMoving) {
				if (moveToObjReplace ("sorted")
//					&& moveToObjReplace2 ("onsort", oranges [(oranges.Length - IncreaseNum) - 1].transform)
				    ) {
					clickObj = null;
					isOrangeMoving = false;
				}
			} else {
				char input = clickObjToTray ();
				if(input=='1'){
					bui.incScore (25);
				}else if(input=='2'){
					bui.theHeart.LosingHeart ();
				}
			}

//			Debug.Log (IncreaseNum);

		}
	}
		

	char clickTomove ()
	{
		char res = '0';
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (!clickObj && hit.transform.tag == "unsort"
				    && hit.transform.GetComponent <orangeValue> ().switchValue == IncreaseNum
				    && chk_isMaxheap_balloon ()) {
					clickObj = hit.transform;
					setOrangeTomove ();
					res = '1';
				}else if(!clickObj && hit.transform.tag == "unsort"){
					res = '2';
				}
			}
		}
		return res;
	}

	char clickObjToTray ()
	{
		char res = '0';
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (!clickObj && hit.transform.tag == "onsort"
				    && hit.transform.GetComponent <orangeValue> ().value == IncreaseNum + 1
				    && chk_isMaxheap_balloon ()) {
					clickObj = hit.transform;
					GameObject newObj = heap_balloon [IncreaseNum].GetComponent <heap_balloon> ()._CurSurface;
					DoReplace (heap_balloon[0], newObj);
					setOrangeTomove ();
					res = '1';
				}else if(!clickObj && hit.transform.tag == "onsort"){res = '2';}
			}
		}
		return res;
	}

	void DoReplace(GameObject Fb,GameObject Sb){
		Sb.transform.position = new Vector3 (Fb.transform.position.x, Fb.transform.position.y, Sb.transform.position.z);
	}

	public bool chk_isMaxheap_balloon ()
	{
		//get the num of balloon that have a orange on surface
		//and is maxheap
		int numOfobj = get_cur_num_balloon ();
		int numOfmax = 0;
		bool res = false;
		foreach (GameObject obj in heap_balloon) {
			if (obj.GetComponent <heap_balloon> ()._isCurNull == false) {
				if (obj.GetComponent <heap_balloon> ()._isMaxheap)
					numOfmax++;
			}
		}
//		Debug.Log (numOfobj+"  "+numOfmax);
		if (numOfobj == numOfmax) {
			res = true;
		}
		return res;
	}

	int get_cur_num_balloon ()
	{
		//get the num of balloon that have a orange on surface
		int numOfobj = 0;
		foreach (GameObject obj in heap_balloon) {
			if (obj.GetComponent <heap_balloon> ()._isCurNull == false) {
				numOfobj++;
			}
		}

		return numOfobj;
	}

	void setOrangeTomove ()
	{
		isOrangeMoving = true;
	}

	bool moveToObjReplace (string tagName)
	{
		bool isMoveDone = false;
		float step = 2 * Time.deltaTime;
		Vector3 sTarget = Vector3.zero;

		if (_heapSortReverseMode == 1) {
			sTarget = new Vector3 (heap_balloon [IncreaseNum].transform.position.x,
				heap_balloon [IncreaseNum].transform.position.y,
				clickObj.transform.position.z);
		} else {
			sTarget = new Vector3 (trays [IncreaseNum].transform.position.x,
				trays [IncreaseNum].transform.position.y,
				clickObj.transform.position.z);
		}

		clickObj.transform.position = Vector3.MoveTowards (clickObj.transform.position, sTarget, step * 10f);

//		StartCoroutine (setCollideDelay ());
		clickObj.GetComponent <BoxCollider2D> ().enabled = false;
		if (clickObj.transform.position == sTarget) {
			clickObj.GetComponent <BoxCollider2D> ().enabled = true;
			moveToabit (clickObj.gameObject);
			clickObj.transform.tag = tagName;
			isMoveDone = true;
		}
		return isMoveDone;
	}

	IEnumerator setCollideDelay(){
		yield return new WaitForSeconds (0.1f);
		clickObj.GetComponent <BoxCollider2D> ().enabled = false;
	}

	bool moveToObjReplace2 (string tagName,Transform thatObj)
	{
		bool isMoveDone = false;
		float step = 2 * Time.deltaTime;
		Vector3 sTarget = Vector3.zero;

		sTarget = new Vector3 (heap_balloon [oranges.Length - IncreaseNum].transform.position.x,
			heap_balloon [oranges.Length - IncreaseNum].transform.position.y,
			thatObj.transform.position.z);


		thatObj.transform.position = Vector3.MoveTowards (thatObj.transform.position, sTarget, step * 10f);
		thatObj.GetComponent <BoxCollider2D> ().enabled = false;
		if (thatObj.transform.position == sTarget) {
			thatObj.GetComponent <BoxCollider2D> ().enabled = true;
			thatObj.transform.tag = tagName;
			isMoveDone = true;
		}
		return isMoveDone;
	}


	void moveToabit (GameObject objTomove)
	{
		objTomove.transform.position = new Vector3 (objTomove.transform.position.x + 0.1f, objTomove.transform.position.y, objTomove.transform.position.z);
		objTomove.transform.position = new Vector3 (objTomove.transform.position.x - 0.1f, objTomove.transform.position.y, objTomove.transform.position.z);
//		Debug.Log ("move move move");
		isMaxHeapOnce = !isMaxHeapOnce;
	}


}
