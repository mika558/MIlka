using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    //private Animator anim;
    //private int toSceneNum;
    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    //Debug.Log("start");
    //}

    //public void OnEnd(int sceneNum)
    //{
    //    Debug.Log("onend");
    //    toSceneNum = sceneNum;
    //    anim.SetTrigger("end");
    //}
    public void EndSceneMethod(int toSceneNum)
    {
        SceneManager.LoadScene(toSceneNum);
    }
}
