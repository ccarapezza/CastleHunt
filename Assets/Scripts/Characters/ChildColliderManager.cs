using UnityEngine;
using System.Collections;

public class ChildColliderManager : MonoBehaviour {

    private Collider2D[] colliders;

    void Start()
    {
        colliders = GetComponentsInChildren<Collider2D>();
    }

    public void ActivateCollider(string name, bool value)
    {
        foreach (var currentCollider in colliders)
        {
            if (currentCollider.name.Equals(name))
            {
                currentCollider.enabled = value;
            }
        }
    }
}
