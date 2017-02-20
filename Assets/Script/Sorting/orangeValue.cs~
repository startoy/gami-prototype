using UnityEngine;
using System.Collections;

public class orangeValue : MonoBehaviour
{
	public int value;
	public int switchValue;
	public int swapNum = 0;
	float stepSpd = 2f;
	public bool ismoveToRight;
	public bool ismoveToLeft;
	public Vector3 curPos = Vector3.zero;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ismoveToRight) {
			moveToRight (curPos);
		} else if (ismoveToLeft) {
			moveToLeft (curPos);
		}
	}

	void Awake ()
	{
		ismoveToRight = false;
		ismoveToLeft = false;

	}

	public void moveToRight (Vector3 curPos)
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (curPos.x + 2.2f, curPos.y, curPos.z);
		//move it move it
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 3f);

		if (this.transform.position == sTarget) {
//			isMoveRightDone = true;
			Debug.Log ("ismoveRight TRUE");
			ismoveToRight = false;
		}
	}

	public void moveToLeft (Vector3 curPos)
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (curPos.x - 2.2f, curPos.y, curPos.z);
		//move it move it
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 3f);

		if (this.transform.position == sTarget) {
			//			isMoveRightDone = true;
			Debug.Log ("ismoveLeft TRUE");
			ismoveToLeft = false;
		}
	}

	//	public void moveToLR(Vector3 curPos,float fPlus)
	//	{
	//		//second switch 2 object
	//		float step = stepSpd * Time.deltaTime;
	//		//get from previous move
	//		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
	//		Vector3 sTarget = new Vector3 (curPos.x + fPlus, curPos.y, curPos.z);
	//		//move it move it
	//		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 3f);
	//
	//		if (this.transform.position == sTarget) {
	//			//			isMoveRightDone = true;
	//			Debug.Log ("isMoveRightDone TRUE");
	//			ismoveToRight = false;
	//		}
	//	}


}
