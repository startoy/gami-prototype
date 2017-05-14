using UnityEngine;
using System.Collections;

public class TreeNodeanswer : MonoBehaviour
{
	public string NodeAnswer;
	public int count;
	private string NodeColliderAnswer;
	private bool NodeLock = false;
	// Use this for initialization
	void Start ()
	{
	
	}

	void Awake ()
	{
		NodeLock = false;
	}
	// Update is called once per frame
	void Update ()
	{
	
	}

	//attach this obj with Rigidbody2D to use collide
	void OnTriggerEnter2D (Collider2D col)
	{
//		StartCoroutine (IEDelay (4f, col.transform, 1));
		NodeColliderAnswer = col.transform.GetComponent <Node> ().nodeValue;
		if (NodeColliderAnswer == NodeAnswer) {
			count = 1;
		}
	}



	void OnTriggerExit2D (Collider2D col)
	{
		NodeColliderAnswer = col.transform.GetComponent <Node> ().nodeValue;
		if (NodeColliderAnswer == NodeAnswer) {
			count = 0;
		}
	}

	IEnumerator IEDelay (float second, Transform col, int mode)
	{
		yield return new WaitForSeconds (second);
		if (mode == 1) {
			NodeColliderAnswer = col.transform.GetComponent <Node> ().nodeValue;
			Debug.Log ("Node Answer = " + NodeAnswer + "Collision Answer = " + NodeColliderAnswer);
			count = 1;
			NodeLock = true;
		} else {
			NodeColliderAnswer = "";
			count = 0;
		}
	}
}
