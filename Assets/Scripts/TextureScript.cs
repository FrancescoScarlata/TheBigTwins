using UnityEngine;
using System.Collections;

// Per mettere le immagini nei plane
public class TextureScript : MonoBehaviour {


	public Texture [] main;
	Renderer rend;
	// Use this for initialization
	void Start () {
	//	Renderer.material.mainTexture= main;
		rend = GetComponent<Renderer>();
		rend.enabled=true;
		rend.material.mainTexture= main[Random.Range(0,main.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	

	}




}
