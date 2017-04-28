using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getHighScore : MonoBehaviour {

	public string getHighScoreURL = "getHighScore.php?";
	public Text rank, name, score;
	//	http://localhost/project/game/addScore.php?gameId=4&levelId=6&subLevelId=2&score=25&medal=3


	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	void Awake(){
//		string[] test1 = {"1","2","3"};
//		string[] test2 = {"asdasdasdasdasdasd asdasda","asdasdsadsadsada","asdasdsadasdas"};
//		string[] test3 = {"123123","521312321","214121"};
//		foreach(string n in test1){
//			rank.text += n + '\n';
//		}
//		foreach(string n in test2){
//			name.text += n + '\n';
//		}
//		foreach(string n in test3){
//			score.text += n + '\n';
//		}
		StartCoroutine(getHighScoreData());
	}



	IEnumerator getHighScoreData()
	{
		

		WWW getScore = new WWW(getHighScoreURL);
		yield return getScore; // The function halts until the get Score

		if (getScore.error == null)
		{
			//handle echo string
			parseScoreString (getScore.text);
			print("getting score data completed...");
		}
		else
		{
			print ("there is an error : " + getScore.error);
		}


	}

	void parseScoreString(string scoreString){
		if(scoreString == string.Empty)
			return;
		//trim remove whitespace(leading,tailing)
		string[] splitScore = scoreString.Trim ().Split('\n');

		int count = 1;
		foreach(string entry in splitScore){
			if (!entry.Contains ("\t"))
				throw new UnityException ("something went wrong.. " + entry);

			string[] temp = entry.Split ('\t');
			//temp[0] name
			//temp[1] score
			setTextUI (count.ToString (), temp [0], temp [1]);
			count++;
		}
		
	}

	void setTextUI(string rank,string name,string score){
		this.rank.text += rank + '\n' ;
		this.name.text += name + '\n' ;
		this.score.text += score + '\n' ;
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
