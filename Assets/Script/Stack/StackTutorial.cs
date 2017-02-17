using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StackTutorial : MonoBehaviour {
	public TextAsset TextFile;
	public Text TextObj;
	public GameObject[] arrow;
	public GameObject[] dragdroptSprite;
	string[] tLine;
	int counter;

	// Use this for initialization
	void Start () {
		if (TextFile != null) {
			tLine = (TextFile.text.Split('\n'));
			TextObj.text = tLine [0];
			//			Debug.Log (Input.GetAxis ("Horizontal"));
			foreach (GameObject arr in arrow) {
				arr.SetActive (false);
			}
			foreach (GameObject arr in dragdroptSprite) {
				arr.SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//input all time
		counter = boxGroupControl.boxCount;
		if (counter == 6) {
			dragdroptSprite [0].SetActive (true);
			if (Input.GetMouseButtonDown (0)) {
				Invoke ("ink1", 1f);
			}

		} else if (counter == 5) {
			changeText (2);
			arrow[0].SetActive(false);
			arrow[1].SetActive(true);
			arrow[2].SetActive(true);

			dragdroptSprite [0].SetActive (false);
			dragdroptSprite [1].SetActive (true);
			dragdroptSprite [2].SetActive (false);

		} else if (counter == 4) {
			changeText (3);
			arrow[0].SetActive(true);
			arrow[1].SetActive(false);
			arrow[2].SetActive(false);

			dragdroptSprite [0].SetActive (false);
			dragdroptSprite [1].SetActive (false);
			dragdroptSprite [2].SetActive (true);
		} else if (counter == 3) {
			TextObj.text = "";
			foreach (GameObject arr in arrow) {
				arr.SetActive (false);
			}
			foreach (GameObject arr in dragdroptSprite) {
				arr.SetActive (false);
			}
		}
			
	}

	void changeText(int a)
	{
		TextObj.text = tLine [a];
	}

	void ink1()
	{
		changeText (1);
		arrow[0].SetActive(true);

	}

}
