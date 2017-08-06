using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CanvasUIController : MonoBehaviour {

    public RectTransform[] PlayersPanels;
    public RectTransform Time;


	// Use this for initialization
	void Start () {
         NoPlayerConnected();
        //Prova per vedere se si riesce a trovarli in ordine - ordine raggiunto. bisogna sistemare
        /*
        GameObject [] elems =  GameObject.FindGameObjectsWithTag("PlayerPanel");
        Debug.Log(elems.Length);
        for( int i=0; i<elems.Length; i++)
            
            elems[i].gameObject.name="Elemento "+i;
        */

	}
	
	// Update is called once per frame
	void Update () {

	}

    void NoPlayerConnected()
    {
        for (int i=0; i<PlayersPanels.Length; i++)
        {
            PlayersPanels[i].gameObject.SetActive(false);
        }
        Time.gameObject.SetActive(true);
    }

    //Quando un nuovo utente si collega, bisogna dargli un panel per inserire il suo nome e il suo score.
    // Il suo score poi deve essere aggiornato da lui, quindi bisognerebbe legarlo al giocatore.
    // In dubbio Se dargli il text direttamente oppure un index da cui poi prendere il panel e il rispettivo text. Da rivedere
    public int NewPlayerConnected(string Playername)
    {
        Debug.Log("si e' connesso un giocatore");
        int index;
        for(index=0; index<PlayersPanels.Length; index++)
        {
            if(!PlayersPanels[index].gameObject.activeSelf)
            {
                PlayersPanels[index].gameObject.SetActive(true);
                PlayersPanels[index].GetComponent<Image>().color = Color.white;
                Text[] elements = PlayersPanels[index].GetComponentsInChildren<Text>();
                elements[0].text = ""+(index+1);
                elements[1].text = Playername;
                elements[2].text = "" + 0;
                return index;
                
            }
        }
        // nel caso in cui non trovi un pannello Disponibile
        return -1;
    }

   
    // Bisogna Eliminare il giocatore disconesso
    public void PlayerDisconnected(int index)
    {
        if (PlayersPanels[index].gameObject.activeSelf)
        {
            PlayersPanels[index].gameObject.SetActive(false);       
        }
        
    }

    void PlayerIsDead(int index)
    {
            PlayersPanels[index].GetComponent<Image>().color=Color.cyan;
    }

}
