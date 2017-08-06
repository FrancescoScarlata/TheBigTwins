using UnityEngine;
using System.Collections;

public class FireBossTerrainScript : MonoBehaviour {

	// Use this for initialization
	Vector3 terrFireOffset= new Vector3( 1.5f, 0.84f, -0.1f);
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		
		if (other.CompareTag("Enemy")||other.CompareTag("Fire"))
			return;
		
		GameObject [] terr = GameObject.FindGameObjectsWithTag("Terrain");

			Debug.Log("terr.length : "+ terr.Length);
		Debug.Log("This : "+transform.position);
		for (int i=0; i<terr.Length; i++){

			Debug.Log("Terr x "+i+ " : "+terr[i].transform.position.x+ " Terr z   : "+terr[i].transform.position.z+
			          " e this x,z "+ (transform.position.x+terrFireOffset.x)+"  "+ (transform.position.z+terrFireOffset.z));
			// terreno fuoco
			if (terr[i].transform.position.x== (transform.position.x+terrFireOffset.x) && 
			    terr[i].transform.position.z== (transform.position.z)){

				Destroy(other.gameObject);
				Destroy(terr[i].gameObject);
				Destroy(this.gameObject);
				return;
			}
			
		}
		Debug.Log("non ha trovato l'elemento da aliminare");
		
	}
}

