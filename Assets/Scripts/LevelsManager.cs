using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsManager : MonoBehaviour
{
    public GameObject Lvl1Wrap;
    public GameObject Lvl2Wrap;
    public GameObject Lvl3Wrap;
    public GameObject Lvl4Wrap;
    public GameObject Lvl5Wrap;

    public GameObject Lvl1OffBtn;
    public GameObject Lvl1OnBtn;

    public GameObject Lvl2OffBtn;
    public GameObject Lvl2OnBtn;

    public GameObject Lvl3OffBtn;
    public GameObject Lvl3OnBtn;

    public GameObject Lvl4OffBtn;
    public GameObject Lvl4OnBtn;

    public GameObject Lvl5OffBtn;
    public GameObject Lvl5OnBtn;

    private GameObject btn;


    public Text DonutCountText;
    public int DonutCount;
    public Text CookieCountText;
    public int CookieCount;


    private void Start()
    {
        Time.timeScale = 1;
        if (!PlayerPrefs.HasKey("level1"))
        {
            PlayerPrefs.SetString("level1", "notcomplete");
            PlayerPrefs.SetString("level2", "notcomplete");
            PlayerPrefs.SetString("level3", "notcomplete");
            PlayerPrefs.SetString("level4", "notcomplete");
            PlayerPrefs.SetString("level5", "notcomplete");

            PlayerPrefs.Save();

        }

        CookieCount = PlayerPrefs.GetInt("Lvl1Cookie") + PlayerPrefs.GetInt("Lvl2Cookie") + PlayerPrefs.GetInt("Lvl3Cookie") + PlayerPrefs.GetInt("Lvl4Cookie") + PlayerPrefs.GetInt("Lvl5Cookie");
        DonutCount = PlayerPrefs.GetInt("Lvl1Donut") + PlayerPrefs.GetInt("Lvl2Donut") + PlayerPrefs.GetInt("Lvl3Donut") + PlayerPrefs.GetInt("Lvl4Donut") + PlayerPrefs.GetInt("Lvl5Donut");
        DonutCountText.text = CookieCount.ToString() + " / 22";
        CookieCountText.text = DonutCount.ToString() + " / 22";

        Destroy(Lvl5Wrap.GetComponent<Transform>().GetChild(0).gameObject);
        //GameObject btn;
        if (PlayerPrefs.GetString("level5") == "complete")
        {
            btn = Instantiate(Lvl5OnBtn, Lvl5Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetString("level4") == "notcomplete")
        {
            Debug.Log("4notcpmplete");

            btn = Instantiate(Lvl5OffBtn, Lvl5Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("level4") == "complete" && PlayerPrefs.GetString("level5") == "notcomplete")
        {
            btn = Instantiate(Lvl5OffBtn, Lvl5Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        btn.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);



        Destroy(Lvl4Wrap.GetComponent<Transform>().GetChild(0).gameObject);
        if (PlayerPrefs.GetString("level4") == "complete")
        {
            btn = Instantiate(Lvl4OnBtn, Lvl4Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetString("level3") == "notcomplete")
        {
            Debug.Log("3notcpmplete");

            btn = Instantiate(Lvl4OffBtn, Lvl4Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("level3") == "complete" && PlayerPrefs.GetString("level4") == "notcomplete")
        {
            btn = Instantiate(Lvl4OffBtn, Lvl4Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        btn.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);


        Destroy(Lvl3Wrap.GetComponent<Transform>().GetChild(0).gameObject);
        if (PlayerPrefs.GetString("level3") == "complete")
        {
            btn = Instantiate(Lvl3OnBtn, Lvl3Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetString("level2") == "notcomplete")
        {
            Debug.Log("2notcpmplete");

            btn = Instantiate(Lvl3OffBtn, Lvl3Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("level2") == "complete" && PlayerPrefs.GetString("level3") == "notcomplete")
        {
            btn = Instantiate(Lvl3OffBtn, Lvl3Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        btn.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);


        Destroy(Lvl2Wrap.GetComponent<Transform>().GetChild(0).gameObject);
        if (PlayerPrefs.GetString("level2") == "complete")
        {
            btn = Instantiate(Lvl2OnBtn, Lvl2Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetString("level1") == "notcomplete")
        {
            Debug.Log("1notcpmplete");

            btn = Instantiate(Lvl2OffBtn, Lvl2Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetString("level1") == "complete" && PlayerPrefs.GetString("level2") == "notcomplete")
        {
            btn = Instantiate(Lvl2OffBtn, Lvl2Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        btn.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);


        Destroy(Lvl1Wrap.GetComponent<Transform>().GetChild(0).gameObject);
        if (PlayerPrefs.GetString("level1") == "complete")
        {
            btn = Instantiate(Lvl1OnBtn, Lvl1Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetString("level1") == "notcomplete")
        {
            btn = Instantiate(Lvl1OffBtn, Lvl1Wrap.GetComponent<Transform>());
            btn.GetComponent<Button>().interactable = true;
        }
        btn.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);



    }

}