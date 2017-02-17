using UnityEngine;
using System.Collections;

public class arrow_script : MonoBehaviour
{
	public AudioClip arrowCreateAudio,arrowDeleteAudio;
	public Transform originTarget, target;
	public int arrowNO;
	private Vector3 v_diff;
	private float atan2;

	// Use this for initialization
	void Start ()
	{

	}

	void Awake ()
	{
		StartCoroutine(Delay(0.0001f));
		this.gameObject.GetComponent<AudioSource> ().PlayOneShot (arrowCreateAudio);
	}
	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator Delay(float sec){
		yield return new WaitForSeconds (sec);
		setPosArrow ();
		rotateArrow ();
	}

	void rotateArrow ()
	{
		//get position between 2
		v_diff = (target.position - transform.position);    
		atan2 = Mathf.Atan2 (v_diff.y, v_diff.x);
		//apply atan2 to Z position
		transform.rotation = Quaternion.Euler (0f, 0f, atan2 * Mathf.Rad2Deg);
	}

	void setPosArrow ()
	{
		//move arrow to midpoint between 2 objects
		Vector3 midPointVector = (originTarget.position + target.position) / 2;
		transform.position = midPointVector;

		//cal. relative 2 object
		Vector3 relative = (originTarget.position - target.position);
		//convert relative(vector3) to length
		float maggy = relative.magnitude;
		//scale sprite by length \depend on sprite size
		transform.localScale = new Vector3 (maggy/1.125f, 3f, 0);
//		transform.localScale = new Vector3 (maggy / 2f, 1f, 0);
	}

	public void destroyArrow()
	{
		this.gameObject.GetComponent<AudioSource> ().PlayOneShot (arrowDeleteAudio);
		StartCoroutine(DelayDelete(0.25f));
	}

	IEnumerator DelayDelete(float sec){
		yield return new WaitForSeconds (sec);
		DestroyObject(this.gameObject);
	}

//	void roTate ()
//	{
////		anchorPos = second.transform.position;
////		currentPos = first.transform.position;
////		//		anchorPos.z = 0;
////		currentPos.z = 0;
////		//get midpoint/centerpoint
////		Vector3 midPointVector = (currentPos + anchorPos)/2;
////		//move arrow to that midpoint
////		transform.position = midPointVector;
////		//get length between 2 vectors
////		Vector3 relative = currentPos - anchorPos;
////		float maggy = relative.magnitude;
////
////
//////		transform.localScale = new Vector3(maggy/4f,0.3f,0);
//////		Quaternion rotationVector = Quaternion.LookRotation(relative);
////		Quaternion rotationVector = Quaternion.LookRotation (relative);
////		Debug.Log (rotationVector);
////		rotationVector.z = 0;
////		rotationVector.w = 0;
////		transform.rotation = rotationVector;
//	}


}
