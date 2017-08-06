using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MultiProjectileSpawn : NetworkBehaviour {

    public GameObject IceBullet;
    public GameObject FireBullet;

    public GameObject Gun;
    public Transform ProjectileSpawnPoint;
    public float delay;

    private float counter;
  

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            if (Input.GetButton("Fire1") && counter > delay)
            {
                CmdFire(1);
                

                counter = 0;

            }
            if (Input.GetButton("Fire2") && counter > delay)
            {

                CmdFire(2);
                counter = 0;

            }
            counter += Time.deltaTime;
        }
        
    }

    [Command]
    void CmdFire(int typebullet)
    {
        if(typebullet==1)
        {
            Gun.GetComponent<Animation>().Play("GunShooting");
            var bullet=(GameObject) Instantiate(FireBullet, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
            NetworkServer.Spawn(bullet);
        }
        if (typebullet == 2)
        {
            Gun.GetComponent<Animation>().Play("GunShooting");
            var bullet = (GameObject)Instantiate(IceBullet, ProjectileSpawnPoint.transform.position, ProjectileSpawnPoint.transform.rotation);
            NetworkServer.Spawn(bullet);
        }
    }

}
