using UnityEngine;
using System.Collections;

public class TutorialTrigger : MonoBehaviour {

    TutorialManager tutorialManager;


	// Use this for initialization
	void Start () {
        tutorialManager = this.GetComponentInParent<TutorialManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 18)
        {
            tutorialManager.OnTriggerEnter2DTrigger(this.tag);
        }
    }
}
