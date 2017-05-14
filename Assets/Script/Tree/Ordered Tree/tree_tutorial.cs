using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tree_tutorial : MonoBehaviour {



	public TextAsset TextFile;
	public Text TextObj;
	public GameObject[] tap;
	public GameObject[] node;
	string[] tLine;
	int counter = 1;
	// Use this for initialization
	void Start ()
	{
		if (TextFile != null) {
			tLine = (TextFile.text.Split ('\n'));
			TextObj.text = tLine [0];
			//			Debug.Log (Input.GetAxis ("Horizontal"));
			setTapActiveOnce (999);
		}
		tap [0].SetActive (true);
	}

	void Awake ()
	{
		tap [0].SetActive (true);
		Invoke ("invk1", 4f);
	}

	// Update is called once per frame
	void Update ()
	{

		if (counter == 1) {

		} else if (counter == 2) {
			//ถ้าคลิกที่เครื่องมือแล้ว
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[0])
				{
					//เปลี่ยนคำ เป็น ให้สร้างเส้นเชื่อม 1-2 แทน 
//					changeText (2);
					setTapActiveOnce (2);
					counter = 3;
				}
			}
		} else if (counter == 3) {
			//ถ้าคลิกที่โหนด 1
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[1])
				{
					//เปลี่ยนเมาส์ให้เลือกที่โหนด 2
					changeText (2);
					setTapActiveOnce (3);
					counter = 4;
				}
			}

		} else if (counter == 4) {
			//ถ้าคลิกโหนดที่ 2
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[2])
				{
					setTapActiveOnce (4);
//					changeText (3);
					counter = 5;
				}
			}
		} else if (counter == 5) {
			//ถ้าคลิกโหนดที่ 1
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[3])
				{
					//เปลี่ยนเมาส์ให้เลือกโหนด 3
					changeText (3);
					setTapActiveOnce (5);
					counter = 6;
				}
			}
		} else if (counter == 6) {
			//ถ้าคลิกโหนดที่ 3
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[4])
				{
					//ให้เลือกเครื่องมือสร้างเส้นเชื่อม
					//เมาส์ไปชี้ที่เครื่องมือ ลบ เส้นเชื่อม
//					changeText (4);
					setTapActiveOnce (6);
					counter = 7;
				}
			}
		} else if (counter == 7) {
			//ถ้าคลิกเครื่องมือลบเส้นเชื่อม
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[5])
				{
					//ให้คลิกที่เส้นเชื่อมที่ขึ้นมา
					//แสดงข้อความ เลือกเส้นเชื่อมที่จะลบ
					changeText (4);
					setTapActiveOnce (999);
					counter = 8;
					Invoke ("ink2",6f);
				}
			}
		} else if (counter == 8) {
			//ถ้าคลิกเส้นเชื่อม
			if (Input.GetMouseButtonDown (0)) {
				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
				if(hit==node[6])
				{
										TextObj.text = "";
										setTapActiveOnce (999);
					counter = 9;
				}
			}
		} 
//		else if (counter == 9) {
//			//ถ้าคลิกเส้นเชื่อม
//			if (Input.GetMouseButtonDown (0)) {
//				Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
//				RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
//				if(hit==node[5])
//				{
//					TextObj.text = "";
//					setTapActiveOnce (999);
//					counter = 10;
//				}
//			}
//		} 
	}

	//	if (Input.GetMouseButtonDown (0)) {
	//		Vector2 ray = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	//		RaycastHit2D hit = Physics2D.Raycast (ray, Vector2.zero);
	//		if(hit)
	//		{
	//
	//		}
	//	}


	void invk1 ()
	{
		if (counter != 2) {
			changeText (1);
			setTapActiveOnce (1);
			counter = 2;
		}
	}

	void ink2()
	{
		TextObj.text = "";
		setTapActiveOnce (999);
	}


	void changeText (int a)
	{
		TextObj.text = tLine [a];
	}

	void setTapActiveOnce (int num)
	{
		//num 999 --> all tap FALSE
		if (num == 999) {
			foreach (GameObject arr in tap) {
				arr.SetActive (false);
			}
		} else { 
			//if num is any number --> show only one num
			foreach (GameObject arr in tap) {
				arr.SetActive (false);
			}
			tap [num].SetActive ((true));
		}

	}

}
