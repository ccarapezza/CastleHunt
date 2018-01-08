using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour
{

    public float speed;
    public bool subiendo;
    public float maxYLimit;
    public float minYLimit;

    public bool active;

    // Update is called once per frame
    void FixedUpdate()
    {
        // cambios aca
        if (active)
        {
            if (transform.position.y >= maxYLimit || !subiendo)
            {
                transform.position += speed * Time.deltaTime * Vector3.down;
                subiendo = false;
            }
            if (transform.position.y <= minYLimit || subiendo)
            {
                transform.position += speed * Time.deltaTime * Vector3.up;
                subiendo = true;
            }
        }
            // hasta aca
     }
    

    }

