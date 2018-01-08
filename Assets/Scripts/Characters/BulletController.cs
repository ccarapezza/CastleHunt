using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public SpriteRenderer render;
    public int speed;
    public Rigidbody2D rb;

    // Use this for initialization
    void Awake () {
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(int direction) {
        if (direction != 1)
        {
            render.flipX = true;
        }

        Vector2 direct = new Vector2(direction * speed, rb.velocity.y);
        rb.AddForce(direct,ForceMode2D.Impulse);
    }

    public void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
