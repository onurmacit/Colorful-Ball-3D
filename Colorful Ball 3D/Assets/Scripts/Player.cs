using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public GameObject vectorBack;
     public GameObject vectorForward;
    public GameObject cam;
    public Rigidbody rb;
    private Touch touch;
    [Range(20,40)]
    public int speedModifier;
    public int forwardSpeed;
    
    public float duration;
    public float strength;
    public int vibrato;
    public float randomness;

     
    public void Update()
    {
        if(Variables.firsTouch == 1)
        {
           transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
           cam.transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
           vectorBack.transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
           vectorForward.transform.position += new Vector3(0,0,forwardSpeed*Time.deltaTime);
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);   
            
            if(touch.phase == TouchPhase.Began)
            {
                Variables.firsTouch = 1;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
               rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * speedModifier * Time.deltaTime);
            }

            else if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity =  Vector3.zero;
            }         
            }
        }  
    public GameObject[] FractureItems;

    public void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.CompareTag("Obstacles"))
        {              
             gameObject.transform.GetChild(0).gameObject.SetActive(false);
             foreach (GameObject item in FractureItems)
             {
                item.GetComponent<SphereCollider>().enabled = true;
                item.GetComponent<Rigidbody>().isKinematic = false;

                 cam.transform.DOShakeRotation(duration,strength,vibrato,randomness);                                             
             }               
        }       
    }  
}
