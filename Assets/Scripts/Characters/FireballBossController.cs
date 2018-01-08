using UnityEngine;
using System.Collections;

public class FireballBossController : MonoBehaviour
{
    public int speed;
    public SpriteRenderer render;
    public Rigidbody2D rb;
    float attackDist;

    public Vector3 target;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity == Vector2.zero) {
            Fire();
        }
    }

    public void Fire()
    {
        Vector3 director = target + new Vector3(0,0.2f,0) - gameObject.transform.position;
        float distance = director.magnitude;
        Vector3 directionVector = director / distance; // This is now the normalized direction.

        rb.AddForce(directionVector * speed, ForceMode2D.Impulse);
    }


    public void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
