using UnityEngine;
using System.Collections;

public class RandomSpawnPrefab : MonoBehaviour
{
	public GameObject[] objSpawn;
//	public float randomMin=0f, randomMax=5f;
	public bool _isOver;
	public QueueControll Qcontroll;
//	public MakeHeart mkHeart;
	public float spawnTimeMin=1f, spawnTimeMax=1f;

	private float carHealth;
	private bool isSpawn;
	private bool isLost;
	private bool firstTrigger;
	Vector3 positionToSpawn = Vector3.zero;
	GameObject Car;
	// Use this for initialization
	void Start ()
	{
	
		//get position of this
		positionToSpawn = this.transform.position;
		isSpawn = false;
		_isOver = false;
		isLost = false;
		firstTrigger = false;
		//spawn car once on start

	}

	void Awake()
	{
		Invoke("spawnCar",Random.Range(spawnTimeMin,spawnTimeMax));
	}

	// Update is called once per frame
	void Update ()
	{
		_isOver = Qcontroll._gameControlOver;
		if (!_isOver) {
			//if not over -> continue spawning
			if (Car == null && firstTrigger) {
				//spawnCar if null AnchoredJoint2D firstTrigger is TRUE

				spawnCar ();

			}
			else if (Car != null) {
				
				carHealth = Car.GetComponent<carHealth> ()._curHealth;
//				Debug.Log ("CAR HEALTH = " + carHealth);
				if(carHealth<=0){
					if (isLost==false) {

						isLost = true;
						Qcontroll.bui.theHeart.LosingHeart ();
//						mkHeart.LosingHeart ();
					}
				}
			}
		} else {
			//else is over then return
			return;
		}

		//more condition if this null by health = 0


	}

	void FixedUpdate()
	{

	}

	void spawnCar()
	{
		firstTrigger = true;
		isLost = false;
		Car = Instantiate (objSpawn [Random.Range (0, objSpawn.Length)], positionToSpawn, Quaternion.identity) as GameObject;
		QueueControll.numCar++;
		Car.GetComponent<StorageBox>().thisNumCar = QueueControll.numCar;
//		Debug.Log ("numCar = " + QueueControll.numCar + "\n Car Num = " + Car.GetComponent<StorageBox>().thisNumCar);
//		Debug.Log ("Cur Car = " + QueueControll.curCar);
	}

}
