using UnityEngine;
using System.Collections;

public class StairsController : MonoBehaviour {

    Collider2D platformCollider;
    Collider2D platformActivatorCollider;

    // Use this for initialization
    void Start () {
        Collider2D[] childColliders = GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < childColliders.Length; i++)
        {
            if (childColliders[i].name == "Platform") {
                platformCollider = childColliders[i];
            } else if (childColliders[i].name == "PlatformActivator"){
                platformActivatorCollider = childColliders[i];
            }
        }
        DesactivatePlatform();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 18)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.isAttachedToStair)
            {
                DesactivatePlatform();
            }
        }
    }

    public void OnTriggerEnter2DPlatformActivator(Collider2D collision) {
        ActivatePlatform();
    }
    
    public void OnTriggerStay2DPlatformActivator(Collider2D collision){
        if (collision.gameObject.layer == 18) {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player.isBajando)
            {
                DesactivatePlatform();
            }
            else
            {
                ActivatePlatform();
            }
        }
    }

    public void OnTriggerExit2DPlatformActivator(Collider2D collision){
        DesactivatePlatform();
    }

    public void ActivatePlatform() {
        platformCollider.enabled = true;
    }

    public void DesactivatePlatform(){
        platformCollider.enabled = false;
    }

    public void ActivatePlatformActivator()
    {
        platformActivatorCollider.enabled = true;
    }

    public void DesactivatePlatformActivator()
    {
        platformActivatorCollider.enabled = false;
    }
}
