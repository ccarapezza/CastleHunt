using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    AnimationControllerCustom animationController;

    public bool isOpen;
    public string puertaTarget;
    public bool isWinnerDoor;

    // Use this for initialization
    void Start () {
        animationController = GetComponent<AnimationControllerCustom>();
        isOpen = false;
    }
	
	public Vector3 Open () {
        animationController.ChangeAnimation("Opening");
        isOpen = true;
        GameObject doorObject = null;
        if (puertaTarget != null && puertaTarget != "") {
            doorObject = GameObject.FindGameObjectWithTag(puertaTarget);
        }
        if (doorObject == null)
        {
            doorObject = this.gameObject;
        }
        doorObject.GetComponent<DoorController>().animationController.ChangeAnimation("Opening");
        return doorObject.transform.position;
    }
}
