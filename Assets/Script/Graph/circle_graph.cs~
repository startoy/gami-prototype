using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class circle_graph : MonoBehaviour {

	public int nodeValue = 0;
	public Text textValue;
	public GameObject particle;
	// Use this for initialization
	void Start () {
		
	}

	void Awake(){
		
	}
	
	// Update is called once per frame
	void Update () {
		if (nodeValue == 0) {
			nodeValue = int.Parse (textValue.text);
		}
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
