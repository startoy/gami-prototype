using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class toggleScript : MonoBehaviour
{
	public Toggle tgBtn;
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

//		print (PlayerPrefs.GetInt ("mutestate")); 	
	}

	void Awake ()
	{
		// 0 true, 1 false

		int mute = PlayerPrefs.GetInt ("mutestate");
		if (mute==1) {
//			print("Awake TRUE");
			tgBtn.isOn = false;}
		else {
//			print ("Awake FALSE");
			tgBtn.isOn = true;
		}	
//		this.GetComponent <Toggle>().isOn;
	}

	public void setToggleState ()
	{
		
		int mute = PlayerPrefs.GetInt ("mutestate");
//		print ("mute=" + mute);
		if(mute==1){PlayerPrefs.SetInt ("mutestate",0);
//			print("1 set to 0");
		}else if(mute==0){PlayerPrefs.SetInt ("mutestate",1);
//			print("0 set to 1");
		
		}
	}
}
