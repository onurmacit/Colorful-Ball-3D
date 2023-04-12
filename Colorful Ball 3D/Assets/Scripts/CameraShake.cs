using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CameraShake : MonoBehaviour
{
    public float randomness;
    public float strength;
    public int vibrato;
    public float duration;
    public float restoreDuration = 0.5f;
    private bool shakeControl = false;
    public void ShakeCamera()
    {
        if ((shakeControl == false))
        {
            transform.DOShakeRotation(duration, strength, vibrato, randomness);
            Quaternion startRotation = transform.rotation;
            DOTween.Sequence().AppendInterval(duration)
            .Append(transform.DORotate(startRotation.eulerAngles, restoreDuration))
            .Play();
            shakeControl = true;
        }
    }
}

