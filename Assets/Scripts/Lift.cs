using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D _rb;

    public Transform upPoint;
    public Transform downPoint;
    public Transform LiftTrans;

    private int moveDirect = -1;

    public float stopTimer = 3;
    private float stopTimerCount = 0;

    void Start()
    {
        //Debug.Log(upPoint.position.y);
        //Debug.Log(downPoint.position.y);
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Debug.Log(LiftTrans.position.y);

        if (moveDirect == -1)
        {
            if (LiftTrans.position.y <= downPoint.position.y)
            {
                _rb.velocity = new Vector2(0, 0);
                if (stopTimerCount >= stopTimer)
                {
                    moveDirect = 1;
                    stopTimerCount = 0;
                } 
                else
                {
                    stopTimerCount += Time.deltaTime;
                }
                
                //Debug.Log(moveDirect);

            }
            else
            {
                //_rb.velocity = new Vector2(moveDirect * Speed, _rb.velocity.y);
                _rb.velocity = (downPoint.position - LiftTrans.position).normalized * moveSpeed;
            }
        }
        if (moveDirect == 1)
        {
            if (LiftTrans.position.y >= upPoint.position.y)
            {
                _rb.velocity = new Vector2(0, 0);

                if (stopTimerCount >= stopTimer)
                {
                    moveDirect = -1;
                    stopTimerCount = 0;
                }
                else
                {
                    stopTimerCount += Time.deltaTime;
                }
                //Debug.Log(moveDirect);
            }
            else
            {
                //_rb.velocity = new Vector2(moveDirect * Speed, _rb.velocity.y);
                _rb.velocity = (upPoint.position - LiftTrans.position).normalized * moveSpeed;
            }
        }
    }

}
