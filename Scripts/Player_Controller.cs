using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 10;
    private float horizontalInput;
    private float verticalInput;
    private float xRange = 25;
    private float zRange = 14;
    //private float jumpForce = 10;
    //private float gravityModifier;
    //public bool isOnGround = true;
    public bool isAttacking = false;
    public bool isMining = false;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
        
        //check for attacking
        if(Input.GetKey(KeyCode.Z) && !isMining)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        //check for mining
        if(Input.GetKey(KeyCode.X) && !isAttacking)
        {
            isMining = true;
        }
        else
        {
            isMining = false;
        }
    }

    //Moves Player based on Input
    void MovePlayer()
    {
        //get player input
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //move player
        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        transform.rotation = Quaternion.LookRotation(movement);
        transform.Translate(movement * Time.deltaTime * speed, Space.World);
        
        //turns model to match movement

    }

    //Player Restricted Area
    void ConstrainPlayerPosition()
    {
        //handle player boundries
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with enemy");
            if (isAttacking)
            {
                Debug.Log("Attack!!!");
                Destroy(collision.gameObject);
            }

        }
        if (collision.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Rocks Ahead");
            if (isMining)
            {
                Debug.Log("DESTROYED1");
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }

}
