using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour {
 void Start ()
    {
        Cursor.visible = true;

        if (PlayerPrefs.GetInt("primaVolta") == 0)
        {
            PlayerPrefs.SetFloat("volume", 1);
            PlayerPrefs.SetInt("livello", 2);
            PlayerPrefs.SetString("LastLevelPassed", "");

            PlayerPrefs.SetInt("primaVolta", 1);
        }

        
    }

	public void changeToScene(int Scena) {
		if (Scena == 1) {
            PlayerPrefs.SetInt("FirstTimeChampain", 0);
        }
			
		if (Scena==5)
			PlayerPrefs.SetInt("FirstTimeFreeMode",0);

        //Debug.Log ("Livello precedente :"+PlayerPrefs.GetInt("PreviousLevel"));
        PlayerPrefs.SetString("LastLevelPassed", "");
        SceneManager.LoadScene(Scena);
	}

	public void Options(){
        SceneManager.LoadScene("Options");
	}

    public void LoadCampaign()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevelPassed"));  
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("tempMultiplayer");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
