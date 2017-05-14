using UnityEngine;
using System.Collections;

public class animalMove : MonoBehaviour
{

	// Use this for initialization
	//		right 0.25
	//		left  -0.25
	public float maxSpeed=0.75f;
	Vector3 transXLeft=Vector3.zero, tranXRight=Vector3.zero;
	bool RBool = false;

	void Start ()
	{
		transXLeft = this.transform.position;
		tranXRight = this.transform.position;

		transXLeft.x = this.transform.position.x - 0.25f;
		tranXRight.x = this.transform.position.x + 0.25f;
		float chooseStart = Mathf.Round (Random.Range (0f, 1.5f));
		if (chooseStart == 1f) {
			RBool = true;
			setFlip ();
		} else {
			RBool = false;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.GetComponent <Animator> ().speed = maxSpeed;
	}

	void FixedUpdate ()
	{
		if(RBool){
			randomMove ("R");
		}else{
			randomMove ("L");
		}
	}

	void randomMove (string mode)
	{
		float speed = Random.Range (0f, maxSpeed);
		float step = Random.Range (0f,maxSpeed) * Time.deltaTime;
		Vector3 newPos = Vector3.zero;
		if(mode == "R"){
			newPos = tranXRight;
		}else{
			newPos = transXLeft;
		}

		this.transform.position = Vector3.MoveTowards (this.transform.position, newPos, step);
		if(this.transform.position == newPos){
			setFlip ();
			RBool = !RBool;
		}

	}

	void setFlip(){
			Vector3 tran = this.transform.localScale;
			tran.x = -tran.x;
			this.transform.localScale = tran;
	}


}
