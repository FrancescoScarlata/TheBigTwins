using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {
	public MovieTexture movie;
	private AudioSource audio;
    
        
	void Start () {
        audio = GetComponent<AudioSource>();
        Cursor.visible = false;
        GameObject oldmusic;
		if(oldmusic=GameObject.FindGameObjectWithTag("ResultsTrack")){
			Destroy(oldmusic.gameObject);
		}

		GetComponent<RawImage> ().texture = movie as MovieTexture;
		audio = GetComponent<AudioSource> ();
		audio.clip = movie.audioClip;
		movie.Play ();
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!movie.isPlaying)
			SceneManager.LoadScene("SplashScreen");

		if (Input.GetKey (KeyCode.Escape))
			movie.Stop();
	

	}

    
}
