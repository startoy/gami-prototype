using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnFruits : MonoBehaviour
{

	public GameObject[] objSpawn;
	Vector3 positionToSpawn = Vector3.zero;
	GameObject fruit;


	public StorageBox stbox;
	//	string[] FruitTags = new string[] { "BoxOrange", "BoxCarrot", "BoxPineapple", "BoxGrape", "BoxMango" };
	string[] fruitName;
	int[] fruitQty;
	int _Line;
	bool isLock;
	float offsetX, firstX, firstY, secondY, realY;
	List<string> fruitTemp = new List<string> ();
	List<GameObject> fruitObj = new List<GameObject> ();
	// Use this for initialization
	void Start ()
	{
		//get position of this
		positionToSpawn = this.transform.localPosition;
		positionToSpawn.z = -0.5f;

	}

	// Update is called once per frame
	void Update ()
	{

		//recieve the Car wanted all the time | will this cause performance ?!?
		fruitName = stbox.fruitNameTemp;
		fruitQty = stbox.fruitQtyTemp;
		_Line = stbox._NLine;



		if (!isLock) {
			if (fruitName != null && fruitQty != null && _Line != null) {
				
				//for of fruit wanted
				for (int i = 0; i < _Line; i++) {
					int n = 0;
					if (fruitName [i] == "BoxOrange") {
						n = 3;
					} else if (fruitName [i] == "BoxCarrot") {
						n = 0;
					} else if (fruitName [i] == "BoxPineapple") {
						n = 4;
					} else if (fruitName [i] == "BoxGrape") {
						n = 1;
					} else if (fruitName [i] == "BoxMango") {
						n = 2;
					}
						
					if (i == 0) {
						//Line1
						firstY = 0.112f;
						realY = firstY;

					} else {
						//Line2
						secondY = -0.3f;
						realY = secondY;
					}
					offsetX = 0f;
					firstX = -0.9f;
					//for of each fruit qty wanted
					//each Line spawn fruit prefab
					for (int j = 0; j < fruitQty [i]; j++) {

						offsetX = offsetX + 0.3f;
						fruit = spawnFruit (n, fruitName [i], j);
						fruitObj.Add (fruit);
						fruit.transform.SetParent (this.transform, true);
						fruit.transform.localPosition = new Vector3 (firstX + offsetX, realY, -0.5f);
					}
					
				}
			}
			isLock = true;
		}

	}

	GameObject spawnFruit (int n, string boxName, int boxQty)
	{
		fruitTemp.Add (boxName + boxQty);
		return Instantiate (objSpawn [n], positionToSpawn, Quaternion.identity) as GameObject;
		//objSpawn
		//0 Carrot
		//1 Grape
		//2 Mango
		//3 Orange
		//4 Pineapple

	}

	public void isDead (string fruitName, int fruitChildNum)
	{
		for (int i = 0; i < fruitObj.ToArray ().Length; i++) {
			if (fruitTemp [i] == fruitName + fruitChildNum) {
				fruitObj [i].GetComponent<Animator> ().SetBool ("IsDead", true);
				//this Animator disable sprite -> disappear
			}
		}
	}
		
}
