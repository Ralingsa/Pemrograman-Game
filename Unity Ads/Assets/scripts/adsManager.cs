using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour
{
    public Button btnAdd;
    public Button btnUse;
    public Text txCoin;

        int coin = 0;
        //durasi video 5 detik dan tidak bisa dilewati
        string placementId = "RewardedVideo";
    //video dapat dilewati setelah 5 detik
    //string placementId = "video";

    // Menggunakan Game ID berdasarkan Platform yang digunakan

#if UNITY_IOS
        private string gameId="4437843";
#elif UNITY_ANDROID
    private string gameId = "4437842";
#endif

    // Start is called before the first frame update
    void Start()
    {
        // menghandle button
        if (btnAdd) btnAdd.onClick.AddListener(ShowAd);
        if (btnUse) btnUse.onClick.AddListener(UseCoin);

        // inisialisasi Game ID ke Unity Ads
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize(gameId, true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // menentukan tombol dapat interakasi atau tidak
        if (btnAdd) btnAdd.interactable = Advertisement.IsReady(placementId);
        btnUse.interactable = (coin > 0);
    }

    void ShowAd()
    {
        // menampilkan iklan
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;
        Advertisement.Show(placementId, options);
    }

    void HandleShowResult(ShowResult result)
    {
        // merespon feedback, jika berhasil maka coin akan ditambah
        if (result == ShowResult.Finished)
        {
            Debug.Log("Video selesai - tawarkan coin ke pemain");
            coin += 50;
            txCoin.text = "Coin: " + coin;
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("Video dilewati - tidak menawarkan coin ke pemain");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video tidak ditampilkan");
        }
    }
    
    void UseCoin()
    {
        // koin dikurangi
        if (coin > 0)
        {
            coin -= 10;
            txCoin.text = "Coin: " + coin;
        }
    }
}
