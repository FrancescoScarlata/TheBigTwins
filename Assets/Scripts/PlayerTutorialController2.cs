using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerTutorialController2 : MonoBehaviour {
    
    public float speed;
    public float jumpSpeed;
    public float gravity;

    float realspeed;
    public int endofway;

    int count;
    int previouscount;
    int scoreused;

    CharacterController controller;
    TextTutorial tutorialadvices;

    bool buildright;
    NewTryMap mapcontroller;

    int progress;

    private Vector3 moveDirection;
    
    
    void Start()
    {
        realspeed = speed;
        controller = GetComponent<CharacterController>();
        count = 0;
        previouscount = 0;
        scoreused = 0;

        moveDirection = Vector3.zero;
        progress =(int) controller.transform.localPosition.z;
        if (SceneManager.GetActiveScene().name == "AllIn"|| SceneManager.GetActiveScene().name == "IceTutorial" || SceneManager.GetActiveScene().name == "FireTutorial")
        {
            tutorialadvices = this.GetComponent<TextTutorial>();
        }
        mapcontroller = GetComponent<NewTryMap>();
    }

    void Update()
    {
        // gestione messaggi AllIn
        if(SceneManager.GetActiveScene().name=="AllIn")
        {
            if(progress< (int)controller.transform.localPosition.z|| progress==0)
            {
                progress = (int)controller.transform.localPosition.z;
               if(progress%10==0)
                    tutorialadvices.ChangeText(progress/2);
            }
       }
        if (SceneManager.GetActiveScene().name == "IceTutorial"|| SceneManager.GetActiveScene().name == "FireTutorial")
        {
            if (progress < (int)controller.transform.localPosition.z || progress == 0)
            {
                progress = (int)controller.transform.localPosition.z;
                if (progress % 10 == 0)
                    tutorialadvices.ChangeText(progress);
            }
        }

        if (controller.isGrounded && controller.transform.position.z >= endofway)
        {
            //Magari salvare l'aver superato il livello
            SceneManager.LoadScene("TutorialMenu");           
            return;
        }

        // giocatore caduto
        if (controller.gameObject.transform.position.y < -100)
        {
            GameOver();
        }

        // Controlla se lo score è stato modificato
        if (previouscount < count)
        {
            previouscount = count;
            
        }

        // Comandi mentre è a terra
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= realspeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        count = (int)(transform.position.z) / 2;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Mouse2))
        {
            Debug.Log("fatta la pic");
            System.DateTime now = System.DateTime.Now;
            Application.CaptureScreenshot(string.Format("Screenshot_{0}{1}{2}{3}{4}{5}.png", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second));
        }

    }

    void LateUpdate()
    {

        if (buildright && previouscount % 20 == 0 && scoreused != previouscount)
        {

            mapcontroller.BuildMap(previouscount, 20);
            mapcontroller.DestroyMap(previouscount, 20);

            scoreused = previouscount;

            buildright = false;

        }
        if (previouscount % 20 != 0 && buildright == false)
            buildright = true;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ice") || other.gameObject.CompareTag("Fire"))
        {
            if (other.gameObject.CompareTag("Ice"))
            {
                realspeed = speed * 4;
            }
            else // è fuoco
               GameOver();
       }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            //	Debug.Log(realspeed);
            realspeed = speed;
        }
    }

    void GameOver()
    {
        SaveScore();
        SceneManager.LoadScene("GameOver");
    }

    void SaveScore()
    {
         PlayerPrefs.SetString("PreviousLevel", SceneManager.GetActiveScene().name);
    }
}
