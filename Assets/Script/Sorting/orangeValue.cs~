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
	public bool ismoveLR;
	public bool ismoveUP;
	public bool ismoveDown;
	public Vector3 curPos = Vector3.zero;
	public Vector3 nextPos = Vector3.zero;
	public bool ChainMove,finishChain;
	bool upFinish = false, RightFinish = false, DownFinish = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (ismoveUP) {
			moveUP (curPos);
		} else if (ismoveDown) {
			moveDown (curPos);
		} else if (ismoveToRight) {
			moveToRight (curPos);
		} else if (ismoveToLeft) {
			moveToLeft (curPos);
		} else if (ismoveLR) {
			moveLR (curPos);
		} 

		//for chain move
		if(ChainMove){
			//finishChain = false;
			fchain(nextPos);
		}
	}

	void Awake ()
	{
		ismoveToRight = false;
		ismoveToLeft = false;
		ismoveLR = false;
		ismoveUP = false;
		ismoveDown = false;

		ChainMove = false;
		finishChain = false;
	}

//	void setToundetec(){
//		this.GetComponent <R>().ena;
//	}

	void fchain(Vector3 Pos)
	{
//		bool result = false;
		float step = stepSpd * Time.deltaTime;

		//UP
		if (!upFinish) {
			Vector3 sTarget = new Vector3 (this.transform.position.x, Pos.y + 2.2f, this.transform.position.z);
			this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 6f);
			if (this.transform.position == sTarget) {
				upFinish = true;
			}
		}
		if (!RightFinish && upFinish) {
			Vector3 sTarget = new Vector3 (Pos.x, this.transform.position.y, this.transform.position.z);
			this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 6f);
			if (this.transform.position == sTarget) {
				RightFinish = true;
			}
		}
		if (!DownFinish && RightFinish && upFinish) {
			
			Vector3 sTarget = new Vector3 (this.transform.position.x, Pos.y, this.transform.position.z);
			this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 6f);
			if (this.transform.position == sTarget) {
				ChainMove = false;
				DownFinish = false;
				RightFinish = false;
				upFinish = false;
				finishChain = true;
//					result = true;
			}
		}
//				return result;
	}

	/*	
	 *  USE WITH THIS FUNCTION
	 * 
	void swapOrangePos(int left,int right)
	{
		Vector3 LPosTemp = oranges [left].transform.position;
		oranges [left].GetComponent <orangeValue> ().nextPos = oranges [right].transform.position;
		oranges [left].GetComponent <orangeValue> ().chainRight = true;
		oranges [right].GetComponent <orangeValue> ().nextPos = LPosTemp;
		oranges [right].GetComponent <orangeValue> ().chainLeft = true;
	}
	*
	*/
	public int OnMouseDown(){
		// this object was clicked - do something
		return 55555;
	}   


	public void moveLR (Vector3 curPos)
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (curPos.x, curPos.y, curPos.z);
		//move it move it
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 6f);

		if (this.transform.position == sTarget) {
			//			isMoveRightDone = true;
//			Debug.Log ("moveLR");
			ismoveLR = false;
		}
	}

	public void moveUP (Vector3 curPos)
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (curPos.x, curPos.y + 2.2f, curPos.z);
		//move it move it
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 5f);

		if (this.transform.position == sTarget) {
			//			isMoveRightDone = true;
//			Debug.Log ("moveUP");
			ismoveUP = false;
		}
	}

	public void moveDown (Vector3 curPos)
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (curPos.x, curPos.y - 2.2f, curPos.z);
		//move it move it
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 5f);

		if (this.transform.position == sTarget) {
			//			isMoveRightDone = true;
//			Debug.Log ("moveUP");
			ismoveDown = false;
		}
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
//			Debug.Log ("ismoveRight TRUE");
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
//			Debug.Log ("ismoveLeft TRUE");
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
