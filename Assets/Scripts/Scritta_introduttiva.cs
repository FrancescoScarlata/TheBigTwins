using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scritta_introduttiva : MonoBehaviour {

	float time =0;


	// Update is called once per frame
	void Update () {
		time+= Time.deltaTime;

		if (time > 5)
			this.gameObject.SetActive(false);

	}
}
