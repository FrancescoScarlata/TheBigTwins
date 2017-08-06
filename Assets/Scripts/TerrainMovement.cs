using UnityEngine;
using System.Collections;

public class TerrainMovement : MonoBehaviour {

	public bool up;
    public float movement;

    float ttl= 5;
	
	private Rigidbody rb;
	private float ystartposition;

	// Use this for initialization
	void Start () {
		rb= GetComponent<Rigidbody>();
		ystartposition= rb.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		ttl-= Time.deltaTime;
		
            if (up)
                rb.transform.localPosition += new Vector3 (0,movement,0)*Time.deltaTime;
            else
                rb.transform.localPosition -= new Vector3(0, movement/1.5f, 0) * Time.deltaTime;
            
		
		if (ttl<0){ 
				Object.Instantiate(this,new Vector3(this.transform.position.x, ystartposition, this.transform.position.z), 
			                   		this.transform.rotation);

			Destroy(this.gameObject);
		}

	}
		public void setUp(bool direction) {
			up=direction;
		}
    
}
