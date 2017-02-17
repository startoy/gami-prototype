using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Node : MonoBehaviour {

	public string nodeValue = "0";
	public Text textValue;
	public GameObject particle;
	// Use this for initialization
	void Start () {

	}

	void Awake(){
		if (nodeValue == "0") {
			nodeValue = textValue.text;
		}
	}

	// Update is called once per frame
	void Update () {

	}

	public void setT()
	{	
		if(particle)
			particle.SetActive (true);
	}

	public void setF()
	{
		if(particle)
			particle.SetActive (false);
	}
}
