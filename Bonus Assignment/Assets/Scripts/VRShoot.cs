using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public OVRInput.Button shootButton;

    private OVRGrabbable grabbable;
    private AudioSource audioChosen;

    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
        audioChosen = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if(grabbable.isGrabbed && OVRInput.GetDown(shootButton,grabbable.grabbedBy.getController())){
            simpleShoot.StartShoot();
            audioChosen.Play();
        }
        
    }
}
