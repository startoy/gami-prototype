using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boxbomb : MonoBehaviour
{

	public float _timeLeft;
	public bool _isBombed;
	public bool _isStop;
	public Text _timerText;

	//explode
	public float radius = 3.0F;
	public int power = 15000;
	//	Vector2[] vpos = new Vector2[]{transform.up};

	// Use this for initialization
	void Start ()
	{
		_isBombed = false;
		_isStop = false;
	}

	// Update is called once per frame
	void Update ()
	{
		
		//if is neither bombed and stop -> countdown the timer
		if (!_isBombed && !_isStop) {
			_TimerCountdown ();
		}

		// if is bombed
		if (_isBombed) {
			_timerText.text = "";

			this.transform.GetComponent<Animator> ().SetBool ("isExplode", true);

		}

		//if this obj is play animator state call "boxbombExplode" after finished play then set active to false
		if (this.transform.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("boxbombExplode")) {
			
			this.gameObject.SetActive (false);
			explode ();

		}
		if (_isStop) {
			Invoke ("disText", 2f);
		}
	}

	void _TimerCountdown ()
	{
		if (_timeLeft < 0) {
			_isBombed = true;
			_timeLeft = 0;
		}
		if (!_isBombed) {
			_timeLeft -= Time.deltaTime;
		}
		if (_timerText != null) {
			_timerText.text = "เวลาก่อนจะระเบิด : " + Mathf.Round (_timeLeft).ToString ();
		}
	}

	void disText ()
	{
		_timerText.text = "";
	}

	void explode ()
	{
		Vector2 explosionPos = transform.position;
		Collider2D[] colliders = Physics2D.OverlapCircleAll (explosionPos, radius);
		Debug.Log (colliders.Length + " colliders in range ");
		foreach (Collider2D hit in colliders) {
			float ran = Mathf.Round (Random.Range (1, 3));

			Rigidbody2D rb = hit.GetComponent<Rigidbody2D> ();
			SpringJoint2D spring = hit.GetComponent <SpringJoint2D> ();


			if (rb != null && spring != null) {
				Destroy (spring);
				rb.isKinematic = false;
				if (ran == 1) {
					rb.AddForce (transform.up * power * Mathf.Round (Random.Range (15, 25)));
				} else if (ran == 2) {
					rb.AddForce (transform.right * power * Mathf.Round (Random.Range (15, 25)));
				} else if (ran == 3) {
					rb.AddForce (-transform.right * power * Mathf.Round (Random.Range (15, 25)));
				}
				// THERE IS NO EXPLOSIONFORCE IN RIGID 2D !!
//				rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
			}
		}
	}
}
