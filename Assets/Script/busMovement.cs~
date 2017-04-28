using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class busMovement : MonoBehaviour
{
	//controll speed
	public string LevelScoreName;
	public float maxspeed;
	public float rotationSpeed;
	int ListCountPerson;
	static public bool _GameOver;
	public string[] answer;

	public bubble_ui bui;

	// Use this for initialization
	void Start ()
	{
		_GameOver = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!_GameOver) {
			BusMove ();
		} 
	}

	void BusMove ()
	{
		//Rotate the bus left right
		Quaternion rot = transform.rotation;
		float z = rot.eulerAngles.z; //grab z euler angle
		z -= Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime;
		rot = Quaternion.Euler (0, 0, z); //recreate the quaternion
		transform.rotation = rot; //apply to object bus

		Vector3 pos = new Vector3 (0, Input.GetAxis ("Vertical") * maxspeed * Time.deltaTime, 0);
		transform.Translate (pos);
	}

	void Update ()
	{

		ListCountPerson = StackingOrder.ListCount;
		if (_GameOver || ListCountPerson >= answer.Length || bui.isGameUIOver) {
			bui.isGameUIOver = true;
			_GameOver = true;

		}
	}



}
