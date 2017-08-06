using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerInBossLevel : MonoBehaviour {


	public Text clock;
	public GameObject enemy;
	public float speed;
	public float jumpSpeed;
	public float gravity;
	
	float realspeed;
	
	CharacterController controller;

	float clocktime;

	private Vector3 moveDirection;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        realspeed =speed;
		controller = GetComponent<CharacterController>();
		moveDirection = Vector3.zero;
		clocktime=PlayerPrefs.GetInt("Time");

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene("SplashScreen");

        if (controller.isGrounded && enemy.transform.position.y<=-100||enemy.gameObject.GetComponent<BossScript>().life<=1){
			SaveScore(clocktime);
			PlayerPrefs.SetInt("LastScore",PlayerPrefs.GetInt("Score"));
			PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+100);
		
			SceneManager.LoadScene("Win");
			return;
		}


		// Comandi mentre è a terra
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= realspeed;
			
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);


		if (controller.gameObject.transform.position.y <-100)
		{
			//portare al game over
			GameOver(clocktime);		
		}

		clocktime+= Time.deltaTime;

        if(clocktime>60)
        {
            clock.text = "Time : " + (int)clocktime/60 + " min " + (int)clocktime % 60 + " sec";
        }
        else
		    clock.text= "Time : "+ (int)clocktime +" sec";

		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Mouse2)) {
			Debug.Log("fatta la pic");
			System.DateTime now = System.DateTime.Now;
			Application.CaptureScreenshot(string.Format("Screenshot_{0}{1}{2}{3}{4}{5}.png",now.Year,now.Month,now.Day, now.Hour, now.Minute, now.Second));
		}

	}
	
	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Ice")||other.gameObject.CompareTag("Fire")){
			if (other.gameObject.CompareTag ("Ice")){
			//	Debug.Log(realspeed);
				realspeed=speed*4;
			}
			else
				GameOver(clocktime);	
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Ice")){
			//Debug.Log(realspeed);
			realspeed=speed;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if( other.gameObject.CompareTag("Enemy")){
			Object.DestroyObject(other.gameObject);
			GameOver(clocktime);
		}
	}

	void GameOver(float clock){
		//Debug.Log ( "you lose");
		// PlayerPrefs.SetInt("Score",); // metterò dopo score+100

		SaveScore(clock);
		SceneManager.LoadScene("GameOver");
	}

	void SaveScore(float clock) {
		PlayerPrefs.SetInt("Time", (int) clock);
		PlayerPrefs.SetString("PreviousLevel",SceneManager.GetActiveScene().name);

	}


}
