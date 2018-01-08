using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TutorialManager : MonoBehaviour {

    public List<GameObject> mensajes;
    public float countDown = 5;
    public bool isInstanceJump;
    public bool isInstanceAttack;
    public bool isInstanceClimb;
    public bool isInstanceEtoInteract;
    public bool isInstanceEtoDoor;
    
    

    private GameObject instanciar;
    
    // Use this for initialization
    void Start ()
    {

        MostrarMensajes(TutorialMensajes.ArrowToMove);
        
        Destroy(instanciar, countDown);



        isInstanceAttack = false;
        isInstanceClimb = false;
        isInstanceEtoInteract = false;
        isInstanceEtoDoor = false;
        isInstanceJump = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MostrarMensajes(TutorialMensajes i)
    {
        


        
        //print((int)i);
        instanciar = Instantiate(mensajes[(int)i]);
        
        
    }

    public void OnTriggerEnter2DTrigger(string tag)
    {
       

        if (tag == "TutorialTriggerJump" )
        {
            if (isInstanceJump) return;
            
            

            
            MostrarMensajes(TutorialMensajes.SpaceToJump);
            isInstanceJump = true;
            
            Destroy(instanciar, countDown);

            
            
        }
        if (tag == "TutorialTriggerAttack" )
        {

            if (isInstanceAttack) return;
            MostrarMensajes(TutorialMensajes.AtoAttack);
            isInstanceAttack = true;
                Destroy(instanciar, countDown);

            
        }
        if (tag == "TutorialTriggerClimb" )
        {
            if (isInstanceClimb) return;
            MostrarMensajes(TutorialMensajes.UpToClimb);
            isInstanceClimb = true;
            Destroy(instanciar, countDown);
            
        }
        if (tag == "TutorialTriggerEtoInteract" )
        {
            if (isInstanceEtoInteract) return;

            MostrarMensajes(TutorialMensajes.EtoInteract);
            isInstanceEtoInteract = true;
            Destroy(instanciar, countDown);
            
        }
        if (tag == "TutorialTriggerEtoDoor" )
        {
            if (isInstanceEtoDoor) return;
            MostrarMensajes(TutorialMensajes.EtoDoor);
            isInstanceEtoDoor = true;
            Destroy(instanciar, countDown);
            
        }
    }


    
}

 public enum TutorialMensajes
{
    ArrowToMove,
    SpaceToJump,
    AtoAttack,
    UpToClimb,
    EtoInteract,
    EtoDoor
}
