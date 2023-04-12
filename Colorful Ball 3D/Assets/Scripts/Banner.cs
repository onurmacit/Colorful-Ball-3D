using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class Banner : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
    // #if UNITY_ANDROID
    //   private string _adUnitId = "ca-app-pub-3940256099942544/6300978111";
    // #elif UNITY_IPHONE
    //   private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
    // #else
    //   private string _adUnitId = "unused";
    // #endif  
    private BannerView bannerView;

    // Test ID'leri, test etmek için kullanabilirsiniz.
    private string appId = "ca-app-pub-3940256099942544~3347511713";
    private string adUnitId = "ca-app-pub-3940256099942544/6300978111";

    [System.Obsolete]
    void Start()
    {
        // Initialize the Google Mobile Ads SDK
        MobileAds.Initialize(initStatus => { });

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);
    }
}