using UnityEngine;
using System.Collections;

public class heap_index : MonoBehaviour {

	/* 
	 *  เอาไว้เลื่อนตัวชี้ไปตามออบเจคบนถาด	
		วิธีใช้
		-เพิ่มสคริปนี้เข้าไป
		-ถ้าจะสั่งให้ตัวชี้ที่มีสคริปนี้เลื่อนไปหาตัวไหน
		ให้ใช้ฟังก์ชัน moveToObj(ออบเจ็คที่จะไป)
	*/

	public bool heap_index_moving;
	bool isGoIndex;
	GameObject objTogo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(isGoIndex==true){
			moveIndexToObj (objTogo);
		}
	}

	void moveIndexToObj(GameObject otherPos){
		float step = 2 * Time.deltaTime;
		Vector3 sTarget = new Vector3 (otherPos.transform.position.x, -1.25f, this.transform.position.z);
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 4f);
		if (this.transform.position == sTarget) {
			isGoIndex = false;
			heap_index_moving = false;
		}
	}

	public void moveToObj(GameObject obj){
		objTogo = obj;
		isGoIndex = true;
		heap_index_moving = true;
	}

	public void changeIndexColor(string color){
		switch (color) {
		case "normal":
			changeSpriteColor (255, 255, 255, 255);
			break;
		case "red":
			changeSpriteColor (255, 39, 24, 255);
			break;
		case "green":
			changeSpriteColor (40, 255, 0, 255);
			break;
		case "blue":
			changeSpriteColor (0, 86, 255, 255);
			break;
		}
	}

	void changeSpriteColor (byte c1,byte c2,byte c3,byte c4)
	{
		this.GetComponent <SpriteRenderer> ().color = new Color32 (c1, c2, c3, c4);
	}
}
