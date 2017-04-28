using UnityEngine;
using System.Collections;

public class addScore : MonoBehaviour {

	private string secretkey = "senior2017";
	public string gameId,levelId,subLevelId;
	//Don't forget the question marks!
	public string AddScoreURL = "game/addScore.php?";
//	http://localhost/project/game/addScore.php?gameId=4&levelId=6&subLevelId=2&score=25&medal=3
	private int score;
	private string medal;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//attached this file to game set id each level and if update score call this function "addScoreWWW"
	public void addScoreWWW(int score,string medal){
		setScore (score);
		setMedal (medal);
		StartCoroutine(AddScore());
	}

	void setScore(int score){
		this.score = score;
	}

	void setMedal(string medal){
		this.medal = medal;
	}

	IEnumerator AddScore()
	{
		string hash = Md5Sum(gameId + levelId + subLevelId + score + medal + secretkey);

		WWW ScorePost = new WWW(AddScoreURL 
			+ "gameId=" + WWW.EscapeURL(gameId) 
			+ "&levelId=" + WWW.EscapeURL(levelId)
			+ "&subLevelId=" + WWW.EscapeURL(subLevelId)
			+ "&score=" + score 
			+ "&medal=" + WWW.EscapeURL(medal)
			+ "&hash=" + hash); //Post our score
		yield return ScorePost; // The function halts until the score is posted.

		if (ScorePost.error == null)
		{
			print (ScorePost.text);
			print("posting data with no error completed");
//			StartCoroutine(GrabRank(name)); // If the post is successful, the rank gets grabbed next.
		}
		else
		{
			print ("there is an error : " + ScorePost.error);
		}
			

	}

	private string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}
}
