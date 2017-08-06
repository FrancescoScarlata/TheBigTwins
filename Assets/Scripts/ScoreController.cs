using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {

	
	// Use this for initialization

	// Update is called once per frame
	public static string newScore (int numscore) {

		if(SceneManager.GetActiveScene().name == "IceRun"|| SceneManager.GetActiveScene().name == "ModalitàLibera"|| SceneManager.GetActiveScene().name == "Tutorial")
			return "Score : "+numscore;
		else	
			return "Score : "+(numscore+PlayerPrefs.GetInt("LastScore"));


	}
}
