using UnityEngine;
using System.Collections;

public class SpriteScript : MonoBehaviour {

	public Sprite [] main;
	SpriteRenderer rend;
	// Use this for initialization
	void Start () {
		//	Renderer.material.mainTexture= main;
		rend = GetComponent<SpriteRenderer>();
		rend.enabled=true;
		rend.sprite= main[Random.Range(0,main.Length)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
