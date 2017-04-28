using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class numberRandom : MonoBehaviour
{

	//drag to here to operate
	public Text[] txt;
	//max number of random
	public int maxNumber;
	//store the unique number
	private List<int> uniqueNumbers;


	void Start ()
	{
		uniqueNumbers = new List<int>();
		if (maxNumber > 0) {
			GenerateRandomList ();
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void GenerateRandomList(){
		for(int i = 1; i <= maxNumber; i++)
		{
			uniqueNumbers.Add(i);
		}

		for(int i = 1; i<= maxNumber; i ++)
		{
			//random from List to variable
			//assign to Text
			//then Remove from List -> loop -> not duplicate anymore !!!
			int ranNum = uniqueNumbers[Random.Range(0,uniqueNumbers.Count)];
			txt [i - 1].text = ranNum.ToString ();
			uniqueNumbers.Remove (ranNum);
//			Debug.Log (txt [i - 1].text);

		}
	}
}
