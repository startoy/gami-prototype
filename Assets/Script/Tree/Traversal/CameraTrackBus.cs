using UnityEngine;
using System.Collections;

public class CameraTrackBus : MonoBehaviour {
	public GameObject _bus;
	private float _offsetX;
	private float _offsetY;
	// Use this for initialization
	void Start () {

		_offsetX = transform.position.x - _bus.transform.position.x;
		_offsetY = transform.position.y - _bus.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		Vector3 pos = new Vector3 (_bus.transform.position.x + _offsetX, _bus.transform.position.y + _offsetY, transform.position.z);
		transform.position = pos;
	}
}