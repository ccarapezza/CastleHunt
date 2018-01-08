using UnityEngine;
using System.Collections;

public class AIControllerMaguin : MonoBehaviour
{

    public Rigidbody2D rb;
    public SpriteRenderer render;
    public AnimationControllerCustom anim;
    public int direction;
    private float speed;
    public float easySpeed;
    public float hardSpeed;
    public bool isMoving;
    public GameObject fireballPrefab;
    public GameObject royce;
    public  float attackDistance;
    public bool isDisparando;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<AnimationControllerCustom>();
        royce = GameObject.FindGameObjectWithTag("Player");
        RenderColor();
        int difficutl = 0;
        if (GameManager.instance != null) difficutl = GameManager.instance.difficult;
        if (difficutl == 0) speed = easySpeed;
        if (difficutl == 1) speed = hardSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void LateUpdate()
    {
        AnimationControl();
    }

    void FixedUpdate()
    {
        float dist = Vector3.Distance(royce.transform.position, transform.position);
        if (dist < attackDistance && CheckEqualHorizontalPosition() && !royce.GetComponent<Player>().isDead)
        {
            isDisparando = true;
            isMoving = false;
            rb.velocity = new Vector2(0, rb.velocity.y);
            if (royce.transform.position.x > this.transform.position.x)
            {
                render.flipX = true;
            }
            else
            {
                render.flipX = false;
            }
        }

        else
        {
            isDisparando = false;
            isMoving = true;
        }
    }

    bool CheckEqualHorizontalPosition()
    {
        float Ydist = royce.transform.position.y - transform.position.y;

        if (Mathf.Abs(Ydist) < 0.4)
        {
            return true;

        }
        else { return false; }
    }

    public void RenderColor()
    {
         if (Random.Range(0, 5) == 0) render.color = Color.red;
         if (Random.Range(0, 5) == 1) render.color = Color.green;
         if (Random.Range(0, 5) == 2) render.color = Color.white;
         if (Random.Range(0, 5) == 3) render.color = Color.cyan;
         if (Random.Range(0, 5) == 4) render.color = Color.yellow;
         if (Random.Range(0, 5) == 5) render.color = Color.magenta;
    }

    public void Move()
    {
        if (!isDisparando)
        {
            isMoving = true;
            direction = -1;
            if (render.flipX)
            {
                direction = 1;
            }

            Vector2 direct = new Vector2(direction * speed, rb.velocity.y);
            rb.velocity = direct;
        }
    }

    public void AnimationControl()
    {
        if (isMoving) anim.ChangeAnimation("Walk");
        else if (isDisparando) anim.ChangeAnimation("Attack");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 15) {
            render.flipX = !render.flipX;
        }
        if (collision.gameObject.layer == 11)
        {
            SoundManager.instance.Stop(SoundID.AIRPUNCH);
            SoundManager.instance.Stop(SoundID.PUNCH);
            SoundManager.instance.Play(SoundID.PUNCH, false, 0.02f, 0);
            Destroy(this.gameObject);
        }
    }

    public void Disparar()
    {
        float offset = 0.5f;
        GameObject fireball = Instantiate(fireballPrefab);
        int dir = 1;
        if (!render.flipX)
        {
            dir = -1;
            offset = -offset;
        }
        SoundManager.instance.Stop(SoundID.MAGE);
        SoundManager.instance.Play(SoundID.MAGE, false, 0.2F, 0);
        Vector3 newPosition = new Vector3(this.transform.position.x + offset,this.transform.position.y + 0.5f, 0);
        fireball.transform.position = newPosition;
        FireballController fireballcontroller = fireball.GetComponent<FireballController>();
        fireballcontroller.direction = dir;

        //fireballcontroller.Fire(direction);

        
    }

    

}
