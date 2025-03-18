using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.5f;
    public GameObject player;

    public float lookSpeed = 5f;
    public GameObject myCam;
    public float camLock = 90;

    public int CarrotCollect = 0;

    Vector3 myLook;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myLook = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
        //What happens when player collects carrots 

        if (CarrotCollect == 5)
        {
            SceneManager.LoadScene("Good Job");
            Destroy(gameObject);
        }

        //if (CarrotCollect <= 4)
        //{
            ///SceneManager.LoadScene("Try Again");
            //Destroy(gameObject);
        //}

        //Camera 

        Vector3 playerLook = myCam.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, playerLook * 3f, Color.magenta);

        myLook += DeltaLook() * Time.deltaTime;
        if (myLook.y > camLock)
        {
            myLook.y = camLock;
        }
        else if (myLook.y < -camLock)
        {
            myLook.y = -camLock;
        }

        transform.rotation = Quaternion.Euler(0f, myLook.x, 0f);
        myCam.transform.rotation = Quaternion.Euler(-myLook.y, myLook.x, 0f);

    }
    void FixedUpdate()
    {
        Vector3 myDir = transform.TransformDirection(Dir());
        Vector3 Dir()
        {

            Vector3 moveDir = Vector3.zero;

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            moveDir = new Vector3(x, 0, z);
            return moveDir;
        }

        
    }

    Vector3 DeltaLook()
    {
        Vector3 deltaLook = Vector3.zero;
        float rotY = Input.GetAxisRaw("Mouse Y") * lookSpeed;
        float rotX = Input.GetAxisRaw("Mouse X") * lookSpeed;

        deltaLook = new Vector3(rotX, rotY, 0);
        return deltaLook;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Carrot")
        {
            Destroy(collision.gameObject);
        }
    }
}