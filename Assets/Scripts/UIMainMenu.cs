using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{ 
    public GameObject KeyMapPanel;
    public GameObject RecyclePanel;
    private bool RecyclePanelisActive;
    private float Timer = 4;

    public KeyMap keymap;

    void Update()
    {
        if (RecyclePanelisActive)
        {
            Timer -= Time.deltaTime;
        }
        if (Timer <= 0)
        {
            RecyclePanel.SetActive(false);
            RecyclePanelisActive = false;
            Timer = 4;
        }
    }

    void Start()
    {
        Time.timeScale = 1;
        if (!PlayerPrefs.HasKey("Lvl1Donut"))
        {
            PlayerPrefs.SetInt("Lvl1Donut", 0);
            PlayerPrefs.SetInt("Lvl1Cookie", 0);

            PlayerPrefs.SetInt("Lvl2Donut", 0);
            PlayerPrefs.SetInt("Lvl2Cookie", 0);

            PlayerPrefs.SetInt("Lvl3Donut", 0);
            PlayerPrefs.SetInt("Lvl3Cookie", 0);

            PlayerPrefs.SetInt("Lvl4Donut", 0);
            PlayerPrefs.SetInt("Lvl4Cookie", 0);

            PlayerPrefs.SetInt("Lvl5Donut", 0);
            PlayerPrefs.SetInt("Lvl5Cookie", 0);
            PlayerPrefs.Save();
        }
    }
    public void Recycle()
    {
        if (PlayerPrefs.HasKey("Lvl1Donut"))
        {
            PlayerPrefs.SetInt("Lvl1Donut", 0);
            PlayerPrefs.SetInt("Lvl1Cookie", 0);

            PlayerPrefs.SetInt("Lvl2Donut", 0);
            PlayerPrefs.SetInt("Lvl2Cookie", 0);

            PlayerPrefs.SetInt("Lvl3Donut", 0);
            PlayerPrefs.SetInt("Lvl3Cookie", 0);

            PlayerPrefs.SetInt("Lvl4Donut", 0);
            PlayerPrefs.SetInt("Lvl4Cookie", 0);

            PlayerPrefs.SetInt("Lvl5Donut", 0);
            PlayerPrefs.SetInt("Lvl5Cookie", 0);
        }

        if (PlayerPrefs.HasKey("level1"))
        {
            PlayerPrefs.SetString("level1", "notcomplete");
            PlayerPrefs.SetString("level2", "notcomplete");
            PlayerPrefs.SetString("level3", "notcomplete");
            PlayerPrefs.SetString("level4", "notcomplete");
            PlayerPrefs.SetString("level5", "notcomplete");

        }

        //if (PlayerPrefs.HasKey("slimecatRight"))
        //{

        //    PlayerPrefs.SetString("slimecatRight", "L");
        //    PlayerPrefs.SetString("slimecatLeft", "J");
        //    PlayerPrefs.SetString("slimecatJump", "I");
        //    PlayerPrefs.SetString("slimecatInteractOne", "O");
        //    PlayerPrefs.SetString("slimecatInteractTwo", "U");

        //    PlayerPrefs.SetString("golemRight", "D");
        //    PlayerPrefs.SetString("golemLeft", "A");
        //    PlayerPrefs.SetString("golemJump", "W");
        //    PlayerPrefs.SetString("golemInteractOne", "E");
        //    PlayerPrefs.SetString("golemInteractTwo", "Q");
        //}
        PlayerPrefs.Save();
        RecyclePanel.SetActive(true);
        RecyclePanelisActive = true;

    }
    public void OpenChangeKeyMap()
    {
        KeyMapPanel.SetActive(true);
    }
    public void CloseChangeKeyMap()
    {
        KeyMapPanel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
