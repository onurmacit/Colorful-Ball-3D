using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
  public GameObject whiteEffectİmage;
  public Image ımage;
  public float duration;

  private bool radial_Shine;

  public Image fillrateImage;
  public GameObject player;

  public GameObject finishLine;

  public Animator layoutAnimator;

  public TextMeshProUGUI coinText;

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
  public GameObject blackBackground; 
  public GameObject complete;
  public GameObject radialShine;
  public GameObject coin;
  public GameObject rewarded;
  public GameObject nothanks;


  public void Start(){
     whiteEffectİmage.SetActive(false);
    if(PlayerPrefs.HasKey("Sound")== false){
      PlayerPrefs.SetInt("Sound",1);

      if(PlayerPrefs.HasKey("Vibration") == false){
        PlayerPrefs.SetInt("Vibration",1);
      }
    }
    CoinTextUpdate();
  }

  public void Update(){
    if(radial_Shine == true)
    radialShine.GetComponent<RectTransform>().Rotate(new Vector3(0,0,15f * Time.deltaTime));

    fillrateImage.fillAmount = ((player.transform.position.z*200) / (finishLine.transform.position.z))/200;

  }

  public void FirstTouch(){
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

  public void CoinTextUpdate(){
    coinText.text = PlayerPrefs.GetInt("moneyy").ToString();
  }

  public void RestartButtonActive(){
    restartScreen.SetActive(true);
  }

  public void RestartScene(){
    Variables.firsTouch = 0;
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

  }

  public void FinishScreen(){
    StartCoroutine("FinishLaunch");
  }

  public IEnumerator FinishLaunch(){
    Time.timeScale = 0.5f;
    radial_Shine = true;
    finishScreen.SetActive(true);
    blackBackground.SetActive(true);
    yield return new  WaitForSecondsRealtime(0.8F);
    complete.SetActive(true);
    yield return new  WaitForSecondsRealtime(1.3F);
    radialShine.SetActive(true);
    coin.SetActive(true);
    yield return new  WaitForSecondsRealtime(1F);
    rewarded.SetActive(true);
    yield return new  WaitForSecondsRealtime(3F);
    nothanks.SetActive(true);
  }










  //Buton Fonksiyonları

  public void SettingsOpen(){
    settingsOpen.SetActive(false);
    settingsClose.SetActive(true);
    layoutAnimator.SetTrigger("slide_in");

    if(PlayerPrefs.GetInt("Sound") == 1){
      soundOn.SetActive(true);
      soundOff.SetActive(false);
      AudioListener.volume = 1;
    }

    else if(PlayerPrefs.GetInt("Sound") == 2){
      soundOn.SetActive(false);
      soundOff.SetActive(true);
      AudioListener.volume = 0; 
    }

     if (PlayerPrefs.GetInt("Vibration") ==1){
       vibrationOn.SetActive(true);
       vibrationOff.SetActive(false);
    }

     else if (PlayerPrefs.GetInt("Vibration") ==2){
       vibrationOn.SetActive(false);
       vibrationOff.SetActive(true);
    }
    
  }

  public void SettingsClose(){
    settingsOpen.SetActive(true);
    settingsClose.SetActive(false);
    layoutAnimator.SetTrigger("slide_out");
  }

  public void SoundOn (){
    soundOn.SetActive(false);
    soundOff.SetActive(true);
    AudioListener.volume = 0;
    PlayerPrefs.SetInt("Sound",2);
  }

  public void SoundOff (){
    soundOn.SetActive(true);
    soundOff.SetActive(false);
    AudioListener.volume = 1;
    PlayerPrefs.SetInt("Sound",1);
  }

  public void VibrationOn (){
    vibrationOn.SetActive(false);
    vibrationOff.SetActive(true);
    PlayerPrefs.SetInt("Vibration",2); 
  }

   public void VibrationOff (){
    vibrationOn.SetActive(true);
    vibrationOff.SetActive(false);
    PlayerPrefs.SetInt("Vibration",1);
  }

























  
    public void WhiteEffect(){
         whiteEffectİmage.SetActive(true);
        ımage.DOFade(1f,duration)
        .SetEase(Ease.OutQuad)
            .OnComplete(() => {
                ımage.DOFade(0f, duration)
                    .SetEase(Ease.OutQuad);
                    whiteEffectİmage.SetActive(false);
        });      
    }
}

