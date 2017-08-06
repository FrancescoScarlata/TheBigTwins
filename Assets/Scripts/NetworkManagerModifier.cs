using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class NetworkManagerModifier : NetworkManager {
 
    public GameObject Canvas;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            // bisogna inserire ritirato.
            SceneManager.LoadScene("SplashScreen");
        }
    }

    public override void OnStartClient(NetworkClient client)
    {
        Debug.Log("ClientStarted");
        base.OnStartClient(client);
    }


    public override void OnStopClient()
    {
        disconnectfromUI();
        base.OnStopClient();
    }

    void disconnectfromUI()
    {
        //Bisogna trovare quale dei giocatori, quello locale si è disconnesso.
        // Per farlo proviamo a vedere il giocatore che non ha alcuni elementi attivi
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i=0; i<players.Length; i++)
        {
            if(players[i].GetComponent<MultiPlayerController>().isActiveAndEnabled)
            {
                Canvas.GetComponent<CanvasUIController>().PlayerDisconnected(players[i].GetComponent<MultiPlayerController>().index);
                Debug.Log("Si e' disconnesso");
            }
        }

    }
}
