using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    private float rot;
    //public Transform MirrorBase;
    void Start()
    {
        rot = transform.rotation.eulerAngles.z;
    }

    public void RotateMirrorCounterClockwise() //против часовой
    {
        //float angle = Mathf.Atan2(directLaser.y, directLaser.x) * 180 / Mathf.PI;
        //transform.rotation = Quaternion.AngleAxis(transform.rotation.z + 10f, Vector3.forward);
        //Debug.Log("Mirror rotate");
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 10.0f), Time.deltaTime * 5.0f);
        //transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
        //Quaternion rot = Quaternion.LookRotation(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z) - transform.position);
        //rot = transform.rotation.eulerAngles.z;
        rot = rot + 0.2f;
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rot), 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot);


    }
    public void RotateMirrorClockwise() // по часовой
    {
        //float angle = Mathf.Atan2(directLaser.y, directLaser.x) * 180 / Mathf.PI;
        //transform.rotation = Quaternion.AngleAxis(transform.rotation.z + 10f, Vector3.forward);
        //Debug.Log("Mirror rotate");
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, 10.0f), Time.deltaTime * 5.0f);
        //transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
        //Quaternion rot = Quaternion.LookRotation(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z) - transform.position);
        //rot = transform.rotation.eulerAngles.z;
        rot = rot - 0.2f;
                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, 0.0f, rot), 1 * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot);


    }
}
