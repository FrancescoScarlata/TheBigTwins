using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	public float mousesensitivity=2;
	float rotLeftRight;
	float rotUpDown;

	void Start () {
		offset=transform.position - player. transform.position;
	}

	void Update () {	

		rotLeftRight= Input.GetAxis("Mouse X")*mousesensitivity;
		transform.Rotate(0,rotLeftRight,0);
		player.transform.Rotate(0,rotLeftRight,0);


		rotUpDown-= Input.GetAxis("Mouse Y")*mousesensitivity;
		rotUpDown=Mathf.Clamp(rotUpDown,-60,+60);
		Camera.main.transform.localRotation= Quaternion.Euler(rotUpDown,0,0);


	}

	void LateUpdate () {
		transform.position= player.transform.position+ offset;
	}
	
}
