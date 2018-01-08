using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
        GameObject cameraObject = GameObject.Find("Main Camera");
        this.gameObject.transform.parent = cameraObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
