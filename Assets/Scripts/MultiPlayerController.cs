using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiPlayerController : MonoBehaviour
{
    //Player settings
    public float speed = 5;
    public float jumpSpeed = 10;
    public float gravity = 20;
    public int MouseSensibility = 2;
    public int upDownRange = 45;

    // UI settings
    GameObject UIController;
    public Camera cam;
    Text score;


    float realspeed;
    float rotUpDown;
    float rotLeftRight;

    CharacterController controller;
    int count;
    int previouscount;
    //bool buildright;
   

    //indice per la visualizzazione del panel da inserire e annesso Text di score
    public int index;
    

    private Vector3 moveDirection;

    // Use this for initialization
    void Start()
    {
        //Cursor.visible = false;
        controller = GetComponent<CharacterController>();
        realspeed = speed;
        count = 0;
        previouscount = 0;
        UIController = GameObject.FindGameObjectWithTag("Canvas");
        index = UIController.GetComponent<CanvasUIController>().NewPlayerConnected(this.name);

        GameObject[] elems = GameObject.FindGameObjectsWithTag("PlayerPanel");
        Text[] elements = elems[index].GetComponentsInChildren<Text>();
        score = elements[2];
        score.text = "Eccoci!";
    }

    // Update is called once per frame
    void Update()
    {

        //The last one alive is the winner or when they are all dead the one with more score

        // Rotation
        rotLeftRight = Input.GetAxis("Mouse X");
        transform.Rotate(0, rotLeftRight * MouseSensibility, 0);

        rotUpDown -= Input.GetAxis("Mouse Y");

        rotUpDown = Mathf.Clamp(rotUpDown, -upDownRange, +upDownRange);
        cam.transform.localRotation = Quaternion.Euler(rotUpDown * MouseSensibility, 0, 0);


        //movement
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= realspeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void LateUpdate()
    {
        count = (int)(transform.position.z) / 2;
        
        if (Input.GetKey(KeyCode.Escape))
        {
            // bisogna inserire ritirato.
            SceneManager.LoadScene("SplashScreen");
        }

        /* Da sistemare
        // Controlla se lo score è stato modificato
        if (previouscount < count)
        {
            previouscount = count;
            score.text = ScoreController.newScore(previouscount).ToString();
        }
        */
    }


    public void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Ice"))
         {
                //Debug.Log(realspeed);
                realspeed = speed * 4;
         }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            //Debug.Log(realspeed);
            realspeed = speed;
        }
    }
}
