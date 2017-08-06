using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    public Slider volume;
   
    private GameObject music;

    //Inserire il Nome giocatore e come modificarlo

    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        volume.value = PlayerPrefs.GetFloat("volume");
    }

    // Update is called once per frame
    public void ChooseDifficulty (int livello) {

        PlayerPrefs.SetInt("livello", livello);
    }
    public void CambiaVolume()
    {
        PlayerPrefs.SetFloat("volume", volume.value);

        if (music = GameObject.FindGameObjectWithTag("SSTrack"))
            music.GetComponent<AudioSource>().volume = volume.value;
    }

    //Metodo per tornare indietro al menu
    public void ComeBack()
    {
        SceneManager.LoadScene("SplashScreen");
    }
}
