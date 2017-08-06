using UnityEngine;
using System.Collections;

public class BossIceTerrainScript : MonoBehaviour {

	Vector3 terrIceOffset= new Vector3( -1.5f, 1.7f, 2.5f);



	// Update is called once per frame
	void Update () {
	


	}


	void OnTriggerEnter(Collider other){

		if (other.CompareTag("Player")|| other.CompareTag("Enemy")||other.CompareTag("Ice"))
			return;

		GameObject [] terr = GameObject.FindGameObjectsWithTag("Terrain");

	//	Debug.Log("this : "+transform.position);
	//	Debug.Log("terr.length : "+ terr.Length);
		//Debug.Log("This : "+transform.position);
		for (int i=0; i<terr.Length; i++){
			//Debug.Log("Terr "+i+ " : "+terr[i].transform.position);
			// terreno normale
			if (terr[i].transform.position.x== transform.position.x+terrIceOffset.x && 
			    terr[i].transform.position.z== transform.position.z+terrIceOffset.z){

				//Debug.Log("trovato al tentativo "+i+ " ma ce ne sono ancora "+ terr.Length);
				Destroy (other.gameObject);
				Destroy(terr[i].gameObject);
				Destroy(this.gameObject);
				return;
			}

		}
		Debug.Log("non ha trovato l'elemento da aliminare");

	}
}
