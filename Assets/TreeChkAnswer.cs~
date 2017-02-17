using UnityEngine;
using System.Collections;

public class TreeChkAnswer : MonoBehaviour
{
	public GameObject[] ansNode;
	private int count = 0;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.C)) {
			if (chkBoolTreeAnswer ()) {
				Debug.Log ("CORRECT !!");
			}else{
				Debug.Log ("INCORRECT !!");
			}
		}
	}

	public bool chkBoolTreeAnswer ()
	{
		bool res;
		count = 0;
		foreach (GameObject node in ansNode) {
			if (node.transform.GetComponent <TreeNodeanswer> ().count == 1) {
				count++;
			}
		}
		Debug.Log ("Count correct =" + count);

		if (count == ansNode.Length) {
			res = true;

		} else {
			res = false;
		}
		return res;
	}
}
