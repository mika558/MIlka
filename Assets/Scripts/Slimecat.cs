using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slimecat : MonoBehaviour
{

    private Rigidbody2D _rb;

    public float Speed;
    public float JumpForce = 300f;

    private bool _isGrounded;
    public Transform feetPose;
    private BoxCollider2D feetPoseCollider;
    public LayerMask whatIsGround;

    private float moveInput;
    private Animator anim;
    private bool facingRight = true;


    public KeyMap keyMap;
    public lvlinfo Lvlinfo; 
    public Mirror mirrorScript;
    //public InteractSlime interactSlime;


    public bool isCollected = false;

    //public GameObject CannonIndicator;
    //private bool cannon = false;

    //public GameObject Bullet;
    //public GameObject CannonPosition;

    private Collider2D mirrorCol;
 

    private Collider2D swipeMoveWallCol;
    public bool sensorActive = true;
    private Collider2D swipeMoveWallColGreen;
    public bool sensorActiveGreen = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Donut"))
        {
            if (isCollected == false)
            {
                isCollected = true;
                Lvlinfo.ChangeDonutCount(1);
                Destroy(collision.gameObject);
            }
        }

        //if (collision.CompareTag("Golem"))
        //{
        //    cannon = true;
        //    CannonIndicator.SetActive(true);
        //}
        if (collision.CompareTag("Gate"))
        {
            Lvlinfo.SetSlimecatGateWin(true);
        }
        if (collision.CompareTag("Mirror"))
        {
            mirrorCol = collision;
        }
        if (collision.CompareTag("SwipeMoveWall"))
        {
            swipeMoveWallCol = collision;
        }
        if (collision.CompareTag("SwipeMoveWallGreen"))
        {
            swipeMoveWallColGreen = collision;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        //if (collision.CompareTag("Golem"))
        //{
        //    cannon = false;
        //    CannonIndicator.SetActive(false);
        //}
        if (collision.CompareTag("Mirror"))
        {
            mirrorCol = null;
        }
        if (collision.CompareTag("SwipeMoveWall"))
        {
            swipeMoveWallCol = null;
        }
        if (collision.CompareTag("SwipeMoveWallGreen"))
        {
            swipeMoveWallColGreen = null;
        }
        if (collision.CompareTag("Gate"))
        {
            Lvlinfo.SetSlimecatGateWin(false);
        }

    }
    void Start()
    {
        //anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        feetPoseCollider = feetPose.GetComponent<BoxCollider2D>();

    }

    void FixedUpdate()
    {
        Move();
    }


    void Update()
    {
        Debug.Log(mirrorCol);
        Jump();
        isCollected = false;
        //Cannon();
        if (mirrorCol != null && Input.GetKey(keyMap.GetKeyCode("slimecatInteractOne")))
        {
            //Debug.Log("Mirror rotate from slimescript");
            //mirrorRot = true;
            mirrorCol.gameObject.GetComponent<Mirror>().RotateMirrorCounterClockwise();
            //mirrorScript.RotateMirror();
            //Vector2 newTransform = new Vector2(0, 100);
            //mirrorCol.gameObject.transform.position = new Vector3(0, mirrorCol.gameObject.transform.position.y + 10, 0);
        }
        if (mirrorCol != null && Input.GetKey(keyMap.GetKeyCode("slimecatInteractTwo")))
        {
            mirrorCol.gameObject.GetComponent<Mirror>().RotateMirrorClockwise();
        }
        Debug.Log(swipeMoveWallCol);
        //Debug.Log(sensorActive);
        if (swipeMoveWallCol != null && Input.GetKey(keyMap.GetKeyCode("slimecatInteractTwo")) && sensorActive)
        {
            sensorActive = false;
            swipeMoveWallCol.gameObject.GetComponent<Sensor>().MoveWallsMethod();
        }

        if (swipeMoveWallColGreen != null && Input.GetKey(keyMap.GetKeyCode("slimecatInteractTwo")) && sensorActiveGreen)
        {
            sensorActiveGreen = false;
            swipeMoveWallColGreen.gameObject.GetComponent<SensorGreen>().MoveWallsMethod();
        }

    }
    public void ChangeSensorActive()
    {
        sensorActive = true;
    }
    public void ChangeSensorActiveGreen()
    {
        sensorActiveGreen = true;
    }


    //private void Cannon()
    //{
    //    if (cannon && Input.GetKey(keyMap.GetKeyCode("cannon")))
    //    {
    //        Instantiate(Bullet);
    //        Bullet.transform.position = CannonPosition.transform.position;
    //        Destroy(gameObject);
    //    }
    //}



    void Move()
    {
        if (Input.GetKey(keyMap.GetKeyCode("slimecatLeft")))
        {
            moveInput = -1;
        }
        else if (Input.GetKey(keyMap.GetKeyCode("slimecatRight")))
        {
            moveInput = 1;
        }
        else
        {
            moveInput = 0;
        }


        _rb.velocity = new Vector2(moveInput * Speed, _rb.velocity.y);
        if (_rb.velocity.x != 0)
        {
            //anim.SetBool("isRun", true);

            if (facingRight == false && _rb.velocity.x < 0)
            {
                Flip();
            }
            else if (facingRight == true && _rb.velocity.x > 0)
            {
                Flip();
            }
        }
        else
        {
            //anim.SetBool("isRun", false);
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        //Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
        //transform.localScale = Scaler;

        transform.Rotate(0, 180, 0);
    }
    void Jump()
    {
        _isGrounded = Physics2D.OverlapBox(feetPose.position, feetPoseCollider.bounds.size, feetPose.rotation.z, whatIsGround);
        if (_isGrounded == true && Input.GetKeyDown(keyMap.GetKeyCode("slimecatJump")))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
        }
        if (_isGrounded == true)
        {
            //anim.SetBool("isJump", false);
        }
        else
        {
            //anim.SetBool("isJump", true);
        }
    }

}
