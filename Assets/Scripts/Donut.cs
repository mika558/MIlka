using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private bool isCollected = false;
    //исправляем проблему с подбором "монеток". После первого пересечения одного из коллайдеров слайма с "монеткой",
    //эта переменная указывает на то, что "монетка" собрана после первого соприкосновения

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected)
        {
            if (collision.CompareTag("Slimecat"))
            {
                isCollected = true;
                Destroy(gameObject);
            }
        }

    }
}
