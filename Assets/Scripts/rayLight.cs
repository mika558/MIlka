using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayLight : MonoBehaviour
{
    void Start()
    {
        rayLightManager.instance.AddLaser(this);   
    }













    //public Transform originalObject;
    //public Transform reflectedObject;
    //public Transform mirrorObject;

    //void Update()
    //{
    //    // Makes the reflected object appear opposite of the original object,
    //    // mirrored along the z-axis of the world
    //    reflectedObject.position = Vector3.Reflect(originalObject.position, mirrorObject.normal);
    //}

    //private void Start()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
    //    {
    //        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
    //        Debug.Log("Did Hit");
    //    }

    //}
    //void Update()
    //{
    //    Raycast(transform.position, transform.right); // ѕередаю начало и направлени€ лазера в метод
    //}
    //private void Raycast(Vector2 origin, Vector2 direction)
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(origin, direction, 100);
    //    Debug.DrawRay(origin, direction * hit.distance, Color.red);

    //    if (hit.collider.tag == "Mirror")
    //    {
    //        Vector2 newOrigin = hit.point; // —оздаю переменную дл€ точки, откуда будет лететь отражЄнный луч
    //        Vector2 newDirection = ??? // —оздаю переменную дл€ направлени€ его направлени€
    //        Raycast(newOrigin, newDirection);
    //        /* ¬ метод Raycast должны быть переданы точка, откуда будет лететь отражЄнный луч
    //        » направление, в которе он должен отразитьс€ */
    //    }
    //}

    //public GameObject Start;

    //void Update()
    //{
    //    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right);
    //    if (hit.collider != null)
    //    {
    //        //Draws a line from the normal of the object
    //        Debug.DrawLine(transform.position, Vector3.right, Color.red, 20.0f);
    //        Debug.DrawLine(transform.position, hit.normal, Color.yellow, 10.0f);
    //    }
    //}
}
