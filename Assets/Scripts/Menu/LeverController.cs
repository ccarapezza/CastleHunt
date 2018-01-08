using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeverController : MonoBehaviour {

    private AnimationControllerCustom animationController;
    public string[] plataformTags;


    void Start ()
    {    
        animationController = GetComponent<AnimationControllerCustom>();
    }

    public void PushLever() {
        PlatformController plataformController;

        foreach (var tag in plataformTags)
        {
            plataformController = GameObject.FindGameObjectWithTag(tag).GetComponent<PlatformController>();
            plataformController.active = !plataformController.active;

        }
        animationController.ChangeAnimation("MoveLever");
        animationController.isPlaying = true;
    }   
}
