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

