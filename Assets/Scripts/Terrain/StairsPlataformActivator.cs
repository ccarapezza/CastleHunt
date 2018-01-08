using UnityEngine;
using System.Collections;

public class StairsPlataformActivator : MonoBehaviour {

    StairsController stairsController;

    // Use this for initialization
    void Start() {
        stairsController = this.gameObject.GetComponentInParent<StairsController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        stairsController.OnTriggerEnter2DPlatformActivator(collision);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        stairsController.OnTriggerStay2DPlatformActivator(collision);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        stairsController.OnTriggerExit2DPlatformActivator(collision);
    }
}
