using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour {

	public GameObject IceBullet;
	public GameObject FireBullet;

	public GameObject Gun;
	// Use this for initialization
	public float delay;

	private float counter;
	// Update is called once per frame
	void FixedUpdate () {

		if(Input.GetButton("Fire1")&&counter>delay) {
			Gun.GetComponent<Animation>().Play ("GunShooting");
			Instantiate(FireBullet, transform.position,transform.rotation);

			counter=0;
		
		}
		if(Input.GetButton("Fire2")&&counter>delay) {
			Gun.GetComponent<Animation>().Play ("GunShooting");
			Instantiate(IceBullet, transform.position,transform.rotation);
			
			counter=0;
			
		}
		counter+= Time.deltaTime;
	}
}
