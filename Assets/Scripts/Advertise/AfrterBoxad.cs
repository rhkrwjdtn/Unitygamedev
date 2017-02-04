using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfrterBoxad : MonoBehaviour {

    public Button[] BoxButton = new Button[3];
    public Button OkButton;
    public bool[] BoxClicked = new bool[3];
    public bool[] Itemvariable = new bool[5];
    public bool endPopup = false;
    public Image[] Boximg = new Image[3];
    public Sprite box=null;
    public Sprite[] ItemImage = new Sprite[5];
    public int[] Randomnum = new int[3];
    public int[] Itemrandom = new int[5];
    public int Itemcnt;
    public Text[] Texts = new Text[2];

    public GameObject AfterAdPopup=null;


	// Use this for initialization
	void Start () {
        OkButton.interactable = false;
        for(int i=0;i<3;i++)
        {
            BoxClicked[i] = false;
            Boximg[i].GetComponent<Image>().sprite = box;
        
        }


	}
	
	// Update is called once per frame
	void Update () {
		if(AfterAdPopup.active==false)
        {
            OkButton.interactable = false;
            for (int i = 0; i < 3; i++)
            {
                BoxClicked[i] = false;
                Boximg[i].GetComponent<Image>().sprite = box;
                BoxButton[i].interactable = true;
                BoxButton[i].enabled = true;

            }

            Texts[0].text = "박스 한개 를 선택하세요~";
            Texts[1].text = "각 종 아이템이 들어있어요~";

            endPopup = false;

        }

	}
    public void BoxClickEvent()
    {
        IconManager itemmanager = GameObject.Find("IconManager").GetComponent<IconManager>();
        for(int i=0;i<3;i++)
        {
            if(BoxClicked[i]==true)
            {
                Texts[0].text = "짜잔~";
                for(int j=0;j<3;j++)
                {
                    Randomnum[j] = Random.Range(0, 10);

                    if (i!=j)
                    {
                        BoxButton[j].interactable = false; 
                    }
                    if (Randomnum[j] < 3)  //레드불이미지
                    {
                        Boximg[j].GetComponent<Image>().sprite = ItemImage[0];
                        if(i==j)
                        {
                            Itemvariable[0] = true;
                        }
                    }
                    else if (Randomnum[j] >= 3 && Randomnum[j] < 6) //스몰피자 이미지
                    {
                        Boximg[j].GetComponent<Image>().sprite = ItemImage[1];
                        if (i == j)
                        {
                            Itemvariable[1] = true;
                        }
                    }
                    else if (Randomnum[j] >= 6 && Randomnum[j] < 8) // 번 
                    {
                        Boximg[j].GetComponent<Image>().sprite = ItemImage[2];
                        if (i == j)
                        {
                            Itemvariable[2] = true;
                        }
                    }
                    else if (Randomnum[j] >= 8 && Randomnum[j] < 10) // 라지피자
                    {
                        Boximg[j].GetComponent<Image>().sprite = ItemImage[3];
                        if (i == j)
                        {
                            Itemvariable[3] = true;
                        }
                    }
                    else if (Randomnum[j] == 10)//환생물약
                    {
                        Boximg[j].GetComponent<Image>().sprite = ItemImage[4];
                        if (i == j)
                        {
                            Itemvariable[4] = true;
                        }
                    }
                    BoxButton[i].enabled = false;
                    OkButton.interactable = true;
                }
                //아이템 갯수
                for(int k=0;k<5;k++)
                {
                    if(Itemvariable[k]==true)
                    {
                        Itemrandom[k] = Random.Range(0, 10);
                        if(Itemrandom[k]<7)
                        {
                            Itemcnt = 1;

                        }
                        else if(Itemrandom[k]<10)
                        {
                            Itemcnt = 2;
                        }
                        else if (Itemrandom[k]==10)
                        {
                            Itemcnt = 3;
                        }
                        switch(k)
                        {
                            case 0:

                                itemmanager.redbullcnt += Itemcnt;
                                Texts[1].text = "드링크" + Itemcnt + "개~";
                                break;
                            case 1:
                                itemmanager.smallpizzacnt += Itemcnt;
                                Texts[1].text = "작은피자" + Itemcnt + "조각~";
                                break;
                            case 2:
                                itemmanager.burncnt += Itemcnt;
                                Texts[1].text = "슈퍼드링크" + Itemcnt + "개~";
                                break;
                            case 3:
                                itemmanager.largepizzacnt += Itemcnt;
                                Texts[1].text = "피자한판" + Itemcnt + "판~";
                                break;
                            case 4:
                                itemmanager.rebirthpotion += Itemcnt;
                                Texts[1].text = "환생물약" + Itemcnt + "개~";
                                break;
                        }

                    }
                    Itemvariable[k] = false;

                }
            }

        }
        
           
    }
    public void FirstBoxClick()
    {
        BoxClicked[0] = true;
        BoxClickEvent();
    }
    public void SecondBoxClick()
    {
        BoxClicked[1] = true;
        BoxClickEvent();
    }
    public void ThirdBoxClick()
    {
        BoxClicked[2] = true;
        BoxClickEvent();
    }
}
