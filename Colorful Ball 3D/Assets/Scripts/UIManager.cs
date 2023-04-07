using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
  public GameObject whiteEffectİmage;
  public Image ımage;
  public float duration;

  public Animator layoutAnimator;

  //Butonlar
  public GameObject settingsOpen;
  public GameObject settingsClose; 
  public GameObject soundOn;
  public GameObject soundOff;
  public GameObject vibrationOn;
  public GameObject vibrationOff;
  public GameObject iap;
  public GameObject information;



  //Buton Fonksiyonları

  public void SettingsOpen(){
    settingsOpen.SetActive(false);
    settingsClose.SetActive(true);
    layoutAnimator.SetTrigger("slide_in");
  }

  public void SettingsClose(){
    settingsOpen.SetActive(true);
    settingsClose.SetActive(false);
    layoutAnimator.SetTrigger("slide_out");
  }

  public void SoundOn (){
    soundOn.SetActive(false);
    soundOff.SetActive(true);
  }

  public void SoundOff (){
    soundOn.SetActive(true);
    soundOff.SetActive(false);
  }

  public void VibrationOn (){
    vibrationOn.SetActive(false);
    vibrationOff.SetActive(true);
  }

   public void VibrationOff (){
    vibrationOn.SetActive(true);
    vibrationOff.SetActive(false);
  }

























  
  public void Start(){
    whiteEffectİmage.SetActive(false);
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

