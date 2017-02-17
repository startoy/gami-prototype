using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class carHealth : MonoBehaviour {

	public float _startingHealth = 100f;
	public Slider _slider;
	public Image _fillImage;
	public Color _fullHealColor = Color.green;
	public Color _zeroHealColor = Color.red;

	//if user not set in component this assign will be default value
//	public float MaxdecreaseAmount = 2.5f;
//	public float MaxdecreaseSecond = 1f;
	public StorageBox stb;



	public float _curHealth;
	private bool _dead;
	private float _deAmount;
	private float _deSecond;

	// Use this for initialization
	void Start () {
		_deAmount = 1f;
		_deSecond = 1f;
		//starting 3 second
		//call every decreaseSecond second
		//InvokeRepeating("decreaseMood", 0f, _deSecond);
	}

	void OnEnable()
	{
		_curHealth = _startingHealth;
		_dead = false;
		SetHealthUI ();
	}
	
	// Update is called once per frame
	void Update () {

	}
		

	public void decreaseMood()
	{
		float amount = _deAmount*2;
		_curHealth -= amount;
		SetHealthUI ();
		if (_curHealth <= 0 && !_dead) {
			OnDeath ();
		}
//		Debug.Log (_curHealth);
	}

	void SetHealthUI(){
		//adjust value of color of the slider
		_slider.value = _curHealth;
		_fillImage.color = Color.Lerp (_zeroHealColor, _fullHealColor, _curHealth / _startingHealth);

	}

	void OnDeath(){

		_dead = true;
		stb._isDead = _dead;
	}
}
