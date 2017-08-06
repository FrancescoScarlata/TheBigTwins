using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class TextTutorialBasics : MonoBehaviour {

    float time = 0;
    public Text tutorial;
    string testo;
    // Use this for initialization
    void Start () {
        testo = "Press Esc to go back or continue to go forward.";
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
            tutorial.text = "";
        if (time > 10)
            tutorial.text = testo;
    }

}
