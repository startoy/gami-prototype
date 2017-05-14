using UnityEngine;
using System.Collections;

public class GrassRandom : MonoBehaviour {
	//Range of spawn
	public float _xMin;
	public float _xMax;
	public float _yMin;
	public float _yMax;

	//Array of objects to spawn
	public GameObject[] _theObjects;

	//Time it take to spawn
	[Space(3)]
	public float waitingForNextSpawn;
	public float theCountDown;
	public float SpawnNum;
	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (SpawnNum >= 0) {
			theCountDown -= 1;
			if (theCountDown >= 0) {
				spawn ();
				theCountDown = waitingForNextSpawn;
				SpawnNum--;
			}
		}


	}

	void spawn(){
		//RANDOM x y to pos
		Vector2 position = new Vector2(Random.Range (_xMin, _xMax),Random.Range (_yMin, _yMax));

		//choose from theObjects to spawn -> prefab
		GameObject obj = _theObjects [Random.Range(0,_theObjects.Length)];

		//create obj at pos , rotation
		Instantiate(obj,position,transform.rotation);
	}
}
