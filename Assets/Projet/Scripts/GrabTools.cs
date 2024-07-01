using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabTools : MonoBehaviour
{
    // Start is called before the first frame update
    XRRayInteractor interactor;
    public bool IsGrabbing;
    void Awake()
    {
        interactor= GetComponent<XRRayInteractor>();
        IsGrabbing=false;
    }

    // Update is called once per frame
   
    public void TakeInput(SelectEnterEventArgs args)
    {
 
        IsGrabbing = true;
        Debug.Log("is grabbing");

 
    }
 
    public void StopInput(SelectExitEventArgs args)
    {
 
        IsGrabbing = false;
        Debug.Log("is releasing");
 
    }
}
