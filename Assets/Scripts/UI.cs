using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject KeyMapPanel;
    public GameObject MenuPanel;
    public GameObject WinPanel;


    void Start()
    {
        Time.timeScale = 1;
        
    }

    //public void ChangeCookieCount(int changeCount)
    //{
    //    CookieCount += changeCount;
    //    CookieCountText.text = "" + CookieCount;
    //}
    public void Exit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
    }

    public void OpenMenu()
    {
        Pause();
        MenuPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        MenuPanel.SetActive(false);
        UnPause();
    }
    public void OpenChangeKeyMap()
    {
        Pause();
        MenuPanel.SetActive(false);
        KeyMapPanel.SetActive(true);
    }
    public void CloseChangeKeyMap()
    {
        MenuPanel.SetActive(true);
        KeyMapPanel.SetActive(false);
    }
    public void OpenWinPanel()
    {
        Pause();
        MenuPanel.SetActive(false);
        KeyMapPanel.SetActive(false);
        WinPanel.SetActive(true);
    }
    public void CloseLevel()
    {
       OpenWinPanel();
    }

    void OnGUI()
    {
        if (Event.current.isKey)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (MenuPanel.activeSelf == false)
                {
                    if (KeyMapPanel.activeSelf == true)
                    {
                        CloseChangeKeyMap();
                    } else
                    {
                        OpenMenu();
                    }
                } else
                {
                    CloseMenu();
                }
            }
        }
    }



}

//MenuPanel.SetActive(!MenuPanel.activeSelf);
