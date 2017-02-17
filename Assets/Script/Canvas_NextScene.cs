using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Canvas_NextScene : MonoBehaviour {
	
	public void Retry(string scene)
	{
		SceneManager.LoadScene(scene);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
