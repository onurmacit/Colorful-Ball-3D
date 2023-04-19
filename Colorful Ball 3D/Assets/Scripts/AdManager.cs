using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-3940256099942544/1033173712";
    private string _rwadUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
  private string _adUnitId = "unused";
#endif

    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;
    public UIManager uımanagerScript;
    public void LoadInterstitialAd()
    {
        var adRequest = new AdRequest.Builder()
                  .AddKeyword("unity-admob-sample")
                  .Build();


        InterstitialAd.Load(_adUnitId, adRequest,
                  (InterstitialAd ad, LoadAdError error) =>
                  {
                      // if error is not null, the load request failed.
                      if (error != null || ad == null)
                      {
                          Debug.LogError("interstitial ad failed to load an ad " +
                                         "with error : " + error);
                          return;
                      }

                      Debug.Log("Interstitial ad loaded with response : "
                                + ad.GetResponseInfo());

                      interstitialAd = ad;
                  });


    }


    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    public void LoadRewardedAd()
    {
        var adRequest = new AdRequest.Builder().Build();

        // send the request to load the ad.
        RewardedAd.Load(_rwadUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
            });
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                CoinCalculator(400);  
                uımanagerScript.AfterRewardButton();  
            });
        }
    }

     public void CoinCalculator(int money)
    {
        if (PlayerPrefs.HasKey("moneyy"))
        {
            int oldScore = PlayerPrefs.GetInt("moneyy");
            PlayerPrefs.SetInt("moneyy", oldScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("moneyy", 0);
        }
    }
}


