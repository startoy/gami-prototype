using UnityEngine;
using System.Collections;

public class heap_swap : MonoBehaviour {
	public GameObject Fb, Sb;
	public heap_controller heap_con;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		DoSwap ();
	}

	void DoSwap(){
		if (Fb  && Sb && Fb.GetComponent <heap_balloon> ()._CurSurface && Sb.GetComponent <heap_balloon> ()._CurSurface) {
			GameObject first = Fb.GetComponent <heap_balloon> ()._CurSurface;
			GameObject second = Sb.GetComponent <heap_balloon> ()._CurSurface;

			Vector3 temp = new Vector3 (first.transform.position.x, first.transform.position.y, first.transform.position.z);
			first.transform.position = new Vector3 (second.transform.position.x, second.transform.position.y, second.transform.position.z);
			second.transform.position = temp;
			StartCoroutine (moveDelay (first, second));
		}

	}

	IEnumerator moveDelay(GameObject first,GameObject second){
		yield return new WaitForSeconds (0.2f);
		moveToabit (first);
		moveToabit (second);
	}

	void moveToabit(GameObject objTomove)
	{
		objTomove.transform.position = new Vector3(objTomove.transform.position.x+0.1f, objTomove.transform.position.y, objTomove.transform.position.z);
		objTomove.transform.position = new Vector3(objTomove.transform.position.x-0.1f, objTomove.transform.position.y, objTomove.transform.position.z);
		//		Debug.Log ("move move move");
	}

	void chk_is_maxheap(){
		if(heap_con.chk_isMaxheap_balloon()){
			heap_con.isMaxHeapOnce = !heap_con.isMaxHeapOnce;
		}
	}
}
