using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructWall : MonoBehaviour
{
    public void DestructThisWall() 
    {
        Destroy(transform.parent.gameObject);
    }
}
