using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class Admob : MonoBehaviour
{
    [SerializeField]
    Button BtnInterstitial;

    private BannerView adBanner;
    private InterstitialAd adInternstitial;
    private string idApp, idBanner, idInternstitial;
    // Start is called before the first frame update
    void Start()
    {
        BtnInterstitial.interactable = false;
        idApp = "ca-app-pub-6210751729974442~3441035492";
        idBanner = "ca-app-pub-6210751729974442/1138483394";
        idInternstitial = "ca-app-pub-6210751729974442/6390810074";
        MobileAds.Initialize(idApp);


        //RequestBannerAd();
        RequestInternstitialAD(); 
    }

    #region BannnerAd
    public void RequestBannerAd()
    {
        adBanner = new BannerView(idBanner, AdSize.Banner, AdPosition.Bottom);
        AdRequest request = AdRequestBuild();
        adBanner.LoadAd(request);
    }

    public void DestroyBannerAd()
    {
        if (adBanner != null)
            adBanner.Destroy();
    }
    #endregion

    #region InternstitialAD
    public void RequestInternstitialAD()
    {
        adInternstitial = new InterstitialAd(idInternstitial);
        AdRequest request = AdRequestBuild();
        adInternstitial.LoadAd(request);

        //attach events
        adInternstitial.OnAdLoaded += this.HandleOnAdLoaded;
        adInternstitial.OnAdOpening += this.HandleOnAdOpening;
        adInternstitial.OnAdClosed += this.HandleOnAdClosed;

    }
    public void ShowInternstitialAD()
    {
        if(adInternstitial.IsLoaded())
        {
            adInternstitial.Show();
        }
    }
    public void DestroyInternstitialAD()
    {
        adInternstitial.Destroy();
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //this method executes when interstitialAD is loaded and ready to show
        BtnInterstitial.interactable = true;
    }
    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        //this method executes when interstitialAD is show
        BtnInterstitial.interactable = false;
    }
    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        //this method executes when interstitialAD is closed
        //deattach events
        adInternstitial.OnAdLoaded -= this.HandleOnAdLoaded;
        adInternstitial.OnAdOpening -= this.HandleOnAdOpening;
        adInternstitial.OnAdClosed -= this.HandleOnAdClosed;

        RequestInternstitialAD(); //request new ad when this is closed

    }


    #endregion

    AdRequest AdRequestBuild()
    {
        return new AdRequest.Builder().Build();
    }

    void OnDestroy()
    {
        DestroyBannerAd();
        DestroyInternstitialAD();
        //deattach events
        adInternstitial.OnAdLoaded -= this.HandleOnAdLoaded;
        adInternstitial.OnAdOpening -= this.HandleOnAdOpening;
        adInternstitial.OnAdClosed -= this.HandleOnAdClosed;
    }
}
