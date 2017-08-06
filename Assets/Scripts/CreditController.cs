using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreditController : MonoBehaviour {


	Rect closeButtonRect= new Rect(1920-250,0+125, 50,50);
	public Texture credits_box;
	public Texture X;
	bool Credits = false;
	public Rect window;

	// Update is called once per frame
	void Update () {
	
	}
	public void showCredits() {
		
		Credits=!Credits;
		Debug.Log(Credits);
	//	window= GUI.ModalWindow(1,window, mostracrediti, "Dai");
	}

	public void mostracrediti(int ID){
		
		GUI.DrawTexture(window, credits_box, ScaleMode.StretchToFill);
		GUI.DrawTexture(closeButtonRect, X, ScaleMode.StretchToFill);

	}

	void OnGUI(){


		if (Credits) {
			GUI.DrawTexture(window, credits_box, ScaleMode.StretchToFill);
			if (GUI.Button(closeButtonRect, X))
				Credits=!Credits;
		}
			//window= GUI.ModalWindow(1, window, mostracrediti, GUIContent.none);

	}



}
