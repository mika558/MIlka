using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSlime : MonoBehaviour
{
    public GameObject CannonIndicator;
    private bool Cannon = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Golem"))
        {
            Cannon = true;
            CannonIndicator.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Golem"))
        {
            Cannon = false;
            CannonIndicator.SetActive(false);
        }

    }

    public bool GetCannon()
    {
        return Cannon;
    }


}
