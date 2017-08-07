using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour {
	public Text score;
	public Text MaxScore;
	public Text ClockTime;

	// Use this for initialization
	void Start () {
           Cursor.visible = true;

         // Casi di non tutorial
            score.text = "Your Actual Score is : " + PlayerPrefs.GetInt("Score");

            if (PlayerPrefs.GetString("PreviousLevel") == "IceRun")
                MaxScore.text = "The High score is : " + PlayerPrefs.GetInt("HighscoreIceRun");

            if (PlayerPrefs.GetString("PreviousLevel") == "FireRun")
                MaxScore.text = "The High score is : " + PlayerPrefs.GetInt("HighscoreFireRun");

            if (PlayerPrefs.GetString("PreviousLevel") == "ModalitàLibera")
                MaxScore.text = "The High score is è : " + PlayerPrefs.GetInt("HighscoreFreeMode");

        if (PlayerPrefs.GetString("PreviousLevel") == "IceBoss"|| PlayerPrefs.GetString("PreviousLevel") == "FireBoss")
            MaxScore.text = "No high score here. But Well played the same!";

        if (PlayerPrefs.GetString("PreviousLevel") == "IceRun"|| PlayerPrefs.GetString("PreviousLevel") == "IceBoss" || PlayerPrefs.GetString("PreviousLevel") == "FireRun"|| 
            PlayerPrefs.GetString("PreviousLevel") == "FireBoss" || PlayerPrefs.GetString("PreviousLevel") == "ModalitàLibera")
                ClockTime.text = " Time of Play : " + PlayerPrefs.GetInt("Time")/60 + " minutes and "+ (int)PlayerPrefs.GetInt("Time") % 60 + " sec"; ;

           

        if (PlayerPrefs.GetString("PreviousLevel") == "BasicMoves" || PlayerPrefs.GetString("PreviousLevel") == "Look_Around" || PlayerPrefs.GetString("PreviousLevel") == "Jump"||
            PlayerPrefs.GetString("PreviousLevel") == "IceTutorial" || PlayerPrefs.GetString("PreviousLevel") == "FireTutorial" || PlayerPrefs.GetString("PreviousLevel") == "AllIn")
            score.text = "You failed in a tutorial... Come on! I'm sure you can do better! ";

        if(SceneManager.GetActiveScene().name=="Win")
        {
            if(PlayerPrefs.GetString("PreviousLevel")=="IceRun")
            {
                PlayerPrefs.SetString("LastLevelPassed", "IceBoss");
            }
            if (PlayerPrefs.GetString("PreviousLevel") == "IceBoss")
            {
                PlayerPrefs.SetString("LastLevelPassed", "FireRun");
            }
            if (PlayerPrefs.GetString("PreviousLevel") == "FireRun")
            {
                PlayerPrefs.SetString("LastLevelPassed", "FireBoss");
            }
            if (PlayerPrefs.GetString("PreviousLevel") == "FireBoss")
            {
                PlayerPrefs.SetString("LastLevelPassed", "");
            }
        }
        
	}
		
	// Update is called once per frame
	void Update() {

		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Mouse2)) {
			Debug.Log("fatta la pic");
			System.DateTime now = System.DateTime.Now;
			ScreenCapture.CaptureScreenshot(string.Format("Screenshot_{0}{1}{2}{3}{4}{5}.png",now.Year,now.Month,now.Day, now.Hour, now.Minute, now.Second));
		}
	}
}
