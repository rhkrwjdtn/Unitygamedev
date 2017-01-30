using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

    public Image redbull;
    public Image redbullskillfilter;
    public Image smallpizza;
    public Image smallpizzaskillfilter;
    public Image burn;
    public Image burnskillfilter;
    public Image Largepizza;
    public Image Largepizzaskillfilter;

    public float startTime;
    public float checkTime;

    public int redbullcnt = 3;
    public int smallpizzacnt = 3;
    public int burncnt = 1;
    public int largepizzacnt = 1;
    public int rebirthpotion = 1;

    public bool redbullClicked = false;
    public bool smallpizzaClicked = false;
    public bool burnClicked = false;
    public bool largepizzaClicked = false;

    public Button redbullbtn;
    public Button smallpizzabtn;
    public Button burnbtn;
    public Button largepizzabtn;

    public Text redbullcnt_text = null;
    public Text smallpizzacnt_text = null;
    public Text burncnt_text = null;
    public Text largepizzacnt_text = null;
    public Text rebirthcnt_text = null;

    public Color close;
    public Color open;



	// Use this for initialization
	void Start () {
        startTime = 0.0f;
        checkTime = 10.0f;
        redbullcnt_text.text = redbullcnt + "개";
        smallpizzacnt_text.text = smallpizzacnt + "개";
        burncnt_text.text = burncnt + "개";
        largepizzacnt_text.text = largepizzacnt + "개";
        rebirthcnt_text.text = rebirthpotion + "개";
        redbullskillfilter.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();


        redbullcnt_text.text = redbullcnt + "개";
        smallpizzacnt_text.text = smallpizzacnt + "개";
        burncnt_text.text = burncnt + "개";
        largepizzacnt_text.text = largepizzacnt + "개";
        rebirthcnt_text.text = rebirthpotion + "개";

        if (redbullClicked==true)
        {
            startTime += Time.deltaTime;
            if(startTime>checkTime)
            {
                moneyu.touchspeed = moneyu.touchspeed / 10;
                redbullClicked = false;
                startTime = 0.0f;
                
            }    
        }
        if(smallpizzaClicked==true)
        {
            startTime += Time.deltaTime;
            if(startTime>checkTime)
            {
                moneyu.moneyspeed = moneyu.moneyspeed / 10;
                smallpizzaClicked = false;
                startTime = 0.0f;
            }
        }
        if(burnClicked==true)
        {
            startTime += Time.deltaTime;
            if(startTime>checkTime)
            {
                moneyu.touchspeed = moneyu.touchspeed / 100;
                burnClicked = false;
                startTime = 0.0f;
            }
        }
        if(largepizzaClicked==true)
        {
            startTime += Time.deltaTime;
            if(startTime>checkTime)
            {
                moneyu.moneyspeed = moneyu.moneyspeed / 100;
                largepizzaClicked = false;
                startTime = 0.0f;
            }
        }


        if(redbullcnt==0)
        {
            redbullbtn.enabled = false;
            redbull.color = close;
        }
        else if(redbullcnt!=0)
        {
            redbullbtn.enabled = true;
            redbull.color = open;
        }
        if(smallpizzacnt==0)
        {
            smallpizzabtn.enabled = false;
            smallpizza.color = close;
        }
        else if(smallpizzacnt!=0)
        {
            smallpizzabtn.enabled = true;
            smallpizza.color = open;
        }
        if(burncnt==0)
        {
            burnbtn.enabled = false;
            burn.color = close;
        }
        else if(burncnt!=0)
        {
            burnbtn.enabled = true;
            burn.color = open;
        }
        if(largepizzacnt==0)
        {
            largepizzabtn.enabled = false;
            Largepizza.color = close;
        }
        else if(largepizzacnt!=0)
        {
            largepizzabtn.enabled = true;
            Largepizza.color = open;
        }


        rebirthcnt_text.text = rebirthpotion + "개";

    }
    public void redbullClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();

        if (redbullClicked==false && redbullcnt!=0)
        {
            redbullClicked = true;
            moneyu.touchspeed = moneyu.touchspeed * 10;
            redbullcnt -= 1;
            redbullcnt_text.text = redbullcnt + "개";
            redbullskillfilter.fillAmount = 1;
            StartCoroutine("redbullcooltime");

        }
    }
    public void smallClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();

        if(smallpizzaClicked==false &&smallpizzacnt!=0)
        {
            smallpizzaClicked = true;
            moneyu.moneyspeed = moneyu.moneyspeed * 10;
            smallpizzacnt -= 1;
            smallpizzacnt_text.text = smallpizzacnt + "개";
            smallpizzaskillfilter.fillAmount = 1;
            StartCoroutine("smallpizzacooltime");
        }
    }
    public void burnClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();

        if(burnClicked==false && burncnt!=0)
        {
            burnClicked = true;
            moneyu.touchspeed = moneyu.touchspeed * 100;
            burncnt -= 1;
            burncnt_text.text = burncnt + "개";
            burnskillfilter.fillAmount = 1;
            StartCoroutine("burncooltime");
        }
    }
    public void LargepizzaClick()
    {
        Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();

        if(largepizzaClicked==false && largepizzacnt!=0)
        {
            largepizzaClicked = true;
            moneyu.moneyspeed = moneyu.moneyspeed * 100;
            largepizzacnt -= 1;
            largepizzacnt_text.text = largepizzacnt + "개";
            Largepizzaskillfilter.fillAmount = 1;
            StartCoroutine("largepizzacooltime");
        }
    }

    IEnumerator redbullcooltime()
    {
        while(redbullskillfilter.fillAmount>0)
        {
            redbullskillfilter.fillAmount -= 1 * Time.smoothDeltaTime / checkTime;

            yield return null;
        }
        yield break;
    }
    IEnumerator smallpizzacooltime()
    {
        while (smallpizzaskillfilter.fillAmount > 0)
        {
            smallpizzaskillfilter.fillAmount -= 1 * Time.smoothDeltaTime / checkTime;

            yield return null;
        }
        yield break;
    }
    IEnumerator burncooltime()
    {
        while (burnskillfilter.fillAmount > 0)
        {
            burnskillfilter.fillAmount -= 1 * Time.smoothDeltaTime / checkTime;

            yield return null;
        }
        yield break;
    }
    IEnumerator largepizzacooltime()
    {
        while (Largepizzaskillfilter.fillAmount > 0)
        {
            Largepizzaskillfilter.fillAmount -= 1 * Time.smoothDeltaTime / checkTime;

            yield return null;
        }
        yield break;
    }

}
