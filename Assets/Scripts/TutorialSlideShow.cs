using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSlideShow : MonoBehaviour
{
    public GameObject nextSlide;
    public void NextSlide()
    {
        gameObject.SetActive(false);
        nextSlide.SetActive(true);
    }
    //void Start()
    //{
    //    AllSlides = GameObject.FindGameObjectsWithTag("Slide");
    //    Debug.Log(thisSlide);
    //    Debug.Log(AllSlides.Length);
    //}
    //public void NextSlide()
    //{
    //    AllSlides[thisSlide].SetActive(false);
    //    thisSlide++;
    //    if (thisSlide < AllSlides.Length)
    //    {
    //        AllSlides[thisSlide].SetActive(true);
    //    }
    //    else
    //    {

    //    }
    //}


}
