using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
	public Canvas _CanLogin;
	public Canvas _CanReg;
//	public Canvas _CanIMG;
	public Canvas _CanScore;
	public Canvas _CanIcon;


	// Use this for initialization
	public void btnREG(){
		canloginHide ();
		canregOpen ();
	}
	public void btnGO(){
		canloginHide ();
		canIconOpen();
//		canhouseOpen ();
	}
	public void btnCANCEL(){
		canloginOpen ();
		canregHide ();
	}
	public void btnSUBMIT(){
		// add notic
		canloginOpen();
		canregHide ();
	}
	public void btnCLOSE(){
		canscoreHide ();
		canIconOpen();
//		canhouseOpen ();
	}

	public void btnOpenScoreBoard(){
		canIconHide();
		canscoreOpen();
	}

	public void btnExit(){
		canloginOpen();
		canIconHide ();
	}

	void canloginHide(){ _CanLogin.gameObject.SetActive (false);}
	void canloginOpen(){ _CanLogin.gameObject.SetActive (true); }
	void canregHide(){ _CanReg.gameObject.SetActive (false);}
	void canregOpen(){ _CanReg.gameObject.SetActive (true);}
//	void canhouseHide(){ _CanIMG.gameObject.SetActive (false);}
//	void canhouseOpen(){ _CanIMG.gameObject.SetActive (true);}
	void canscoreHide(){ _CanScore.gameObject.SetActive (false);}
	void canscoreOpen(){ _CanScore.gameObject.SetActive (true);}
	void canIconHide(){ _CanIcon.gameObject.SetActive (false);}
	void canIconOpen(){ _CanIcon.gameObject.SetActive (true);}



	void Start () {
	//	_CanLogin.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
}
