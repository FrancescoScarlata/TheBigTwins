using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

// Necessario per il multiplayer
// serve per togliere gli oggetti dai giocatori non locali in maniera tale da non avere problemi con camere e 
// audio listener di altri giocatori e quella di inizio livello
// Serve anche per togliere le componenti che altrimenti verrebbero utilizzate come gli script del controller
public class PlayerSetup : NetworkBehaviour {
    [SerializeField]
    Behaviour[] componentsToDisable;
    Camera sceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i=0; i<componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
                
        }
    }

    void OnDisable()
    {
        if (sceneCamera!= null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }

}
