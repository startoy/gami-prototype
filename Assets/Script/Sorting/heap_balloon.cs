using UnityEngine;
using System.Collections;

public class heap_balloon : MonoBehaviour
{
	public GameObject _LBall, _RBall, _PBall;
	public GameObject _CurSurface;
	//current obj on surface
	public bool _isCurNull, _isMaxheap;
	//is balloon surface null or not

	// Use this for initialization
	void Start ()
	{
		_isCurNull = true;
		_isMaxheap = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_isMaxheap = isMaxHeap ();
	}

	public bool isMaxHeap ()
	{
		if (!_CurSurface) {
			return false;
		}
		bool res = false;

		GameObject L, R, P;
		int Lval = 0, Rval = 0, Cval = 0, Pval = 0;

		if (_LBall && _LBall.GetComponent <heap_balloon> ()._CurSurface) {
			L = _LBall.GetComponent <heap_balloon> ()._CurSurface;
			Lval = L.GetComponent <orangeValue> ().value;
//			Debug.Log ("Lval" + Lval);
		}

		if (_RBall && _RBall.GetComponent <heap_balloon> ()._CurSurface) {
			R = _RBall.GetComponent <heap_balloon> ()._CurSurface;
			Rval = R.GetComponent <orangeValue> ().value;
//			Debug.Log ("Rval" + Rval);
		}

		if (_PBall && _PBall.GetComponent <heap_balloon> ()._CurSurface) {
			P = _PBall.GetComponent <heap_balloon> ()._CurSurface;
			Pval = P.GetComponent <orangeValue> ().value;
//			Debug.Log ("Pval" + Pval);
		}

		Cval = _CurSurface.GetComponent <orangeValue> ().value;
//		Debug.Log ("Cval" + Cval);

		if (_RBall && _LBall && _LBall.GetComponent <heap_balloon> ()._CurSurface && _RBall.GetComponent <heap_balloon> ()._CurSurface) {
			if (Cval >= Lval && Cval >= Rval) {
				res = true;
			}
//			Debug.Log ("is have both L and R");
		} else if (!_RBall && _LBall && _LBall.GetComponent <heap_balloon> ()._CurSurface) {
			if (Cval >= Lval) {
				res = true;
			}
//			Debug.Log ("is have only L");
		} else if (_RBall && !_LBall && _RBall.GetComponent <heap_balloon> ()._CurSurface) {
			if (Cval >= Rval) {
				res = true;
			}
//			Debug.Log ("is have only R");
		} else {
//			Debug.Log ("No childs");
			res = true;
		}

		if (_PBall && _PBall.GetComponent <heap_balloon> ()._CurSurface) {
			if (Cval > Pval) {
				res = false;
			} else {
				res = true;
			}
		}

		return res;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "onsort") {
			StartCoroutine (enter2d(other));
		}
	}

	IEnumerator enter2d(Collider2D other){
		yield return new WaitForSeconds (0.5f);
		_isCurNull = false;
		_CurSurface = other.gameObject;
	}

	//	void OnTriggerStay2D (Collider2D other)
	//	{
	//		if (other.tag == "unsort") {
	//			_isCurNull = false;
	//			_CurSurface = other.gameObject;
	//			_isMaxheap = isMaxHeap ();
	//		}
	//	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (heap_controller._heapSortReverseMode == 2) {
			if (other.tag == "onsort") {
//				Debug.Log (this.gameObject.name + " set onsort ->" + _CurSurface.GetComponent <orangeValue>().value);
				_isCurNull = true;
				_CurSurface = null;
			}
		}
	}

}
