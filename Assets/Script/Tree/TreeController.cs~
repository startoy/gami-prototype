using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour
{
	public Transform firstNode, secondNode;
	private Vector3 Fnode, Snode;
	public float stepSpd = 2f;
	bool isObjMove = false, isMoveToanswer = false, isMoving = false;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		

		if (isMoving) {
			if (firstNode != null && secondNode != null) {
				if (isObjMove) {
					moveToObjSwitch ();
				} else if (isMoveToanswer) {
					moveToObjReplace ();
				}
			}
		} else {
			inputClickNode ();
		}
	}

	void inputClickNode ()
	{
		if (Input.GetMouseButtonDown (0)) {
			Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
			if (hit) {
				if (!firstNode) {
					firstNode = hit.transform;
					if (firstNode.transform.tag == "Node") {
						Fnode = firstNode.transform.position;
					} else {
						firstNode = null;
					}
				} else if (firstNode != null) {
					secondNode = hit.transform;
					Snode = secondNode.transform.position;
					if (secondNode == firstNode) {
						firstNode = null;
						secondNode = null;
					} else {
						//ถ้ากดครั้งที่สองเป็นชนิดโหนดคำตอบ ให้เลื่อนสลับกัน
						if (secondNode.transform.tag == "Node") {
							isMoving = true;
							isObjMove = true;
							//ถ้ากดครั้งที่สองเป็นชนิดโหนดเปล่าสีขาว ให้เลื่อนไปทัีบ
						} else if (secondNode.transform.tag == "answerNode") {
							isMoving = true;
							isMoveToanswer = true;
						} else {
							secondNode = null;
						}
					}
				}
			}
		}
	}

	void moveToObjSwitch ()
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (Snode.x, Snode.y, Snode.z);

		firstNode.transform.position = Vector3.MoveTowards (firstNode.transform.position, sTarget, step * 10f);
		secondNode.transform.position = Vector3.MoveTowards (secondNode.transform.position, fTarget, step * 10f);

		if (firstNode.transform.position == sTarget && secondNode.transform.position == fTarget) {
			isObjMove = false;
			isMoving = false;

			firstNode = null;
			secondNode = null;
		}
	}

	void moveToObjReplace ()
	{
		//second switch 2 object
		float step = stepSpd * Time.deltaTime;
		//get from previous move
//		Vector3 fTarget = new Vector3 (Fnode.x, Fnode.y, Fnode.z);
		Vector3 sTarget = new Vector3 (Snode.x, Snode.y, firstNode.transform.position.z);

		firstNode.transform.position = Vector3.MoveTowards (firstNode.transform.position, sTarget, step * 10f);

		if (firstNode.transform.position == sTarget) {
			isMoveToanswer = false;
			isMoving = false;

			firstNode = null;
			secondNode = null;
		}
	}
		
}
