using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class queueTutorial : MonoBehaviour {
	public TextAsset TextFile;
	public Text TextObj;
	string[] tLine;

	public static int qCounter;
	public static bool qCounter1,qCounter2,qCounter3,qCounter4;

	public GameObject[] arrow;
	public GameObject[] dragdroptSprite;
	// Use this for initialization
	void Start () {
		qCounter1 = false;
		qCounter2 = false;
		qCounter3 = false;
		qCounter4 = false;
		qCounter = 0;

		if (TextFile != null) {
			tLine = (TextFile.text.Split('\n'));
			TextObj.text = tLine [0];

			setFalse ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (qCounter == 0) {
			
		}
		else if(qCounter == 1){
			arrow [0].SetActive (true);
			dragdroptSprite[0].SetActive (true);
			changeText (1);

		}else if(qCounter == 2){
			setFalse ();
			arrow [1].SetActive (true);
			changeText (2);
			Invoke ("changeLast", 5f);
		}else if(qCounter == 3){
			setFalse ();
		}
	}

	void changeText(int a)
	{
		TextObj.text = tLine [a];
	}

	void changeLast()
	{
		changeText (3);
		qCounter++;
	}

	void setFalse()
	{
		foreach (GameObject arr in arrow) {
			arr.SetActive (false);
		}
		foreach (GameObject arr in dragdroptSprite) {
			arr.SetActive (false);
		}
	}
}
