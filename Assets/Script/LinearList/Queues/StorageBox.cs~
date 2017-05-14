using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StorageBox : MonoBehaviour
{
	//this script attached to the car



	// Use this for initialization
	string[] FruitTags = new string[] { "BoxOrange", "BoxCarrot", "BoxPineapple", "BoxGrape", "BoxMango" };
	public bool IsCollideStop;
	Vector3 CarMove = Vector3.zero;
	public float _CarMoveSpeed = 2f;
	public int _NLine, _NQty;
	public string[] fruitNameTemp;
	public int[] fruitQtyTemp;
	public GameObject Tire1;
	public GameObject Tire2;
	public spawnFruits spnFrt;
	public GameObject thinks;
	public bool _isDead;
	public carHealth carHealth;
	public int givingScore;
	public int startQtyNeed = 2;


	public int thisNumCar;

	private bool isInc;

	private bool isGiving;
	private bool _isOver;
	//	public MakeHeart mkHeart;
	void Start ()
	{
		isInc = false;
		//number of line Random 1-2
		_NLine = Random.Range (1, 3);
		//assign number of line to array size to store what fruit to be wanted for each
		fruitNameTemp = new string[_NLine];
		fruitQtyTemp = new int[_NLine];
		//then setup random the fruit and qty;
		setUpLine ();


		//use this bool to check if car should stop !!
		IsCollideStop = false;

		//use this bool to check increase score only once!!
		isGiving = false;
		Tire1.GetComponent<Animator> ().SetBool ("IsCarMove", true);
		Tire2.GetComponent<Animator> ().SetBool ("IsCarMove", true);

		//set active = false (spawn fruit)until is collide
		thinks.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(QueueControll.queueGameOver){
			CancelInvoke();
			return;
		}
//		Debug.Log ("THIS CAR NUM =>>> " + thisNumCar);

		//function to move the car until stop
		CarMoveToCollide ();

		//destroy this obj when 
		if (_isDead || checkToDestroy ()) {

			//isInc use to trigged to not increase counter too much
			if (!isInc) {
				isInc = true;
				QueueControll.curCar++;

			}
			CancelInvoke ("decreaseMood");
			this.GetComponent<Animator> ().SetBool ("carLeave", true);
			Invoke ("DestroyThis", 2f);
				

		}
			
	}
	//the collider must have Rigidbody and Collide component !! -> Rigidbody first
	//and this script attached should have collider
	void OnTriggerEnter2D (Collider2D other)
	{
		//foreach แต่ละค่าในอาเรย์ เช็คว่าเป็นแท็กอะไร
		foreach (string a in fruitNameTemp) {
			if (other.tag == a) {
				//ถ้ามันตายแล้ว ไม่ให้ผลไม้โยนเข้ามาได้อีก โอเคร๊ !?
				if (isInc)
					return;
				
				//ทำลายอันที่ลากมาใส่รถ
				Destroy (other.gameObject);

				//ทำให้รถขยับแล้วกลับไปเป็นอันเดิมใน 2 วิ
				this.transform.GetComponent<Animator> ().SetBool ("carGet", true);
				Invoke ("setToIdle",2f);

				//if this car not the right queue then losing heart !!
				if (thisNumCar != QueueControll.curCar) {
//					Debug.Log ("thisNum = " + thisNumCar + " - QueueControll.curCar = " + QueueControll.curCar);
					QueueControll.lostHeartQueue = true;
				}

				//call function to operate the answer when user drag boxfruit to collide
				checkAnswer (a);

			}
		}


		if (other.tag == "CollideStop") {

			if (!IsCollideStop) {
				InvokeRepeating ("decreaseMood", 0.5f, 1f); //carHealth.MaxdecreaseSecond

				//tag CollideStop is for stop the car when start moving car -> IsCollideStop true then stoped
				IsCollideStop = true;
			}
			//set thinks to active
			thinks.SetActive (true);
			if (!queueTutorial.qCounter1) {
				//set once
				queueTutorial.qCounter1 = true;
				queueTutorial.qCounter++;
			}
		}
	}
	//	void dc2()
	//	{
	//		InvokeRepeating ("decreaseMood", 0.5f, 0.75f); //carHealth.MaxdecreaseSecond
	//	}
	void checkAnswer (string a)
	{
		//decrease the number of fruit wanted to 0
		for (int i = 0; i < fruitNameTemp.Length; i++) {
			if (fruitNameTemp [i] == a) {
				if (fruitQtyTemp [i] == 0) {
					//PASS
				} else {
					//Decrease the number of wanted fruit
					fruitQtyTemp [i] -= 1;
					//After decrease set this fruit to play dead anim -> dead anim + disable sprite
					spnFrt.isDead (a, fruitQtyTemp [i]);
				}
			}
		}

	}

	void setToIdle()
	{
		this.transform.GetComponent<Animator> ().SetBool ("carGet", false);
	}

	void decreaseMood ()
	{
		carHealth.decreaseMood ();
	}

	//this function return boolean which is fruits wanted is collected all
	bool checkToDestroy ()
	{
		//use counter to check if is zero and equal to the size of array (line)
		int counter = 0;
		bool rt = false;
		for (int i = 0; i < fruitNameTemp.Length; i++) {
			if (fruitQtyTemp [i] == 0) {
				counter++;
			} 

			if (counter == fruitNameTemp.Length) {
				if (!isGiving) {
					isGiving = true;
//					QueueControll.score += givingScore;
					QueueControll.givingScoreQueue = true;
					if (!queueTutorial.qCounter2) {
						//set once
						queueTutorial.qCounter2 = true;
						queueTutorial.qCounter++;
					}
				}
				rt = true;
			}
		}

		return rt;
	}





	//this function operate the movement
	void CarMoveToCollide ()
	{
		if (!IsCollideStop) {
			//if not false to stop then MOVE car
			CarMove = new Vector3 (this.transform.position.x + _CarMoveSpeed * Time.deltaTime, this.transform.position.y, this.transform.position.z);
		} else {
			CarMove = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
			Tire1.GetComponent<Animator> ().SetBool ("IsCarMove", false);
			Tire2.GetComponent<Animator> ().SetBool ("IsCarMove", false);
		}
		this.transform.position = CarMove;
	}

	//this function use to create the wanted fruits
	void setUpLine ()
	{
		for (int i = 0; i < _NLine; i++) {
			//random Qty
			_NQty = Random.Range (startQtyNeed, 6);

			//check if is same
			//when > 1
			if (i >= 1) {
				fruitNameTemp [i] = randomFruit ();
				//if same
				if (fruitNameTemp [i] == fruitNameTemp [i - 1]) {
					
					return;
				}
			} 
			//else 0
			else {
				//assign what fruit wanted
				fruitNameTemp [i] = randomFruit ();
			}

			//assign what number of qty wanted from Random _NQty
			fruitQtyTemp [i] = _NQty;


		}
	}

	string randomFruit ()
	{
		//return string tag
		return FruitTags [Random.Range (0, FruitTags.Length)];
	}

	void DestroyThis ()
	{
		//destroy this car
		DestroyObject (this.gameObject);
	}


}
