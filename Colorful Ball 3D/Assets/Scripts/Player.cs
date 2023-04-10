using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private UIManager uımanagerscript;
    private CameraShake cameraScript;
    public GameObject vectorBack;
     public GameObject vectorForward;
    public GameObject cam;
    public Rigidbody rb;
    private Touch touch;
    [Range(20,40)]
    public int speedModifier;
    public int forwardSpeed;  
    private bool speedballForward = false;
    private bool firsttouchControl = false;

    void Start()
    {
        cameraScript = GameObject.FindObjectOfType<CameraShake>();
        uımanagerscript = GameObject.FindObjectOfType<UIManager>();
    }        
    public void Update()
    {
        if(Variables.firsTouch == 1 && speedballForward == false)
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
                if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
                    if(firsttouchControl == false){
                         Variables.firsTouch = 1;
                         uımanagerscript.FirstTouch();
                         firsttouchControl = true;
                    }
               
                }
                
            }
            else if(touch.phase == TouchPhase.Moved)
            {
               
                  if(!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * speedModifier * Time.deltaTime);

                    if(firsttouchControl == false){
                         Variables.firsTouch = 1;
                         uımanagerscript.FirstTouch();
                         firsttouchControl = true;
                    }
               
                }
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
                cameraScript.ShakeCamera();   
                uımanagerscript.WhiteEffect();                               
             }        
             StartCoroutine(TimeScaleControl());           
        } 
    } 

    public IEnumerator TimeScaleControl(){
        speedballForward = true;
        yield return new WaitForSecondsRealtime(0.4f);
        Time.timeScale = 0.4f;
        yield return new WaitForSecondsRealtime(0.6f);
        uımanagerscript.RestartButtonActive();
        rb.velocity = Vector3.zero;
    }   
}
