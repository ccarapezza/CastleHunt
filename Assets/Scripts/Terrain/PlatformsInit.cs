using UnityEngine;
using System.Collections;

public class PlatformsInit : MonoBehaviour {

    
	// Use this for initialization
	void Awake () {
        Collider2D[] colliders = GetComponents<Collider2D>();

        PhysicsMaterial2D material = new PhysicsMaterial2D();
        material.friction = 0;
        material.bounciness = 0;

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].sharedMaterial = material;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
