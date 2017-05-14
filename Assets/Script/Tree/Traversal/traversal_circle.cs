using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class traversal_circle : MonoBehaviour
{
	//check if we currently entering radius area -> trigger
	public bool EnterTriggerCheck = false;
	//if people hop in use this sprite
	public Sprite SpriteWhenDone;
	//don't use STATIC !! each radius will be the same PickedUp
	public bool PickedUp = false;
	//to get the parent of Radius Animator
	Animator parent;
	//temp for recieve person sprite
	Sprite _PersonTemp;
	//get from class StackingOrder in Array (gameObj) to use FUNCTION
	public StackingOrder stk;



	void Start ()
	{
		//to get the parent of Radius Animator
		parent = gameObject.GetComponentInParent<Animator> ();
	}

	void Update ()
	{
		
		//จาก Trigger ถ้ามันเข้าในเขตจริง ถึงจะเข้าไปกดสเปชบาร์ได้
		if (EnterTriggerCheck) {
			//ถ้ากดสเปชบาร์
			if (Input.GetKeyDown (KeyCode.Space)) {
//				Debug.Log ("Player press SPACE");
				//ถ้ายังไม่เคยกดรับผู้โดยสาร | if never pick up then pick up
				if (!PickedUp) {
					//แสดงว่าจะกดรับผู้โดยสารคนนี้

					//มาเก็บภาพ sprite ปัจจุบันไว้
					_PersonTemp = gameObject.GetComponentInParent<SpriteRenderer> ().sprite;
					//เรียกใช้คลาส stackingOrder เรียกฟังก์ชัน ส่งค่า boolean กลับมา ถ้ามันตรงกับคำตอบที่ปัจจุบัน
					PickedUp = stk.MakePersonBar (_PersonTemp);

					//ถ้าเป็นคำตอบที่ถูกต้อง แสดงว่ารับผู้โดยสารคนนี้แล้ว
					if (PickedUp) {
						//Change person sprite to correct sprite เปลี่ยนภาพ sprite เป็นภาพจาก whendone
						gameObject.GetComponentInParent<SpriteRenderer> ().sprite = SpriteWhenDone;
						//เรียกใช้ฟังก์ชัน playAnimFalse , หน่วงเวลา 0.5วิ
						Invoke ("playAnimFalse", 0.5f);
					}
				}
			}
		}


	}

	void OnTriggerEnter2D (Collider2D bus)
	{
		//เช็ค tag ของวัตถุที่มาชนก่อน ถ้า tag เป็น player
		if (bus.tag == "Player") {
			//ใช้กับอัพเดท ถ้าเข้ามาแล้วให้กดสเปชบาร์ได้
			EnterTriggerCheck = true; 
			//ถ้าเกิดยังไม่เคยรับคนนี้ ให้เคลื่อนไหว ดึ๋งๆ - false
			if (!PickedUp) {
				parent.SetBool ("onBusHover", true);
			}
		}
			
	}

	void OnTriggerExit2D (Collider2D bus)
	{
		if (bus.tag == "Player") {
			EnterTriggerCheck = false;
			parent.SetBool ("onBusHover", false);
		}
//		gameObject.GetComponent<Animator> ().SetBool ("IsEnterCircle", false);
	}

	void playAnimFalse ()
	{
		//เปลี่ยน พารามิเตอร์ของ animator ของคนนี้ เป็น false ทำให้เปลี่ยนไปเล่นท่าอื่น
		parent.SetBool ("onBusHover", false);
	}
		
}