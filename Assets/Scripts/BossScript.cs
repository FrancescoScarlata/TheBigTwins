using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



// è la classe del movimento del boss
 public class BossScript : MonoBehaviour {
	public GameObject player;
	public float moveSpeed = 3; //move speed
	float rotationSpeed = 3; 
	public int life = 11;
	// Use this for initialization
	void Start () {
	
		//Quaternion.
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Slerp(transform.rotation,
		                                      //Perché è al contrario, altrimenti sarebbe +player.transform-transform
		                                        Quaternion.LookRotation(-player.transform.position + transform.position), rotationSpeed*Time.deltaTime);
		// essendo al contrario deve andare indietro, altrimenti sarebbe +=
		transform.position -= transform.forward * moveSpeed * Time.deltaTime;
	
	}


	void OnCollisionEnter(Collision other) {
		if(SceneManager.GetActiveScene().name=="IceBoss")
			if( other.gameObject.CompareTag("Fire")){
				Object.DestroyObject(other.gameObject);
				life--;
			}
		if(SceneManager.GetActiveScene().name == "FireBoss")
			if( other.gameObject.CompareTag("Ice")){
				Object.DestroyObject(other.gameObject);
				life--;
			}
	}	





}
