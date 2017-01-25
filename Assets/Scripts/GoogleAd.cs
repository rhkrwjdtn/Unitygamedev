using GoogleMobileAds.Api;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GoogleAd : MonoBehaviour {

	private InterstitialAd interstitial = null;
	private AdRequest adRequest = null;

	// Use this for initialization
	void Start () {

		if(interstitial==null){
		// 전면 광고 id 등록
		interstitial = new InterstitialAd( "ca-app-pub-4459600216007127/5449335293" );

		// 애드몹 리퀘스트 초기화
		adRequest = new AdRequest.Builder()
			.AddTestDevice( AdRequest.TestDeviceSimulator )       // Simulator.
			.AddTestDevice( "AD4304320520CBA65E96DEADA907D32D" )  // Jeongsu
			.Build();
			adRequest = new AdRequest.Builder()
				.AddTestDevice( AdRequest.TestDeviceSimulator )       // Simulator.
				.AddTestDevice( "04B4306F2A55377786687095A32190AC" )  // Dori
				.Build();
			interstitial.OnAdClosed += AdListener;
		// 애드몹 전면 광고 로드
		interstitial.LoadAd( adRequest );

	
		}

	}

	public void GoogleAdPopup(){
		if ( interstitial.IsLoaded() )
		{
			Debug.Log ("광고실행@@@@@");
			interstitial.Show();
		}
	}

	private void AdListener(object sender, System.EventArgs args){
		interstitial.LoadAd (adRequest);
	}

}
