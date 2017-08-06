﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapScript : MonoBehaviour {
	// tutti gli oggetti che verranno creati "randomicamente" durante il gioco
	public GameObject terreno;
	public GameObject ice;
	public GameObject fire;
	public GameObject elevator;
	public GameObject PicArt;
	public GameObject Notes;
    public GameObject[] specialparts;
    
	int lasty=0;
	int lastz=0;
	float hundredpassed = 80;

	float fireOffset =0.97f;
	float terrainOffset=2;
	Vector3 iceoffset=new Vector3 (1.5f,0.6f,-0.5f);

	Quaternion zero = new Quaternion(0,0,0,0);
	Vector3 coordinates= new Vector3(0, 0, 0);
    int level;

    void Start()
    {
        level = PlayerPrefs.GetInt("livello");
    }
	//deve costruire la mappa
	public void BuildMap(int score, int num){
		// Specifiche :
		// Riesce a salire 2.5 punti in  altezza
		// riesce a saltare fino a 3 unità in orizzontale
		
		//deve costruire la mapp

		if(coordinates.z==0)
			coordinates.z= score*2;

		int newy =0;
		int newz =0;
		int i;
		bool alreadyfire=false;

		// 200 sarebbe la distanza massima da raggiungere in campagna
		if(coordinates.z<=160*level|| SceneManager.GetActiveScene().name=="ModalitàLibera"){

            if (score == 20){
                //Parte iniziale senza altezze diverse
               // Debug.Log(num);
				for (i= 0; i<num; i++){
					//Para un muro Davanti
					Object.Instantiate(terreno, coordinates, terreno.transform.rotation);
					coordinates.z= coordinates.z +terrainOffset+ Random.Range(0,4);
                    //Debug.Log(i);
				}
			//	paintingHandler();
				return;
			}

			for (i=0; i<num; i++){
				if (coordinates.z<hundredpassed){
					// finché non si arriva al punto di cambio

					if (lastz>2){
						newz=Random.Range(0,4);
						newy=0;
					}
					else {
						newz=Random.Range(0,4);
						newy= Random.Range(-2,+2);
						while(Mathf.Abs(lasty-newy)> 2)
							newy= Random.Range(-2,+2);
					}
	
					Object.Instantiate(terreno, coordinates, terreno.transform.rotation);

					//inserisce il fuoco
					if (SceneManager.GetActiveScene().name!="IceRun" && Random.Range(1,20)>10){
						Instantiate(fire,new Vector3(coordinates.x+iceoffset.x, coordinates.y+fireOffset, coordinates.z+iceoffset.z), fire.transform.rotation);
						alreadyfire=true;
					}

					//inserisce il ghiaccio
					if (SceneManager.GetActiveScene().name != "FireRun" && Random.Range(1,20)>12&&!alreadyfire)
						Instantiate(ice,new Vector3(coordinates.x+iceoffset.x, coordinates.y+iceoffset.y, coordinates.z+iceoffset.z),ice.transform.rotation);


					coordinates.z= coordinates.z +terrainOffset+ Random.Range(0,4);
					coordinates.y=coordinates.y+ newy;
					lasty=newy;
					lastz=newz;
				}
				else {
                    Vector3 coordinatestoadd;
                    paintingHandler();
                    coordinatestoadd = randomPart(coordinates);

                    coordinates.x += coordinatestoadd.x;
                    coordinates.y += coordinatestoadd.y;
                    coordinates.z += coordinatestoadd.z;
                    hundredpassed +=80;
				}
			}
			paintingHandler();
		}
		else
			for (i=0; i< 10; i++)
				Object.Instantiate(terreno, new Vector3(coordinates.x, coordinates.y+i*2, coordinates.z+terrainOffset), terreno.transform.rotation);

	}

	//distrugge la parte superata
	public void DestroyMap(int score, int num){
		Debug.Log (""+score +" "+ num);
		if (score < num) {
		//	Debug.Log ("EscePrima");
			return;
		}
		
		GameObject [] terr= new GameObject[100];
		GameObject [] icet= new GameObject[num];
		GameObject [] firet= new GameObject[num];
        GameObject[] paints = new GameObject[20];
        GameObject[] writings = new GameObject[20];


        terr =GameObject.FindGameObjectsWithTag("Terrain");
		icet= GameObject.FindGameObjectsWithTag("Ice");
		firet = GameObject.FindGameObjectsWithTag("Fire");
        paints = GameObject.FindGameObjectsWithTag("Paints");
        writings = GameObject.FindGameObjectsWithTag("Writings");
      
        //Debug.Log (terr.Length);

        for (int i =0; i<terr.Length;i++) {
			if (i> terr.Length){
		//		Debug.Log("Esce prima");
				return;
			}
			// Toglie gli oggetti terreno normali
			if(terr[i] != null && terr[i].transform.position.z<(score*2-num)){

			//	Debug.Log("dovrebbe distruggere qualcosa");
				GameObject.Destroy(terr[i]);
                Debug.Log(i);
			}

			// Toglie gli oggetti di fuoco
			if(  i<firet.Length&& firet[i]!= null && firet[i].transform.position.z<(score*2-num))
				GameObject.Destroy(firet[i]);

			// Toglie gli oggetti di ghiaccio
			if(i<icet.Length&&icet[i]!= null&&icet[i].transform.position.z<(score*2-num))
				GameObject.Destroy(icet[i]);
            // Toglie i quadri e le scritte
            if (i < paints.Length && paints[i] != null &&    paints[i].transform.position.z < (score * 2 - num))
            {
                GameObject.Destroy(paints[i]);
                Debug.Log("ne ha distrutto uno!");
            }
          
            if (i < writings.Length &&  writings[i] != null &&  writings[i].transform.position.z < (score * 2 - num))
                GameObject.Destroy(writings[i]);
        }
	}
	
    // Inserisce le parti speciali. Da cambiare. Trasformare in oggetti a se stanti e poi cambiare il metodo
	Vector3 randomPart (Vector3 coordinates) {


        int usedpart = Random.Range(0, specialparts.Length);
        Instantiate(specialparts[usedpart], coordinates, zero);
        return specialparts[usedpart].GetComponent<LastPosition>().last_position;

    }
		                          
	void paintingHandler() {
		//Debug.Log(coordinates.y);
		GameObject quadro = GameObject.Instantiate(PicArt);
		quadro.transform.localPosition+= new Vector3(0,coordinates.y+3, coordinates.z);
		GameObject scritta = GameObject.Instantiate(Notes);
		scritta.transform.localPosition+= new Vector3(quadro.transform.position.x+1, quadro.transform.position.y+2,quadro.transform.position.z+1.6f);

	}





	public void saveScore(int score, float clock){
		// Da modificare

		if(SceneManager.GetActiveScene().name=="IceRun")
			if(PlayerPrefs.GetInt("HighscoreIceRun")<score)
				PlayerPrefs.SetInt("HighscoreIceRun",score);

		//non è più il primo livello


		if(SceneManager.GetActiveScene().name == "FireRun"){
			score+= PlayerPrefs.GetInt("LastScore");
			if(PlayerPrefs.GetInt("HighscoreFireRun")<score)
				PlayerPrefs.SetInt("HighscoreFireRun",score);
		}

		if(SceneManager.GetActiveScene().name == "ModalitàLibera")
			if(PlayerPrefs.GetInt("HighscoreFreeMode")<score)
			   PlayerPrefs.SetInt("HighscoreFreeMode",score);


		PlayerPrefs.SetInt("Score",score);
		PlayerPrefs.SetInt("Time", (int) clock);
		PlayerPrefs.SetString("PreviousLevel", SceneManager.GetActiveScene().name);
		
		//Debug.Log("ha fatto il load");
	}
	
	
	public void GameOver(int score, float clock){
		Debug.Log ( "you lose");
		saveScore(score, clock);
        SceneManager.LoadScene("GameOver");
	}



}

