using UnityEngine;
using System.Collections;

public class tray_script : MonoBehaviour
{

	public bool isSorted = false;
	public int firstSort;


	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
//		insertion_controller.curInsertionSortedVal;

	}

	void Awake ()
	{
		
	}

	void chkChangeColor (byte c1,byte c2,byte c3,byte c4)
	{
		this.GetComponent <SpriteRenderer> ().color = new Color32 (c1, c2, c3, c4);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Debug.Log ("ENTER TRIGGER");
		if (col.tag == "sorted") {
			chkChangeColor (40, 255, 0, 255); //สีเขียว
		}else if(col.tag == "onsort"){
			//chkChangeColor (255, 39, 24, 255); //สีแดง
			chkChangeColor (255, 248, 0, 255); //สีเหลือง
		}else if(col.tag=="unsort"){
			chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		Debug.Log ("EXIT TRIGGER");
		if (col.tag == "sorted") {
			chkChangeColor (40, 255, 0, 255); //สีเขียว
		}else if(col.tag == "onsort"){
			//chkChangeColor (255, 39, 24, 255); //สีแดง
			chkChangeColor (255, 248, 0, 255); //สีเหลือง
		}else if(col.tag=="unsort"){
			chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		Debug.Log ("STAY TRIGGER");
		if (col.tag == "sorted") {
			chkChangeColor (40, 255, 0, 255); //สีเขียว
		}else if(col.tag == "onsort"){
			//chkChangeColor (255, 39, 24, 255); //สีแดง
			chkChangeColor (255, 248, 0, 255); //สีเหลือง
		}else if(col.tag=="unsort"){
			chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
		}
	}
}
