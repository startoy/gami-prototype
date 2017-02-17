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

	void chkChangeColor ()
	{
		this.GetComponent <SpriteRenderer> ().color = new Color32 (40, 255, 0, 255);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "sorted") {
			chkChangeColor ();
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		
	}

	void OnTriggerStay2D(Collider2D col)
	{
		
	}
}
