using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public static GameObject Ad_Manager;
    public static string APP_ID = ""; // Real ID
    
    public static BannerView bannerAd;
    public static InterstitialAd interstitialAd;
    public static RewardBasedVideoAd rewardBasedVideoAd;

    public static int interstitialControl = 0;
    public static int rewardVideoControl = 0;
    
    public static int interstitialGoldActive = 0;
    // Start is called before the first frame update
    void Start()
    {
	//PlayerPrefs.DeleteAll();

	if(Ad_Manager != null){
	   Destroy(this.gameObject);
	}
        Ad_Manager = this.gameObject;

        MobileAds.Initialize(APP_ID);

        //RequestBanner();
        RequestInterstitial();
        RequestVideoAD();

        DontDestroyOnLoad(Ad_Manager);
	    
    }

    static void RequestBanner() {
        /*string banner_ID = "";
        //string banner_ID = "ca-app-pub-3940256099942544/6300978111";
        bannerAd = new BannerView(banner_ID,AdSize.SmartBanner,AdPosition.Bottom);

        // Real
        AdRequest adRequest = new AdRequest.Builder().Build();
        // Test
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("20")Build();

        bannerAd.LoadAd(adRequest);*/
    }

    static void RequestInterstitial() {
        string interstitial_ID = ""; // Real ID
        //string interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
        interstitialAd = new InterstitialAd(interstitial_ID); 

        interstitialAd.OnAdClosed += InterstitialClosed ;

        // Real
        AdRequest adRequest = new AdRequest.Builder().Build();
        // Test
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("20")Build();

        interstitialAd.LoadAd(adRequest);
    }

    // +30
    static void RequestVideoAD() {
        string request_ID = ""; //Real ID
        //string request_ID = "ca-app-pub-3940256099942544/5224354917";
        rewardBasedVideoAd = RewardBasedVideoAd.Instance;
        // Real
        AdRequest adRequest = new AdRequest.Builder().Build();
        // Test
        //AdRequest adRequest = new AdRequest.Builder().AddTestDevice("20")Build();

        rewardBasedVideoAd.LoadAd(adRequest, request_ID);
    }

    public static void Show_Banner_Bot(){
	#if UNITY_EDITOR
	#elif UNITY_ANDROID
		//bannerAd.Show();

	#endif
	}
    public static void Hide_Banner_Bot(){
	#if UNITY_EDITOR
	#elif UNITY_ANDROID
		//bannerAd.Hide();

	#endif
    }

    public static void InterstitialClosed(object sender, EventArgs e) {
        if(interstitialGoldActive != 0){
            PlayerSettings.setMainGold(PlayerSettings.getMainGold() + 5 );
        }
        interstitialGoldActive = 0;
		RequestInterstitial();
        
        
	}

    public static void Show_Interstitial(){
		#if UNITY_EDITOR
		#elif UNITY_ANDROID
			if(interstitialAd.IsLoaded()){
			
			 interstitialAd.Show();

			}
		#endif
	}

    public static void Show_Rewarted_Video(){
	#if UNITY_EDITOR
	#elif UNITY_ANDROID
		if(rewardBasedVideoAd.IsLoaded())
		{
			rewardBasedVideoAd.Show();
			rewardBasedVideoAd.OnAdRewarded += VideoRewarded;
			rewardBasedVideoAd.OnAdClosed += VideoClosed;
		}
		#endif
	}

    public static void VideoRewarded( object sender ,EventArgs e) {
		Video_Complete();
	}
	public static  void VideoClosed( object sender ,EventArgs e) {
		RequestVideoAD();
	}

    public static void Video_Complete(){
		PlayerSettings.setMainGold(PlayerSettings.getMainGold() + 30 );
	}

}
