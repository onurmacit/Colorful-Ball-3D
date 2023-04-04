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
    public void ShakeCamera()
    {
    transform.DOShakeRotation(duration,strength,vibrato,randomness);     
    }
}
