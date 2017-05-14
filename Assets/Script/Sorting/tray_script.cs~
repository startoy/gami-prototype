using UnityEngine;
using System.Collections;

public class tray_script : MonoBehaviour
{

	public bool isSorted = false;
	public Transform colTemp;
	public bool isForHeapSort = false;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update ()
	{
		if (colTemp != null && !isForHeapSort)
		{
//			print (colTemp.name);

			if (colTemp.tag == "sorted") {
				chkChangeColor (40, 255, 0, 255); //สีเขียว
			}else if(colTemp.tag == "onsort"){
				//chkChangeColor (255, 39, 24, 255); //สีแดง
				chkChangeColor (255, 248, 0, 255); //สีเหลือง
			}else if(colTemp.tag=="unsort"){
				chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
			}else if(colTemp.tag=="pairsort"){
				chkChangeColor (75, 106, 255, 255); //สีน้ำเงิน
			}
		}

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
		
//		if (col.GetComponent <orangeValue> () != null && !col.GetComponent <orangeValue> ().isStop ())
//			return;
//
//		Debug.Log ("ENTER TRIGGER");
		if (col.tag == "sorted") {
			chkChangeColor (40, 255, 0, 255); //สีเขียว
		}else if(col.tag == "onsort"){
			//chkChangeColor (255, 39, 24, 255); //สีแดง
			chkChangeColor (255, 248, 0, 255); //สีเหลือง
		}else if(col.tag=="unsort"){
			chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
		}else if(col.tag=="pairsort"){
			chkChangeColor (75, 106, 255, 255); //สีน้ำเงิน
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		
		if (colTemp != null) {
			colTemp = null;
		}
		
//		Debug.Log ("EXIT TRIGGER");
		if (col.tag == "sorted") {
			chkChangeColor (40, 255, 0, 255); //สีเขียว
		}else if(col.tag == "onsort"){
			//chkChangeColor (255, 39, 24, 255); //สีแดง
			chkChangeColor (255, 248, 0, 255); //สีเหลือง
		}else if(col.tag=="unsort"){
			chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
		}else if(col.tag=="pairsort"){
			chkChangeColor (75, 106, 255, 255); //สีน้ำเงิน
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		colTemp = col.transform;
//		if (col.GetComponent <orangeValue> () != null && !col.GetComponent <orangeValue> ().isStop ())
//			return;
//
//		Debug.Log ("STAY TRIGGER");
//		print (this.name);
		if (col.tag == "sorted") {
			chkChangeColor (40, 255, 0, 255); //สีเขียว
		}else if(col.tag == "onsort"){
			//chkChangeColor (255, 39, 24, 255); //สีแดง
			chkChangeColor (255, 248, 0, 255); //สีเหลือง
		}else if(col.tag=="unsort"){
			chkChangeColor (255, 255, 255, 255); //สีขาวตามสไปร์
		}else if(col.tag=="pairsort"){
			chkChangeColor (75, 106, 255, 255); //สีน้ำเงิน
		}
	}
}
