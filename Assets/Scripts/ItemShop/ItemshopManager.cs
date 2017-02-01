using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ItemshopManager : MonoBehaviour {

    public Button randomboxbtn;
    public int randomnumber;
    public GameObject ItemAlramPopup;
    public GameObject[] ItemList = new GameObject[5];  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if(ItemAlramPopup.active==false)
        {
            for(int i=0;i<5;i++)
            {
                ItemList[i].active = false;
            }
        }	

	}

    public void ShowRewardedAd()
    {
       if (Advertisement.IsReady("rewardedVideo"))
       {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
       }
     }

    private void HandleShowResult(ShowResult result)
        {
        IconManager item = GameObject.Find("IconManager").GetComponent<IconManager>();
        randomnumber = Random.Range(0, 100);

            switch (result)
            {
                case ShowResult.Finished:
                    Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                if(randomnumber<=30)
                {
                    ItemAlramPopup.active = true;
                    ItemList[0].active = true;
                    item.redbullcnt++;
                }
                else if(randomnumber<=60&&randomnumber>30)
                {
                    ItemAlramPopup.active = true;
                    ItemList[1].active = true;
                    item.smallpizzacnt++;
                }
                else if(randomnumber<=80&&randomnumber>60)
                {
                    ItemAlramPopup.active = true;
                    ItemList[4].active = true;
                    item.rebirthpotion++;
                }
                else if(randomnumber<=90&&randomnumber>80)
                {
                    ItemAlramPopup.active = true;
                    ItemList[2].active = true;
                    item.burncnt++;
                
                }
                else if(randomnumber<=100&&randomnumber>90)
                {
                    ItemAlramPopup.active = true;
                    ItemList[3].active = true;
                    item.largepizzacnt++;
                }
                    break;
                case ShowResult.Skipped:
                    Debug.Log("The ad was skipped before reaching the end.");
                    break;
                case ShowResult.Failed:
                    Debug.LogError("The ad failed to be shown.");
                    break;
            }
        }

    public void randomboxbtnClick()
    {
        ShowRewardedAd();

    }
}
