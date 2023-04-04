using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    public float randomness;
    public float strength;
    public int vibrato;
    public float duration;  
     public float restoreDuration = 0.5f;

    public void ShakeCamera()
    {
    transform.DOShakeRotation(duration,strength,vibrato,randomness);  
    Quaternion startRotation = transform.rotation;
    DOTween.Sequence().AppendInterval(duration)
    .Append(transform.DORotate(startRotation.eulerAngles, restoreDuration))
    .Play();
    }
}

