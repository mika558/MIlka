using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class KeyMap : MonoBehaviour
{
    private Dictionary<string, KeyCode> keyMapCodes = new Dictionary<string, KeyCode>();
    //public KeyMapCodes keymapcodes;

    [Header("SlimeCat")]
    public GameObject RightSlimecatBtn;
    public GameObject LeftSlimecatBtn;
    public GameObject JumpSlimecatBtn;

    public GameObject InteractOneSlimecatBtn;
    public GameObject InteractTwoSlimecatBtn;



    [Header("Golem")]
    public GameObject RightGolemBtn;
    public GameObject LeftGolemBtn;
    public GameObject JumpGolemBtn;

    public GameObject InteractOneGolemBtn;
    public GameObject InteractTwoGolemBtn;


    //[Header("General")]
    //public GameObject CannonBtn;
    //public TextAsset keyMapText;
    //private string[] keyscodestext;


    private string changeBtn = "none";
    private KeyCode oldKeyCode;

    public  GameObject RecyclePanel;
    private bool RecyclePanelisActive = false;
    private float Timer = 4f;

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
            Timer = 4f;
        }
    }

    private void Start()
    {
        //keyMapCodes = keymapcodes.keyMapCodes;
        //string keyMapTextOutSpace = keyMapText.text.Replace(" ", "");
        //string[] keyscodestext = keyMapTextOutSpace.Split(';');
        //foreach (string key in keyscodestext)
        //{
        //    string[] keyparametres = key.Split(',');
        //    keyMapCodes.Add(keyparametres[0].ToString(), (KeyCode)Enum.Parse(typeof(KeyCode), keyparametres[1]));

        //}
        if (!PlayerPrefs.HasKey("slimecatRight"))
        {
            //PlayerPrefs.SetString("slimecatRight", "L");
            //PlayerPrefs.SetString("slimecatLeft", "J");
            //PlayerPrefs.SetString("slimecatJump", "I");
            //PlayerPrefs.SetString("slimecatInteractOne", "O");
            //PlayerPrefs.SetString("slimecatInteractTwo", "U");

            //PlayerPrefs.SetString("golemRight", "D");
            //PlayerPrefs.SetString("golemLeft", "A");
            //PlayerPrefs.SetString("golemJump", "W");
            //PlayerPrefs.SetString("golemInteractOne", "E");
            //PlayerPrefs.SetString("golemInteractTwo", "Q");

            DefaultKeyCodes();
        } else
        {
            ReMakeDictionary();
        }
        //keyMapCodes.Add("slimecatRight", KeyCode.L);
        //keyMapCodes.Add("slimecatRight", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatRight")));
        //keyMapCodes.Add("slimecatLeft", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatLeft")));
        //keyMapCodes.Add("slimecatJump", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatJump")));
        //keyMapCodes.Add("slimecatInteractOne", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatInteractOne")));
        //keyMapCodes.Add("slimecatInteractTwo", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatInteractTwo")));


        //keyMapCodes.Add("golemRight", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemRight")));
        //keyMapCodes.Add("golemLeft", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemLeft")));
        //keyMapCodes.Add("golemJump", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemJump")));
        //keyMapCodes.Add("golemInteractOne", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemInteractOne")));
        //keyMapCodes.Add("golemInteractTwo", (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemInteractTwo")));


        //keyMapCodes.Add("cannon", KeyCode.E);

        UploadButtonText();
    }
    private void ReMakeDictionary()
    {
        keyMapCodes["slimecatRight"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatRight"));
        keyMapCodes["slimecatLeft"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatLeft"));
        keyMapCodes["slimecatJump"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatJump"));
        keyMapCodes["slimecatInteractOne"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatInteractOne"));
        keyMapCodes["slimecatInteractTwo"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slimecatInteractTwo"));


        keyMapCodes["golemRight"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemRight"));
        keyMapCodes["golemLeft"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemLeft"));
        keyMapCodes["golemJump"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemJump"));
        keyMapCodes["golemInteractOne"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemInteractOne"));
        keyMapCodes["golemInteractTwo"] = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("golemInteractTwo"));
    }
    public void DefaultKeyCodes()
    {
        PlayerPrefs.SetString("slimecatRight", "L");
        PlayerPrefs.SetString("slimecatLeft", "J");
        PlayerPrefs.SetString("slimecatJump", "I");
        PlayerPrefs.SetString("slimecatInteractOne", "O");
        PlayerPrefs.SetString("slimecatInteractTwo", "U");

        PlayerPrefs.SetString("golemRight", "D");
        PlayerPrefs.SetString("golemLeft", "A");
        PlayerPrefs.SetString("golemJump", "W");
        PlayerPrefs.SetString("golemInteractOne", "E");
        PlayerPrefs.SetString("golemInteractTwo", "Q");

        PlayerPrefs.Save();
        if (RecyclePanel != null)
        {
            Debug.Log("panel");
            RecyclePanel.SetActive(true);
            RecyclePanelisActive = true;
        }
        ReMakeDictionary();
        UploadButtonText();
    }
    public KeyCode GetKeyCode(string keyCodeName)
    {
        return keyMapCodes[keyCodeName];
    }
    private void UploadButtonText()
    {
        //slimecat
        RightSlimecatBtn.GetComponentInChildren<Text>().text = keyMapCodes["slimecatRight"].ToString();
        LeftSlimecatBtn.GetComponentInChildren<Text>().text = keyMapCodes["slimecatLeft"].ToString();
        JumpSlimecatBtn.GetComponentInChildren<Text>().text = keyMapCodes["slimecatJump"].ToString();

        InteractOneSlimecatBtn.GetComponentInChildren<Text>().text = keyMapCodes["slimecatInteractOne"].ToString();
        InteractTwoSlimecatBtn.GetComponentInChildren<Text>().text = keyMapCodes["slimecatInteractTwo"].ToString();

        //golem
        RightGolemBtn.GetComponentInChildren<Text>().text = keyMapCodes["golemRight"].ToString();
        LeftGolemBtn.GetComponentInChildren<Text>().text = keyMapCodes["golemLeft"].ToString();
        JumpGolemBtn.GetComponentInChildren<Text>().text = keyMapCodes["golemJump"].ToString();

        InteractOneGolemBtn.GetComponentInChildren<Text>().text = keyMapCodes["golemInteractOne"].ToString();
        InteractTwoGolemBtn.GetComponentInChildren<Text>().text = keyMapCodes["golemInteractTwo"].ToString();


        //other
        //CannonBtn.GetComponentInChildren<Text>().text = keyMapCodes["cannon"].ToString();

    }
    public void ChangeKeyMap(string str)
    {
        if (changeBtn == "none")
        {
            changeBtn = str;
        }
    }
    private void ChangeBtn(GameObject Btn, string keyCode)
    {
        Btn.GetComponentInChildren<Text>().text = "...";
        if (Event.current.keyCode != KeyCode.None)
        {
            oldKeyCode = keyMapCodes[keyCode];
            keyMapCodes[keyCode] = Event.current.keyCode;
            //
            PlayerPrefs.SetString(keyCode, Event.current.keyCode.ToString());
            foreach (KeyValuePair<string, KeyCode> code in keyMapCodes)
            {
                if (keyMapCodes[keyCode] == code.Value && code.Key != keyCode)
                {
                    keyMapCodes[code.Key] = oldKeyCode;
                    //
                    PlayerPrefs.SetString(code.Key, oldKeyCode.ToString());
                    return;
                }
            }
            PlayerPrefs.Save();
            UploadButtonText();
            changeBtn = "none";
        }
    }
    void OnGUI() //Update ?
    {
        //Debug.Log(changeBtn);
        if (changeBtn != "none")
        {
            switch (changeBtn)
            {
                case "slimecatRight":
                    ChangeBtn(RightSlimecatBtn, "slimecatRight");
                    break;
                case "slimecatLeft":
                    //LeftSlimecatBtn.GetComponentInChildren<Text>().text = "...";
                    //if (Event.current.keyCode != KeyCode.None)
                    //{
                    //    oldKeyCode = keyMapCodes["slimecatLeft"];
                    //    keyMapCodes["slimecatLeft"] = Event.current.keyCode;
                    //    foreach (KeyValuePair<string, KeyCode> code in keyMapCodes)
                    //    {

                    //        if (keyMapCodes["slimecatLeft"] == code.Value && code.Key != "slimecatLeft")
                    //        {
                    //            keyMapCodes[code.Key] = oldKeyCode;
                    //            return;
                    //        }
                    //    }
                    //    UploadButtonText();
                    //    changeBtn = "none";
                    //}
                    ChangeBtn(LeftSlimecatBtn, "slimecatLeft");
                    break;
                case "slimecatJump":
                    //JumpSlimecatBtn.GetComponentInChildren<Text>().text = "...";
                    //if (Event.current.keyCode != KeyCode.None)
                    //{
                    //    oldKeyCode = keyMapCodes["slimecatJump"];
                    //    keyMapCodes["slimecatJump"] = Event.current.keyCode;
                    //    foreach (KeyValuePair<string, KeyCode> code in keyMapCodes)
                    //    {

                    //        if (keyMapCodes["slimecatJump"] == code.Value && code.Key != "slimecatJump")
                    //        {
                    //            keyMapCodes[code.Key] = oldKeyCode;
                    //            return;
                    //        }
                    //    }
                    //    UploadButtonText();
                    //    changeBtn = "none";
                    //}
                    ChangeBtn(JumpSlimecatBtn, "slimecatJump");
                    break;
                case "slimecatInteractOne":
                    ChangeBtn(InteractOneSlimecatBtn, "slimecatInteractOne");
                    break;
                case "slimecatInteractTwo":
                    ChangeBtn(InteractTwoSlimecatBtn, "slimecatInteractTwo");
                    break;

                case "golemRight":
                    //RightGolemBtn.GetComponentInChildren<Text>().text = "...";
                    //if (Event.current.keyCode != KeyCode.None)
                    //{
                    //    oldKeyCode = keyMapCodes["golemRight"];
                    //    keyMapCodes["golemRight"] = Event.current.keyCode;
                    //    foreach (KeyValuePair<string, KeyCode> code in keyMapCodes)
                    //    {
                    //        if (keyMapCodes["golemRight"] == code.Value && code.Key != "golemRight")
                    //        {
                    //            keyMapCodes[code.Key] = oldKeyCode;
                    //            return;
                    //        }
                    //    }
                    //    UploadButtonText();
                    //    changeBtn = "none";
                    //}
                    ChangeBtn(RightGolemBtn, "golemRight");
                    break;
                case "golemLeft":
                    //LeftGolemBtn.GetComponentInChildren<Text>().text = "...";
                    //if (Event.current.keyCode != KeyCode.None)
                    //{
                    //    oldKeyCode = keyMapCodes["golemLeft"];
                    //    keyMapCodes["golemLeft"] = Event.current.keyCode;
                    //    foreach (KeyValuePair<string, KeyCode> code in keyMapCodes)
                    //    {

                    //        if (keyMapCodes["golemLeft"] == code.Value && code.Key != "golemLeft")
                    //        {
                    //            keyMapCodes[code.Key] = oldKeyCode;
                    //            return;
                    //        }
                    //    }
                    //    UploadButtonText();
                    //    changeBtn = "none";
                    //}
                    ChangeBtn(LeftGolemBtn, "golemLeft");
                    break;
                case "golemJump":
                    //JumpGolemBtn.GetComponentInChildren<Text>().text = "...";
                    //if (Event.current.keyCode != KeyCode.None)
                    //{
                    //    oldKeyCode = keyMapCodes["golemJump"];
                    //    keyMapCodes["golemJump"] = Event.current.keyCode;
                    //    foreach (KeyValuePair<string, KeyCode> code in keyMapCodes)
                    //    {

                    //        if (keyMapCodes["golemJump"] == code.Value && code.Key != "golemJump")
                    //        {
                    //            keyMapCodes[code.Key] = oldKeyCode;
                    //            return;
                    //        }
                    //    }
                    //    UploadButtonText();
                    //    changeBtn = "none";
                    //}
                    ChangeBtn(JumpGolemBtn, "golemJump");
                    break;
                case "golemInteractOne":
                    ChangeBtn(InteractOneGolemBtn, "golemInteractOne");
                    break;
                case "golemInteractTwo":
                    ChangeBtn(InteractTwoGolemBtn, "golemInteractTwo");
                    break;
                default:
                    Debug.Log("Ошибка. Такой кнопки нет");
                    break;
            }
        }
    }



}
