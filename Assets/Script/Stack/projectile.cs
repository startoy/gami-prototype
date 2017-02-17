﻿using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour
{

	public float maxStretch = 3.0f;
	public LineRenderer catapultLine;
	public bool isEnableToDrag;

	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private float maxStretchSqr;
		
	private bool clickedOn;
	private Vector2 prevVelocity;



	void Awake ()
	{
		//รับคอมโพเนนท์จากออบเจ็คที่ถือสคริปนี้มาเก็บ spring
		spring = gameObject.GetComponent <SpringJoint2D> ();
		//ตัวแปร Transform เก็บตัวที่สปริงต่ออยู่ ในที่นี้คือจุดศูนย์กลางหมุนของมัน -> centerRigid
		catapult = spring.connectedBody.transform;
	}

	void Start ()
	{
		isEnableToDrag = false;



		//create ray to origin to direction == origin -> at the catapult == direct 0,0,0 temporaly
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		//create ray == origin -> at the left catapuly == direction 0,0,0 temp
		maxStretchSqr = maxStretch * maxStretch;

//		catapultLine.sortingLayerName = "Forground";
//		catapultLine.sortingOrder = 3;
		catapultLine.enabled = false;
		catapultLine.SetWidth (0.025f,0.125f);

	}

	void Update ()
	{
//		RaycastHit2D hit = Physics2D.Raycast
//		Debug.DrawLine (transform.position,catapult.position);

		if (!isEnableToDrag) {
			return;}
		//when we still not click then we can do dragging -> if we dragging = false = no more dragging
		if (clickedOn)
			Dragging ();
		//spring not null
		if (spring != null) {
			if (!gameObject.GetComponent<Rigidbody2D> ().isKinematic && prevVelocity.sqrMagnitude > gameObject.GetComponent<Rigidbody2D> ().velocity.sqrMagnitude) {
				Destroy (spring);
				gameObject.GetComponent<Rigidbody2D> ().velocity = prevVelocity; 
			}

			if (!clickedOn)
				//store the max velocity when mouseUp -> use to assign when destroy spring
				//because when spring destroyed the obj will not launch, drop instead
				prevVelocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
			
			LineSetup ();

		} else {
				
		}
	}


	void OnMouseDown ()
	{
		if (!isEnableToDrag) {
			return;}
		spring.enabled = false;
		catapultLine.enabled = true;
		clickedOn = true;
	}

	void OnMouseUp ()
	{
		if (!isEnableToDrag) {
			return;}
		//boxCount use to check if is box in stack or not -> show gameOverCanvas
		boxGroupControl.boxCount -= 1;
		spring.enabled = true;
		catapultLine.enabled = false;
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = false; //to trigger condition in update
		clickedOn = false;
	}

	void Dragging ()
	{
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;

		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint (maxStretch);
		}

		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;


	}

	void LineSetup()
	{
		
		catapultLine.SetPosition (0, catapult.position);
		catapultLine.SetPosition (1, transform.position);

	}
		
		
}
