using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement; //for loadscene

public class MainHouse : MonoBehaviour
{
	public GameObject obj;
	public string sceneName;
	public LoadScene load;
	public Canvas ScoreCanvas;
	// Use this for initialization
	void Start ()
	{
//		Debug.Log ("STARTTTTTTTTTTT");

	}

	//ใช้เมื่อเป็น collider -> add component collider ก่อน เพื่อตรวจสอบการชน
	void OnMouseOver ()
	{
		GetComponent<Animator> ().SetBool ("IsHover", true);
	}
	//mouse เลื่อนออก
	void OnMouseExit ()
	{
		GetComponent<Animator> ().SetBool ("IsHover", false);
	}

	void OnMouseDown ()
	{
		load.ToScene (sceneName);

	}

	void Update ()
	{

		//for each gameobject with collide -> not allow to click
		if (ScoreCanvas.isActiveAndEnabled) {
			gameObject.GetComponent<Collider2D> ().enabled = false;
		} else {
			gameObject.GetComponent<Collider2D> ().enabled = true;
		}
	}
}

