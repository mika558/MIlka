using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem : MonoBehaviour
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

    //[SerializeField] private int CookieCount = 0;
    //public Text CookieCountText;
    public bool isCollected = false;

    private Collider2D mirrorCol;
    private Collider2D destructWallCol;





    void Start()
    {
        //anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        feetPoseCollider = feetPose.GetComponent<BoxCollider2D>();
        //CookieCountText.text = "" + CookieCount;

    }
    void FixedUpdate()
    {
        Move();
    }
    //public void ChangeCookieCount(int changeCount)
    //{
    //    CookieCount += changeCount;
    //    CookieCountText.text = "" + CookieCount;
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cookie"))
        {
            if (isCollected == false)
            {
                isCollected = true;
                Lvlinfo.ChangeCookieCount(1);
                Destroy(collision.gameObject);
            }

        }
        if (collision.CompareTag("Gate"))
        {
            Lvlinfo.SetGolemGateWin(true);
        }
        if (collision.CompareTag("Mirror"))
        {
            mirrorCol = collision;
        }
        if (collision.CompareTag("DestructWall"))
        {
            destructWallCol = collision;
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
        if (collision.CompareTag("DestructWall"))
        {
            destructWallCol = null;
        }
        if (collision.CompareTag("Gate"))
        {
            Lvlinfo.SetGolemGateWin(false);
        }

    }
    private void Update()
    {

        Jump();
        //Debug.Log(destructWallCol);

        isCollected = false;
        if (mirrorCol != null && Input.GetKey(keyMap.GetKeyCode("golemInteractOne")))
        {
            //Debug.Log("Mirror rotate from slimescript");
            //mirrorRot = true;
            mirrorCol.gameObject.GetComponent<Mirror>().RotateMirrorCounterClockwise();
            //mirrorScript.RotateMirror();
            //Vector2 newTransform = new Vector2(0, 100);
            //mirrorCol.gameObject.transform.position = new Vector3(0, mirrorCol.gameObject.transform.position.y + 10, 0);
        }
        if (mirrorCol != null && Input.GetKey(keyMap.GetKeyCode("golemInteractTwo")))
        {
            //Debug.Log("Mirror rotate from slimescript");
            //mirrorRot = true;
            mirrorCol.gameObject.GetComponent<Mirror>().RotateMirrorClockwise();
            //mirrorScript.RotateMirror();
            //Vector2 newTransform = new Vector2(0, 100);
            //mirrorCol.gameObject.transform.position = new Vector3(0, mirrorCol.gameObject.transform.position.y + 10, 0);
        }
        if (destructWallCol != null && Input.GetKey(keyMap.GetKeyCode("golemInteractTwo")))
        {
            destructWallCol.gameObject.GetComponent<DestructWall>().DestructThisWall();
        }
    }
    private void Move()
    {
        if (Input.GetKey(keyMap.GetKeyCode("golemLeft")))
        {
            moveInput = -1;
        }
        else if (Input.GetKey(keyMap.GetKeyCode("golemRight")))
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
    public void Flip()
    {
        facingRight = !facingRight;
        //Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
        //transform.localScale = Scaler;

        transform.Rotate(0, 180, 0);
    }
    private void Jump()
    {
        _isGrounded = Physics2D.OverlapBox(feetPose.position, feetPoseCollider.bounds.size, feetPose.rotation.z, whatIsGround);
        if (_isGrounded == true && Input.GetKeyDown(keyMap.GetKeyCode("golemJump")))
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
