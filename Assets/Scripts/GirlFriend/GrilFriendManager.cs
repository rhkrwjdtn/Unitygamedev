using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrilFriendManager : MonoBehaviour {

    public Button[] btn = new Button[6];
    public GameObject[] GirlFriend = new GameObject[6];
    public GameObject[] ClosePopup = new GameObject[5];
    public Image[] Backgroundcl = new Image[6];
    public Text[] btn_text = new Text[6];
    public bool[] GFExist = new bool[6];
    public bool[] ison = new bool[6];

    public Color close;
    public Color open;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < 6; i++)
        {
            if (btn[i] == null)
            {
                btn[i] = gameObject.GetComponent<UnityEngine.UI.Button>();
            }
        }
    }

    // Update is called once per frame
    void Update() {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
        if(moneyu.moneyspeed>10000)
        { ClosePopup[0].active = false; }
        if(moneyu.moneyspeed>50000)
        {
            ClosePopup[1].active = false;
        }
        if(moneyu.moneyspeed>100000)
        {
            ClosePopup[2].active = false;
        }
        if(moneyu.moneyspeed>500000)
        {
            ClosePopup[3].active = false;
        }
        if(moneyu.moneyspeed>5000000)
        {
            ClosePopup[4].active = false;
        }

        for (int i = 0; i < 6; i++)
        {
            if (GFExist[i] == true)
            {

                for (int j = 0; j < 6; j++)
                {
                    if (i != j)
                    {
                        btn[j].enabled = false;
                        Backgroundcl[j].color = close;

                    }
                }
                ison[i] = true;
                GirlFriend[i].active = true;
                btn_text[i].text = "헤어지기";
            }
            else if (ison[i] == true)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i != j)
                    {
                        btn[j].enabled = true;
                        Backgroundcl[j].color = open;
                    }
                }
                ison[i] = false;
                GirlFriend[i].active = false;
            }
        }

    }
    public void GFBtnClicked()
    {


        //if (GFExist[0] == true)
            for (int i = 0; i < 6; i++)
            {
                if (GFExist[i] == true)
                {

                    for (int j = 0; j < 6; j++)
                    {
                        if (i != j)
                        {
                            btn[j].enabled = false;
                            Backgroundcl[j].color = close;
                            
                         }
                    }
                ison[i] = true;
                btn_text[i].text = "헤어지기";
                }
                else if(ison[i]==true)
            {
                for(int j=0;j<6;j++)
                {
                    if(i!=j)
                    {
                        btn[j].enabled = true;
                        Backgroundcl[j].color = open;
                    }
                }
                ison[i] = false;
            }
            }
    }

    public void handbtnClick()
    {
        if (GFExist[0] == false)
        {
            GFExist[0] = true;
            GirlFriend[0].active = true;
        }

        else if(GFExist[0]== true)
        {
            GFExist[0] = false;
            GirlFriend[0].active = false;
            btn_text[0].text = "사귀기";

        }
        GFBtnClicked();
    }

    public void ImagineGfbtnClick()
    {
        if(GFExist[1]==false)
        {
            GFExist[1] = true;
            GirlFriend[1].active = true;
        }
        else if(GFExist[1]==true)
        {
            GFExist[1] = false;
            GirlFriend[1].active = false;
            btn_text[1].text = "사귀기";

        }
        GFBtnClicked();
    }
    public void dollbtnClick()
    {
        if (GFExist[2] == false)
        {
            GFExist[2] = true;
            GirlFriend[2].active = true;
        }
        else if (GFExist[2] == true)
        {
            GFExist[2] = false;
            GirlFriend[2].active = false;
            btn_text[2].text = "사귀기";

        }
        GFBtnClicked();
    }

    public void UnivGfbtnClick()
    {
        if (GFExist[3] == false)
        {
            GFExist[3] = true;
            GirlFriend[3].active = true;
        }
        else if (GFExist[3] == true)
        {
            GFExist[3] = false;
            GirlFriend[3].active = false;
            btn_text[3].text = "사귀기";

        }
        GFBtnClicked();
    }

    public void ForeignGfbtnClick()
    {
        if (GFExist[4] == false)
        {
            GFExist[4] = true;
            GirlFriend[4].active = true;
        }
        else if (GFExist[4] == true)
        {
            GFExist[4] = false;
            GirlFriend[4].active = false;
            btn_text[4].text = "사귀기";

        }
        GFBtnClicked();
    }

    public void TrainnerbtnClick()
    {
        if (GFExist[5] == false)
        {
            GFExist[5] = true;
            GirlFriend[5].active = true;
        }
        else if (GFExist[5] == true)
        {
            GFExist[5] = false;
            GirlFriend[5].active = false;
            btn_text[5].text = "사귀기";

        }
        GFBtnClicked();
    }
}

