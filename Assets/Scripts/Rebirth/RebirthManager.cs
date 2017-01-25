using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebirthManager : MonoBehaviour {
    Moneyupdate moneyu = GameObject.Find("MoneyManager").GetComponent<Moneyupdate>();
    public int msrandomnum = 0;
    public int ckrandomnum = 0;
    public int totalrandum = 0;
    public string msstring = null;
    public string ckstring = null;
    public ulong msmoneyspeed = 0;
    public ulong cktouchmoney = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void rebirthbtnClick()
    {
        totalrandum = Random.Range(0, 10000);
        if(totalrandum<=4000)
        {
            gmfrrebirth();
        }
        else if(totalrandum<=6500&&totalrandum>4000)
        {
            plasticrebirth();
        }
        else if(totalrandum<=8000&&totalrandum>6500)
        {
            nokrebirth();
        }
        else if(totalrandum<=9000&&totalrandum>8000)
        {
            dongrebirth();
        }
        else if(totalrandum<=9500&&totalrandum>9000)
        {
            silverrebirth();
        }
        else if(totalrandum<=9800&&totalrandum>9500)
        {
            goldrebirth();
        }
        else if(totalrandum<=10000&&totalrandum>9800)
        {
            diarebirth();
        }
    }
    public void gmfrrebirth()
    {
        msrandomnum = Random.Range(0, 10000);
        ckrandomnum = Random.Range(0, 1000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;

    }
    public void plasticrebirth()
    {
        msrandomnum = Random.Range(10000, 50000);
        ckrandomnum = Random.Range(1000, 5000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;

    }
    public void nokrebirth()
    {
        msrandomnum = Random.Range(50000, 100000);
        ckrandomnum = Random.Range(5000, 10000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
    }
    public void dongrebirth()
    {
        msrandomnum = Random.Range(100000, 500000);
        ckrandomnum = Random.Range(10000, 50000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
    }
    public void silverrebirth()
    {
        msrandomnum = Random.Range(500000, 1000000);
        ckrandomnum = Random.Range(50000, 100000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
    }
    public void goldrebirth()
    {
        msrandomnum = Random.Range(1000000, 5000000);
        ckrandomnum = Random.Range(100000, 500000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
    }
    public void diarebirth()
    {
        msrandomnum = Random.Range(5000000, 10000000);
        ckrandomnum = Random.Range(500000, 1000000);
        msstring = msrandomnum.ToString();
        ckstring = ckrandomnum.ToString();
        msmoneyspeed = ulong.Parse(msstring);
        cktouchmoney = ulong.Parse(ckstring);
        moneyu.moneyspeed = msmoneyspeed;
        moneyu.touchspeed = cktouchmoney;
    }
}
