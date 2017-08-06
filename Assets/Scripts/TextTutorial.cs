using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class TextTutorial : MonoBehaviour {

	float time =0;
	public Text tutorial;
	int testo_corrente=0;
    public string nametutorialfile;
    string[] testi;
   
	//prende i messaggi da file. Controlla i file in resources per vedere i messaggi e player tutorial controller per altre informazioni
	void Start () {
        testi = ((TextAsset)Resources.Load(nametutorialfile)).text.Split("\n"[0]);
	}
	
	// Serve a fare scomparire i messaggi
	void Update () {
	    time += Time.deltaTime;
		if (time > 5)
			tutorial.text = "";

	}
	public void ChangeText(int zposition)
	{
		if (zposition >= testo_corrente * 10) {
			tutorial.text = testi [testo_corrente];
			time = 0;
			testo_corrente++;
		}
	}

}
