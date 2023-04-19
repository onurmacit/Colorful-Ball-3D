using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject whiteEffectİmage;
    public Image ımage;
    public float duration;
    public float revealDuration = 1f;

    private bool radial_Shine;

    public Image fillrateImage;
    public GameObject player;

    public GameObject finishLine;
    public Text coin_text;

    public Animator layoutAnimator;



    //Butonlar
    public GameObject settingsOpen;
    public GameObject settingsClose;
    public GameObject layoutBackground;
    public GameObject soundOn;
    public GameObject soundOff;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject iap;
    public GameObject information;
    public GameObject introHand;
    public GameObject taptostartText;
    public GameObject noAds;
    public GameObject shopButton;
    public GameObject restartScreen;

    //Oyun Sonu Ekranı
    public GameObject finishScreen;
    public RectTransform blackBackground;
    public RectTransform complete;
    public RectTransform radialShine;
    public RectTransform coin;
    public RectTransform rewarded;
    public GameObject nothanks;

    public RectTransform achievedCoin;
    public RectTransform nextLevel;
    public Text achievedText;


    public void Start()
    {
        whiteEffectİmage.SetActive(false);
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);

            if (PlayerPrefs.HasKey("Vibration") == false)
            {
                PlayerPrefs.SetInt("Vibration", 1);
            }
        }
        CoinTextUpdate();
    }

    public void Update()
    {
        if (radial_Shine == true)
            radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f * Time.deltaTime));

        fillrateImage.fillAmount = ((player.transform.position.z * 200) / (finishLine.transform.position.z)) / 200;

    }

    public void FirstTouch()
    {
        introHand.SetActive(false);
        taptostartText.SetActive(false);
        noAds.SetActive(false);
        shopButton.SetActive(false);
        settingsOpen.SetActive(false);
        settingsClose.SetActive(false);
        layoutBackground.SetActive(false);
        soundOn.SetActive(false);
        soundOff.SetActive(false);
        vibrationOff.SetActive(false);
        vibrationOn.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }

    public void CoinTextUpdate()
    {
         coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        restartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firsTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void NextScen()
    {
        Variables.firsTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

  

    











    public void FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radial_Shine = true;
        finishScreen.SetActive(true);
        blackBackground.gameObject.SetActive(true);
        blackBackground.DOScale(Vector3.zero, revealDuration).From();
        complete.gameObject.SetActive(true);
        complete.DOAnchorPosY(230f, revealDuration).From();
        radialShine.gameObject.SetActive(true);
        radialShine.DOAnchorPosX(900f, revealDuration).From();
        coin.gameObject.SetActive(true);
        coin.DOAnchorPosY(-800f, revealDuration).From();
        rewarded.gameObject.SetActive(true);
        var tween = rewarded.DOAnchorPosX(-900f, revealDuration).From();
        tween.OnComplete(() =>
{
    DOVirtual.DelayedCall(3f, () =>
    {
        nothanks.SetActive(true);
    });
});
    }

    public void AfterRewardButton()
    {
        Debug.Log("AfterRewardButton dotween started.");
        finishScreen.SetActive(true);
        achievedCoin.gameObject.SetActive(true);
        achievedCoin.DOAnchorPosY(-800f, revealDuration).From();
        achievedText.gameObject.SetActive(true);
        rewarded.gameObject.SetActive(false);
        nothanks.SetActive(false);
        achievedText.text = "";
        achievedText.DOText("400", revealDuration).SetDelay(revealDuration);
        nextLevel.gameObject.SetActive(true);
        nextLevel.DOAnchorPosY(800f, revealDuration).From();
    }










    //Buton Fonksiyonları

    public void SettingsOpen()
    {
        settingsOpen.SetActive(false);
        settingsClose.SetActive(true);
        layoutAnimator.SetTrigger("slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
            AudioListener.volume = 1;
        }

        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibrationOn.SetActive(true);
            vibrationOff.SetActive(false);
        }

        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibrationOn.SetActive(false);
            vibrationOff.SetActive(true);
        }

    }

    public void SettingsClose()
    {
        settingsOpen.SetActive(true);
        settingsClose.SetActive(false);
        layoutAnimator.SetTrigger("slide_out");
    }

    public void SoundOn()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void SoundOff()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void VibrationOn()
    {
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void VibrationOff()
    {
        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }


























    public void WhiteEffect()
    {
        whiteEffectİmage.SetActive(true);
        ımage.DOFade(1f, duration)
        .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                ımage.DOFade(0f, duration)
                    .SetEase(Ease.OutQuad);
                whiteEffectİmage.SetActive(false);
            });
    }
}

