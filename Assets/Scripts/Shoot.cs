using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public float speed = 1f;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		transform.Translate(0,0,speed);
        
		Destroy(this.gameObject, 2);
	}




	void OnTriggerEnter(Collider other) {
	
		if (other.gameObject.CompareTag("Ice")&&this.gameObject.CompareTag("Fire")){
			Object.DestroyObject(other.gameObject);
			Destroy(this.gameObject);
			return;
		}
		if (other.gameObject.CompareTag("Fire")&&this.gameObject.CompareTag("Ice")){
			Object.DestroyObject(other.gameObject);
			Destroy(this.gameObject);
			return;
		}
        /*
        if(this.gameObject.CompareTag("Fire")&&other.gameObject.tag=="Player")
        {
            Debug.Log("colpisce un giocatore");
            var health = other.GetComponent<HealthController>();
            if(health!=null)
            {
                health.TakeDamage(100);
            }
            Destroy(gameObject);
        }
        */
	}
    void OnCollisionEnter(Collision coll)
    {
        
        if(this.gameObject.CompareTag("Fire")&&coll.gameObject.tag=="Player")
        {
            Debug.Log("colpisce un giocatore");
            var health = coll.gameObject.GetComponent<HealthController>();
            if(health!=null)
            {
                health.TakeDamage(100);
            }
            Destroy(gameObject);
        }
        
    }

}
