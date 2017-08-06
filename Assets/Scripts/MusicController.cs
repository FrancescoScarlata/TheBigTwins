using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicController: MonoBehaviour {

    public Transform[] SplashScreenMusics;
    public Transform[] TutorialMusics;
    public Transform[] GameMusics;
    public Transform[] ResultsMusics;
    public Transform LastLevel;
    public Transform Credits;


    private Object mManager;
    private GameObject music;
    private int index;
    // Per Inserire la musica.
    
	public void Start() {
    
        GameObject oldMusic;
        index = PlayerPrefs.GetInt("indiceMusica");
        if ((SceneManager.GetActiveScene()).name == "SplashScreen" )
        {
            if (!GameObject.FindGameObjectWithTag("SSTrack"))
            {
                index++;
                mManager = Instantiate(SplashScreenMusics[index % SplashScreenMusics.Length], transform.position, Quaternion.identity);
                mManager.name = SplashScreenMusics[index % SplashScreenMusics.Length].name;
                Transform temp = (Transform)mManager;
                if (PlayerPrefs.GetInt("primaVolta") == 0)
                {
                    PlayerPrefs.SetFloat("volume",1);
                    PlayerPrefs.SetInt("primaVolta", 1);
                }
                    temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);
                DontDestroyOnLoad(mManager);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("GameTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("ResultsTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("LastLevelTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("TutorialTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("CreditsTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }
        if ((SceneManager.GetActiveScene()).name == "TutorialMenu" || (SceneManager.GetActiveScene()).name == "Options")
        {
            if (!GameObject.FindGameObjectWithTag("SSTrack"))
            {
                index++;
                mManager = Instantiate(SplashScreenMusics[index % SplashScreenMusics.Length], transform.position, Quaternion.identity);
                mManager.name = SplashScreenMusics[index % SplashScreenMusics.Length].name;
                Transform temp = (Transform)mManager;
               
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);
                DontDestroyOnLoad(mManager);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("GameTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("ResultsTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("LastLevelTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("TutorialTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("CreditsTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }
        if ((SceneManager.GetActiveScene()).name == "Credits")
        {
            if (!GameObject.FindGameObjectWithTag("CreditsTrack"))
            {
                index++;
                mManager = Instantiate(Credits, transform.position, Quaternion.identity);
                mManager.name = Credits.name;
                Transform temp = (Transform)mManager;

                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);
                DontDestroyOnLoad(mManager);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("GameTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("ResultsTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("LastLevelTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("TutorialTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("SSTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }

        if ((SceneManager.GetActiveScene()).name == "IceRun"|| (SceneManager.GetActiveScene()).name == "IceBoss" || (SceneManager.GetActiveScene()).name == "FireRun" || (SceneManager.GetActiveScene()).name == "ModalitàLibera")
        {
            if (!GameObject.FindGameObjectWithTag("GameTrack"))
            {
                index++;
                mManager = Instantiate(GameMusics[index % GameMusics.Length], transform.position, Quaternion.identity);
                mManager.name = GameMusics[index % GameMusics.Length].name;
                DontDestroyOnLoad(mManager);
                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("SSTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("ResultsTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("LastLevelTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("TutorialTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("CreditsTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }
        if ((SceneManager.GetActiveScene()).name == "GameOver" || (SceneManager.GetActiveScene()).name == "Win")
        {
            if (!GameObject.FindGameObjectWithTag("ResultsTrack"))
            {
                index++;
                mManager = Instantiate(ResultsMusics[index % ResultsMusics.Length], transform.position, Quaternion.identity);
                mManager.name = ResultsMusics[index % ResultsMusics.Length].name;
                DontDestroyOnLoad(mManager);
                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("SSTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("GameTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("LastLevelTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("TutorialTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("CreditsTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }
        if ((SceneManager.GetActiveScene()).name == "FireBoss")
        {
            if (!GameObject.FindGameObjectWithTag("LastLevelTrack"))
            {
                index++;
                mManager = Instantiate(LastLevel, transform.position, Quaternion.identity);
                mManager.name = LastLevel.name;
                DontDestroyOnLoad(mManager);
                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("SSTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("ResultsTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("GameTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("TutorialTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("CreditsTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }
        if ((SceneManager.GetActiveScene()).name == "AllIn" || (SceneManager.GetActiveScene()).name == "BasicMoves" || SceneManager.GetActiveScene().name == "FireTutorial" ||
            SceneManager.GetActiveScene().name == "IceTutorial" || SceneManager.GetActiveScene().name == "Jump" || SceneManager.GetActiveScene().name == "Look_Around")
        {
            if (!GameObject.FindGameObjectWithTag("TutorialTrack"))
            {
                index++;
                mManager = Instantiate(TutorialMusics[index % TutorialMusics.Length], transform.position, Quaternion.identity);
                mManager.name = TutorialMusics[index % TutorialMusics.Length].name;
                DontDestroyOnLoad(mManager);
                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                PlayerPrefs.SetInt("indiceMusica", index);

                //Controlla se ci sono musiche di altre parti
                if (oldMusic = GameObject.FindGameObjectWithTag("SSTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("ResultsTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("LastLevelTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("GameTrack"))
                    Destroy(oldMusic.gameObject);
                if (oldMusic = GameObject.FindGameObjectWithTag("CreditsTrack"))
                    Destroy(oldMusic.gameObject);
            }
        }
    }

    public void FixedUpdate()
    {
        if (music = GameObject.FindGameObjectWithTag("SSTrack"))
        {
            if (music == null || SplashScreenMusics.Length == 0)
                return;
            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Destroy(music);
                index++;
                mManager = Instantiate(SplashScreenMusics[index % SplashScreenMusics.Length], transform.position, Quaternion.identity);
                mManager.name = SplashScreenMusics[index % SplashScreenMusics.Length].name;
                
                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                DontDestroyOnLoad(mManager);
                PlayerPrefs.SetInt("indiceMusica", index);
            }
        }
        if (music = GameObject.FindGameObjectWithTag("CreditsTrack"))
        {
            if (music == null || Credits == null)
                return;
            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Destroy(music);
                index++;
                mManager = Instantiate(Credits, transform.position, Quaternion.identity);
                mManager.name = Credits.name;

                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                DontDestroyOnLoad(mManager);
                PlayerPrefs.SetInt("indiceMusica", index);
            }
        }
        if (music = GameObject.FindGameObjectWithTag("TutorialTrack"))
        {
            if (music == null || TutorialMusics.Length == 0)
                return;
            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Destroy(music);
                index++;
                mManager = Instantiate(TutorialMusics[index % TutorialMusics.Length], transform.position, Quaternion.identity);
                mManager.name = TutorialMusics[index % TutorialMusics.Length].name;

                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                DontDestroyOnLoad(mManager);
                PlayerPrefs.SetInt("indiceMusica", index);
            }
        }
        if (music = GameObject.FindGameObjectWithTag("ResultsTrack"))
        {
            if (music == null || ResultsMusics.Length == 0)
                return;
            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Destroy(music);
                index++;
                mManager = Instantiate(ResultsMusics[index % ResultsMusics.Length], transform.position, Quaternion.identity);
                mManager.name = ResultsMusics[index % ResultsMusics.Length].name;

                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                DontDestroyOnLoad(mManager);
                PlayerPrefs.SetInt("indiceMusica", index);
            }
        }
        if (music = GameObject.FindGameObjectWithTag("GameTrack"))
        {
            if (music == null || GameMusics.Length == 0)
                return;
            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Destroy(music);
                index++;
                mManager = Instantiate(GameMusics[index % GameMusics.Length], transform.position, Quaternion.identity);
                mManager.name = GameMusics[index % GameMusics.Length].name;

                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                DontDestroyOnLoad(mManager);
                PlayerPrefs.SetInt("indiceMusica", index);
            }
        }
        if (music = GameObject.FindGameObjectWithTag("LastLevelTrack"))
        {
            if (music == null || LastLevel == null)
                return;
            if (!music.GetComponent<AudioSource>().isPlaying)
            {
                GameObject.Destroy(music);
                index++;
                mManager = Instantiate(LastLevel, transform.position, Quaternion.identity);
                mManager.name = LastLevel.name;

                Transform temp = (Transform)mManager;
                temp.gameObject.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
                DontDestroyOnLoad(mManager);
                PlayerPrefs.SetInt("indiceMusica", index);
            }
        }


    }
}
	
	