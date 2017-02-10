using GoogleMobileAds.Api;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GoogleAd : MonoBehaviour {

	private InterstitialAd stockbutton = null;
	private InterstitialAd emp1 = null;
	private InterstitialAd emp2 = null;
	private InterstitialAd emp3 = null;
	private InterstitialAd charlever = null;
	private AdRequest adRequest = null;

	// Use this for initialization
	void Start () {

		if(stockbutton==null){
			// 전면 광고 id 등록
			stockbutton = new InterstitialAd( "ca-app-pub-4459600216007127/5449335293" );

			// 애드몹 리퀘스트 초기화
			adRequest = new AdRequest.Builder()
				.AddTestDevice( AdRequest.TestDeviceSimulator )       // Simulator.
				.AddTestDevice( "2B3A4AFA99ACDB29BB88EBEB6F651D14" )  // Jeongsu
				.Build();
	//		adRequest = new AdRequest.Builder()
	//			.AddTestDevice( AdRequest.TestDeviceSimulator )       // Simulator.
	//			.AddTestDevice( "9EEDD46C3D7F555BE63F352D2ED8D737" )  // 2
	//			.Build();
			stockbutton.LoadAd( adRequest );

			stockbutton.OnAdClosed += AdListener;
			// 애드몹 전면 광고 로드
		


		}

		if(emp1==null){
			// 전면 광고 id 등록
			emp1 = new InterstitialAd( "ca-app-pub-4459600216007127/4611730492" );

			emp1.LoadAd( adRequest );

			
			emp1.OnAdClosed += AdListener;

		

		}

		if(emp2==null){
			// 전면 광고 id 등록
			emp2 = new InterstitialAd( "ca-app-pub-4459600216007127/9321131694" );

	
			emp2.LoadAd( adRequest );

			emp2.OnAdClosed += AdListener;

	


		}

		if(emp3==null){
			// 전면 광고 id 등록
			emp3 = new InterstitialAd( "ca-app-pub-4459600216007127/4586110494" );

	

			emp3.LoadAd( adRequest );

			emp3.OnAdClosed += AdListener;



		}

		if(charlever==null){
			// 전면 광고 id 등록
			charlever = new InterstitialAd( "ca-app-pub-4459600216007127/6062843696" );

			charlever.LoadAd( adRequest );


			charlever.OnAdClosed += AdListener;

	
		}

	}

	public void stockAdPopup(){
		if ( stockbutton.IsLoaded() )
		{
			Debug.Log ("광고1실행@@@@@");
			stockbutton.Show();
		}
	}

	public void emp1AdPopup(){
		if ( emp1.IsLoaded() )
		{
			Debug.Log ("광고2실행@@@@@");
			emp1.Show();
		}
	}

	public void emp2AdPopup(){
		if ( emp2.IsLoaded() )
		{
			Debug.Log ("광고3실행@@@@@");
			emp2.Show();
		}
	}

	public void emp3AdPopup(){
		if ( emp3.IsLoaded() )
		{
			Debug.Log ("광고4실행@@@@@");
			emp3.Show();
		}
	}

	public void charleverAdPopup(){
		if ( charlever.IsLoaded() )
		{
			Debug.Log ("광고5실행@@@@@");
			charlever.Show();
		}
	}

	private void AdListener(object sender, System.EventArgs args){
		stockbutton.LoadAd (adRequest);
		emp1.LoadAd (adRequest);
		emp2.LoadAd (adRequest);
		emp3.LoadAd (adRequest);
		charlever.LoadAd (adRequest);
	}

}
