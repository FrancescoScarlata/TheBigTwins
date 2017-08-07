using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public Text score;
	public Text clock;
    

    public float speed;
	public float jumpSpeed;
	public float gravity;

	float realspeed;
    
	CharacterController controller;
	int count;
	int previouscount;
	private Vector3 moveDirection;

	int scoreused;
	bool buildright;
	MapScript mapcontroller;
	float clocktime;
	public int difficulty=1;

	// Use this for initialization
	void Start () {
        Cursor.visible= false;
        realspeed =speed;
		controller = GetComponent<CharacterController>();
		count =0;
		previouscount=0;
		scoreused=0;

		buildright= true;
		moveDirection = Vector3.zero;
		mapcontroller= GetComponent<MapScript>();
        difficulty = PlayerPrefs.GetInt("livello");
        if (difficulty == 0)
        {
            difficulty = 2;
            PlayerPrefs.SetInt("livello",2);
        }

		if (PlayerPrefs.GetInt("FirstTimeChampain")==0||PlayerPrefs.GetInt("FirstTimeFreeMode")==0){
			if(PlayerPrefs.GetInt("FirstTimeChampain")==0)
				PlayerPrefs.SetInt("FirstTimeChampain",1);

			if (PlayerPrefs.GetInt("FirstTimeFreeMode")==0)
				PlayerPrefs.SetInt("FirstTimeFreeMode",1);

			clocktime=0;
		}
		else
			clocktime=PlayerPrefs.GetInt("Time");
	}
	
	// Update is called once per frame
	void Update () {

		// Come finisce la partita
		if (controller.isGrounded && SceneManager.GetActiveScene().name !="ModalitàLibera" && previouscount>=80*difficulty){
			mapcontroller.saveScore(previouscount, clocktime);

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

		count=(int)(transform.position.z)/2;
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

		// Controlla se lo score è stato modificato
		if(previouscount<count){
			previouscount=count;
			score.text=ScoreController.newScore(previouscount).ToString();
		}

		if (controller.gameObject.transform.position.y <-100)
		{
			//portare al game over
			mapcontroller.GameOver(previouscount, clocktime);

		}
		clocktime+= Time.deltaTime;

        if (clocktime > 60)
        {
            clock.text = "Time : " + (int)clocktime / 60 + " min "+ (int)clocktime % 60 + " sec";
        }
        else
            clock.text = "Time : " + (int)clocktime + " sec";

        if (Input.GetKey (KeyCode.LeftShift) && Input.GetKeyDown (KeyCode.Mouse2)) {
			Debug.Log("fatta la pic");
			System.DateTime now = System.DateTime.Now;
			ScreenCapture.CaptureScreenshot(string.Format("Screenshot_{0}{1}{2}{3}{4}{5}.png",now.Year,now.Month,now.Day, now.Hour, now.Minute, now.Second));
		}
	}

	// serve per fare lo spawn dei cubi e per la loro distruzione
	void LateUpdate() {
        if (Input.GetKey(KeyCode.Escape))
           SceneManager.LoadScene("SplashScreen");

        if (buildright && previouscount%20==0&& scoreused!=previouscount){

			mapcontroller.BuildMap(previouscount, 20);
			mapcontroller.DestroyMap(previouscount, 20);

			scoreused=previouscount;

			buildright=false;

		}
		if (previouscount%20!=0 && buildright==false)
			buildright= true;

	}

	public void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Ice")||other.gameObject.CompareTag("Fire")){
			if (other.gameObject.CompareTag ("Ice")){
				//Debug.Log(realspeed);
				realspeed=speed*4;
			}
			else
				mapcontroller.GameOver(previouscount, clocktime);

		}
	}

	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.CompareTag("Ice")){
			//Debug.Log(realspeed);
			realspeed=speed;
		}
	}




}