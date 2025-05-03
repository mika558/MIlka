using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvlinfo : MonoBehaviour
{
    public int thisLevel;

    [SerializeField] private int DonutCount = 0;
    public Text DonutCountText;
    public Text DonutCountTextWinMenu;


    [SerializeField] private int CookieCount = 0;
    public Text CookieCountText;
    public Text CookieCountTextWinMenu;

    [SerializeField] private bool LaserEndWin = false;
    [SerializeField] private bool SlimecatGateOnWin = false;
    [SerializeField] private bool GolemGateOnWin = false;

    public SpriteRenderer SpriteRendererLaser;
    public Sprite LaserOffSprite;
    public Sprite LaserOnSprite;

    public UI ui;

    private void Start()
    {
        Time.timeScale = 1;
        DonutCountText.text = "" + DonutCount;
        CookieCountText.text = "" + CookieCount;
    }
    void CheckWin()
    {
        if (LaserEndWin && SlimecatGateOnWin && GolemGateOnWin)
        {
            DonutCountTextWinMenu.text = DonutCount.ToString();
            CookieCountTextWinMenu.text = CookieCount.ToString();
            switch (thisLevel) { 
                case 1:
                    PlayerPrefs.SetInt("Lvl1Donut", DonutCount);
                    PlayerPrefs.SetInt("Lvl1Cookie", CookieCount);
                    PlayerPrefs.SetString("level1", "complete");
                    break;
                case 2:
                    PlayerPrefs.SetInt("Lvl2Donut", DonutCount);
                    PlayerPrefs.SetInt("Lvl2Cookie", CookieCount);
                    PlayerPrefs.SetString("level2", "complete");
                    break;
                case 3:
                    PlayerPrefs.SetInt("Lvl3Donut", DonutCount);
                    PlayerPrefs.SetInt("Lvl3Cookie", CookieCount);
                    PlayerPrefs.SetString("level3", "complete");
                    break;
                case 4:
                    PlayerPrefs.SetInt("Lvl4Donut", DonutCount);
                    PlayerPrefs.SetInt("Lvl4Cookie", CookieCount);
                    PlayerPrefs.SetString("level4", "complete");
                    break;
                case 5:
                    PlayerPrefs.SetInt("Lvl5Donut", DonutCount);
                    PlayerPrefs.SetInt("Lvl5Cookie", CookieCount);
                    PlayerPrefs.SetString("level5", "complete");
                    break;
            }

            PlayerPrefs.Save();
            ui.CloseLevel();
        }
    }
    public void ChangeDonutCount(int changeCount)
    {
        DonutCount += changeCount;
        DonutCountText.text = "" + DonutCount;
    }
    public void ChangeCookieCount(int changeCount)
    {
        CookieCount += changeCount;
        CookieCountText.text = "" + CookieCount;
    }
    public void SetLaserEndWin(bool newWin)
    {
        LaserEndWin = newWin;
        if (newWin)
        {
            SpriteRendererLaser.sprite = LaserOnSprite;
        } else
        {
            SpriteRendererLaser.sprite = LaserOffSprite;
        }
        CheckWin();
    }
    public void SetSlimecatGateWin(bool newWin)
    {
        SlimecatGateOnWin = newWin;
        CheckWin();
    }
    public void SetGolemGateWin(bool newWin)
    {
        GolemGateOnWin = newWin;
        CheckWin();
    }
}
