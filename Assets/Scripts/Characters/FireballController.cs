using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour {

    public AnimationControllerCustom anim;
    private int speed;
    public int easySpeed;
    public int hardSpeed;
    public int direction;
    public SpriteRenderer render;
    public Rigidbody2D rb;

	void Start ()
    {
        anim = GetComponent<AnimationControllerCustom>();
        render = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        int difficutl = 0;
        if(GameManager.instance!=null) difficutl = GameManager.instance.difficult;
        if (difficutl == 0) speed = easySpeed;
        if (difficutl == 1) speed = hardSpeed;
    }

	void Update ()
    {
        anim.ChangeAnimation("Fire");
        Fire();
    }

    public void Fire()
    {
        if (direction == 1)
        {
            render.flipX = true;
        }

        Vector2 direct = new Vector2(direction * speed, rb.velocity.y);
        rb.velocity = direct;
    }


    public void OnTriggerEnter2D()
    {
        Destroy(this.gameObject);
    }
}
