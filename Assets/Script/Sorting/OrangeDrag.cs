using UnityEngine;
using System.Collections;

public class OrangeDrag : MonoBehaviour {
	public bool isEnableToDrag,clickedOn;


	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
	}

	// Update is called once per frame
	void Update () {
//		if (!isEnableToDrag) {
//			return;}
		//when we still not click then we can do dragging -> if we dragging = false = no more dragging
		if (clickedOn)
			Dragging ();
	}

	void Dragging(){
//		Debug.Log ("Dragging");
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.z = -3;
		transform.position = mousePos;
	}

	void OnMouseDown ()
	{
//		if (!isEnableToDrag) {
//			return;}
		clickedOn = true;
	}

	void OnMouseUp ()
	{
//		if (!isEnableToDrag) {
//			return;}
		clickedOn = false;
	}


	void OnMouseDrag()
	{
//		Debug.Log ("Dragging");
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mousePos.z = -3;
		transform.position = mousePos;
	}

}
