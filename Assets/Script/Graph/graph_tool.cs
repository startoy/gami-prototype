using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class graph_tool : MonoBehaviour
{
	public GameObject ArrowPrefab;
	public Transform firstNode, secondNode;
	public bool isdrawTool;
	public GameObject[] particleTool;
	Dictionary<int,int> firstNodeStore, secondNodeStore;
	public int[] faNode, saNode;
//	private int[,] answerNode;


	private int listIndex;
	// Use this for initialization
	void Start ()
	{
		// faNode saNode store real answer
		// firstNodeStore , second-- store temp answer we create
		firstNodeStore = new Dictionary<int,int> ();
		secondNodeStore = new Dictionary<int,int> ();
//		answerNode = new int[faNode.Length, saNode.Length];

	}

	// Update is called once per frame
	void Update ()
	{
//		Debug.Log ("list index " + listIndex);
//		Debug.Log (isdrawTool);
		if (isdrawTool) {
			drawInput ();
		} else {
			deleteArrowInput ();
		}

//		if (Input.GetKeyDown (KeyCode.C)) {
//			if (chkAnswer ()) {
//				Debug.Log ("corret!!");
//			} else {
//				Debug.Log ("incorrect !!");
//			}
//		}
	}

	void Awake ()
	{
		listIndex = 0;
		isdrawTool = true;
	}

	public bool checkBoolAnswer ()
	{
		//		Debug.Log ("firstNode = " + firstNodeStore.Count + "  faNode = " + faNode.Length);
		int count = 0;
		bool res = false;
		if (firstNodeStore != null && secondNodeStore != null && faNode != null && saNode != null) {
			for (int i = 0; i < faNode.Length; i++) {
				foreach (KeyValuePair<int,int> fns in firstNodeStore) {
					foreach (KeyValuePair<int,int> sns in secondNodeStore) {
						//					for (int i = 0; i < faNode.Length; i++) {

						if (fns.Key == sns.Key) {
							//							Debug.Log (fns.Key + " " + sns.Key + " " + i);
							//						Debug.Log (fns.Key + " < Key - Value fa > " + faNode[fns.Key]);
//							Debug.Log ("fns=" + fns + " sns=" + sns + " fanode"+i+"="+faNode[i] + " sanode"+i+"="+saNode[i]);
//							Debug.Log ("1cur counter = " + count);
							if (faNode [i] == fns.Value && saNode [i] == sns.Value) {
								count++;
//								Debug.Log ("2cur counter = " + count);
							}
						}
					}
				}
			}
			//			}

			if (count == faNode.Length) {
				
				if (firstNodeStore.Count > faNode.Length) {
					//if answer > real answer then false
					res = false;
				} else {
					res = true;
				}
			} 
		}

		return res;
	}

	void drawInput ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit && hit.transform.tag == "graph_node") {

				//make sure the object attached with "COLLIDER"
				if (!firstNode) {
					firstNode = hit.transform;
					firstNode.GetComponent <circle_graph> ().setT();

				} else if (firstNode != null) {
					secondNode = hit.transform;
					//					Debug.Log ("click 2 -->" + secondNode.GetComponent <circle_graph> ().nodeValue);
					if (secondNode == firstNode) {
						firstNode.GetComponent <circle_graph> ().setF();
						firstNode = null;
						secondNode = null;
					} else {
						bool isDup = false;
						secondNode.GetComponent <circle_graph> ().setT();
						int fValue = firstNode.GetComponent <circle_graph> ().nodeValue;
						int sValue = secondNode.GetComponent <circle_graph> ().nodeValue;

						//check if node is dup !
						//						firstNodeStore.GroupBy(n => n).Any(c => c.Count() > 1);
						//						Debug.Log ("2 clicks");
						if (firstNodeStore != null && secondNodeStore != null) {
//							Debug.Log ("firstnode secondnode is not null");
							//check dup
							for (int i = 0; i < firstNodeStore.Count; i++) {
								foreach (KeyValuePair<int,int> fns in firstNodeStore) {
									foreach (KeyValuePair<int,int> sns in secondNodeStore) {
										if (fns.Key == sns.Key) {
											if (fValue == fns.Value && sValue == sns.Value) {
												isDup = true;
												break;
											} else {
												//									Debug.Log ("no duplicate");
											}
										}
									}
								}

							}

							if (isDup) {
								//								Debug.Log ("is Dup");
								firstNode.GetComponent <circle_graph> ().setF();
								secondNode.GetComponent <circle_graph> ().setF();
								firstNode = null;
								secondNode = null;

							} else {
								firstNodeStore.Add (listIndex, fValue);
								secondNodeStore.Add (listIndex, sValue);
								instantArrow (listIndex);
								listIndex++;
								firstNode.GetComponent <circle_graph> ().setF();
								secondNode.GetComponent <circle_graph> ().setF();
								firstNode = null;
								secondNode = null;
								isDup = false;
							}
//							loopListAnswer ();
						} 
						//						else {
						//							Debug.Log ("else firstnode secondnode is null");
						//							//else if node store is NULL !! -> add to List (first time)
						//							firstNodeStore.Add (listIndex, fValue);
						//							secondNodeStore.Add (listIndex, sValue);
						//							listIndex++;
						//						}
					}
					//beware of the position GLOBAL or LOCAL !!
				}

				// ### END HIT ###
			} 
		}
		// END checkInput



		//		if (Input.GetKeyDown (KeyCode.X)) {
		//			firstNode.GetComponent <arrow_script> ().destroyArrow ();
		//		}
	}

	void deleteArrowInput ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit && hit.transform.tag == "graph_arrow") {

				//make sure the object attached with "COLLIDER"
				if (!firstNode) {
					firstNode = hit.transform;
					int arrowIndex = firstNode.GetComponent <arrow_script> ().arrowNO;
//					Debug.Log ("delete arrowIndex = " + arrowIndex);
					firstNode.GetComponent <arrow_script> ().destroyArrow ();
					firstNode = null;
					firstNodeStore.Remove (arrowIndex);
					secondNodeStore.Remove (arrowIndex);

				}
			}
		}
		// END deleteArrowInput
	}

//	void loopListAnswer ()
//	{
//		if (firstNodeStore != null && secondNodeStore != null) {
//			for (int i = 0; i < firstNodeStore.Count; i++) {
//				foreach (KeyValuePair<int,int> fns in firstNodeStore) {
//					foreach (KeyValuePair<int,int> sns in secondNodeStore) {
//						if (fns.Key == sns.Key)
////							Debug.Log ("hi" + fns.Value + "," + sns.Value);
//
//					}
//				}
//
//			}
//		}
//	}



	//	public void switchToolMode ()
	//	{
	//		isdrawTool = !isdrawTool;
	//	}

	public void switchDrawMode ()
	{
		isdrawTool = true;
		particleTool [0].SetActive (true);
		particleTool [1].SetActive (false);
	}

	public void switchDeleteMode ()
	{
		isdrawTool = false;
		particleTool [1].SetActive (true);
		particleTool [0].SetActive (false);
	}



	void instantArrow (int arrowNO)
	{
		GameObject arrowPref = Instantiate (ArrowPrefab);
		arrowPref.transform.GetComponent <arrow_script> ().originTarget = firstNode.transform;
		arrowPref.transform.GetComponent <arrow_script> ().target = secondNode.transform;
		arrowPref.transform.GetComponent <arrow_script> ().arrowNO = arrowNO;
	}
	//	public bool MakePersonBar (Sprite PersonSprite)
	//	{
	//		string name = PersonSprite.name.ToString ();
	//		//if true
	//		bool chk = CheckIsTempEqual (name);
	//		if (chk) {
	//			Image newPersonBar = Instantiate (_imgPrefab);
	//			newPersonBar.transform.SetParent(this.transform, true);
	//			newPersonBar.sprite = PersonSprite;
	//
	//			//ใช้ localposition เพราะอ้างอิงจากตัว parent
	//			newPersonBar.GetComponent<RectTransform> ().localPosition = new Vector3 (xpos, -20f, 0f);
	//			xpos += 70f;
	//		}
	//		//		Debug.Log ("STK : " + name);
	//		return chk;
	//	}

	//	public bool CheckIsTempEqual (string name)
	//	{
	//		UserAnswerInorder.Add (name);
	//		//		Debug.Log ("Adding " + name);
	//		string[] userAnswer = UserAnswerInorder.ToArray ();
	//		string[] Answer = busM.answer;
	//		int i = ListCount;
	//		bool res = false;
	//		if (userAnswer [i] == Answer [i]) {
	//			ScoreTemp += 10;
	//			ListCount++;
	//			res = true;
	//		} else {
	//			UserAnswerInorder.Remove (name);
	//			//			Debug.Log ("Losing " + name);
	//			heartObj.LosingHeart ();
	//		}
	//		return res;
	//	}

	//	void createDictionary()
	//	{
	//		//using GENERIC
	//		// Populate example Dictionary.
	//		var dict = new Dictionary<int, bool>();
	//		dict.Add(3, true);
	//		dict.Add(5, false);
	//
	//		// Get a List of all the Keys.
	//		List<int> keys = new List<int>(dict.Keys);
	//		foreach (int key in keys)
	//		{
	//			Debug.Log (key);
	//		}
	//	}
	// END #CLASS

}
