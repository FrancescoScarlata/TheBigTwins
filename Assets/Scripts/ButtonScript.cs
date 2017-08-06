using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	public void PlayAgain()
	{
		SceneManager.LoadScene(PlayerPrefs.GetString("PreviousLevel"));
		PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("LastScore"));
	}
	
	public void CometoMain()
	{
        SceneManager.LoadScene("SplashScreen");
	}

	public void NextCredits()
	{
        SceneManager.LoadScene("SplashScreen");
	}

	public void NextLevel() {
		PlayerPrefs.SetInt("LastScore",PlayerPrefs.GetInt("Score"));

		if (PlayerPrefs.GetString("PreviousLevel")== "Tutorial")
            SceneManager.LoadScene("IceRun");

		if (PlayerPrefs.GetString("PreviousLevel")== "IceRun")
            SceneManager.LoadScene("IceBoss");

		if (PlayerPrefs.GetString("PreviousLevel")== "IceBoss")
            SceneManager.LoadScene("FireRun");

		if (PlayerPrefs.GetString("PreviousLevel")== "FireRun")
            SceneManager.LoadScene("FireBoss");
		if (PlayerPrefs.GetString("PreviousLevel")== "FireBoss")
            SceneManager.LoadScene("SplashScreen");
        
		}


	void Update() {
        
		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Mouse2)) {
			Debug.Log("fatta la pic");
			System.DateTime now = System.DateTime.Now;
			Application.CaptureScreenshot(string.Format("Screenshot_{0}{1}{2}{3}{4}{5}.png",now.Year,now.Month,now.Day, now.Hour, now.Minute, now.Second));
		}
	}

}