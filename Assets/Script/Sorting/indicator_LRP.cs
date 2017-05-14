using UnityEngine;
using System.Collections;

public class indicator_LRP : MonoBehaviour {
	bool isMoving = false;
	bool finishAnim = false;
	GameObject moveToObj;
	public bool isP=false;
	public bool isActive = false;
	public Sprite DActSprite, ActSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!isP)
		{
			if(isActive){
				//สีคล้ำๆ Active
				this.GetComponentInChildren <SpriteRenderer> ().sprite = ActSprite;
				this.GetComponentInChildren <Animator>().SetBool ("indicateAnimate",true);
			}else{
				//สีสว่างๆ Deactive
				this.GetComponentInChildren <SpriteRenderer> ().sprite = DActSprite;
				this.GetComponentInChildren <Animator>().SetBool ("indicateAnimate",false);
			}
		}

		if(isMoving)
		{
			setPosXwith (moveToObj);
		}
	}

	void setPosXwith(GameObject otherPos)
	{
//		bool result = false;
		float step = 2 * Time.deltaTime;
		Vector3 sTarget = new Vector3 (otherPos.transform.position.x, -1.25f, this.transform.position.z);
		this.transform.position = Vector3.MoveTowards (this.transform.position, sTarget, step * 4f);
		if (this.transform.position == sTarget) {
			isMoving = false;
			finishAnim = true;
//			result = true;
		}
//		return result;
	}

	public bool F_finishAnim()
	{
		Debug.Log ("finishAnim="+finishAnim);
		return finishAnim;

	}

	public void setToMoving (bool inputBool,GameObject gameObj)
	{
		finishAnim = false;
		isMoving = inputBool;
		moveToObj = gameObj;
	}
}
