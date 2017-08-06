using UnityEngine;
using System.Collections;

public class FinalMusicCOntroller : MonoBehaviour {

	// Use this for initialization
	public Transform musicPrefab;
	private Object  mManager;
	
	void Start() {
		GameObject oldmusic;
		if(oldmusic=GameObject.FindGameObjectWithTag("MM")){
			Destroy(oldmusic.gameObject);
			mManager=Instantiate(musicPrefab, transform.position, Quaternion.identity);
			mManager.name=musicPrefab.name;
			DontDestroyOnLoad(mManager);
		}

		if(!GameObject.FindGameObjectWithTag("FinalMusic")){
			mManager=Instantiate(musicPrefab, transform.position, Quaternion.identity);
			mManager.name=musicPrefab.name;
			DontDestroyOnLoad(mManager);
		}
		
	}
}
