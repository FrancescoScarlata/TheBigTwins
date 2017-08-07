using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditButtonScript : MonoBehaviour {

	public Text testo;

	// Use this for initialization
	void Start () {
	
		if (SceneManager.GetActiveScene().name == "Win"){
			if(PlayerPrefs.GetString("PreviousLevel")=="IceRun"||
				PlayerPrefs.GetString("PreviousLevel")=="IceBoss"||
				PlayerPrefs.GetString("PreviousLevel")=="FireRun"){
				testo.text= "Next Level";
				return;
			}
			if(PlayerPrefs.GetString("PreviousLevel")=="FireBoss"){
				testo.text= "Continue";
				return;
			}
			if(PlayerPrefs.GetString("PreviousLevel")=="Tutorial"){
				testo.text= "Start the Campaign";
				return;
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
