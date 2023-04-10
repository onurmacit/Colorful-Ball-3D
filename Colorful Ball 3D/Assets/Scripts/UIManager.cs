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


  public void Start(){
     whiteEffectİmage.SetActive(false);
    if(PlayerPrefs.HasKey("Sound")== false){
      PlayerPrefs.SetInt("Sound",1);

      if(PlayerPrefs.HasKey("Vibration") == false){
        PlayerPrefs.SetInt("Vibration",1);
      }
    }
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

  public void RestartButtonActive(){
    restartScreen.SetActive(true);
  }

  public void RestartScene(){
    Variables.firsTouch = 0;
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

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

