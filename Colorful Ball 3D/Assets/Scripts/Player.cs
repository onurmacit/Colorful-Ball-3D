using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Touch touch;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);   

            if(touch.phase == TouchPhase.Moved)
            {

            }
        }
    }
}
