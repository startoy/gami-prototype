using UnityEngine;
using System.Collections;

public class CameraTrack : MonoBehaviour {

	public Transform target;
	public float xOffset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x + xOffset, target.transform.position.y, transform.position.z);
	}
}
