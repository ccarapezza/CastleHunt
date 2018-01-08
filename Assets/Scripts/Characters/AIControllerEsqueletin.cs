using UnityEngine;
using System.Collections;

public class AIControllerEsqueletin : MonoBehaviour
{
    public bool isMoving;
    public bool isActive;
    public bool isAttacking;
    public bool isDead;

    private float speed;
    public float easySpeed;
    public float hardSpeed;
    public float direction;
    public float activeDist;
    public float attackDist;

    private GameObject royce;
    private Rigidbody2D rb;
    private AnimationControllerCustom anim;
    private ChildColliderManager colliderManager;

    public float deadTimer;
    public float currentDeadTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<AnimationControllerCustom>();
        colliderManager = GetComponent<ChildColliderManager>();
        royce = GameObject.FindGameObjectWithTag("Player");
        int difficutl = 0;
        if (GameManager.instance != null) difficutl = GameManager.instance.difficult;
        if (difficutl == 0) speed = easySpeed;
        if (difficutl == 1) speed = hardSpeed;
    }

    void Update()
    {
        if (!isDead)
        {
            if (isActive && !isAttacking)
            {
                if (transform.position.x > royce.transform.position.x) Move(-1);
                else Move(1);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                isMoving = false;
            }
        }
        else {
            currentDeadTimer += Time.deltaTime;
            if (currentDeadTimer > deadTimer) {
                Destroy(this.gameObject);
            }
        }
    }

    void LateUpdate()
    {
        AnimationControl();
    }

    public void Move(float dir)
    {
            isMoving = true;
            direction = dir;

            Vector2 direct = new Vector2(dir * speed, rb.velocity.y);
            rb.velocity = direct;
    }

    void FixedUpdate()
    {
        if (!isDead) {
            float dist = Vector3.Distance(royce.transform.position, transform.position);
            if (dist < activeDist && CheckEqualHorizontalPosition() && !royce.GetComponent<Player>().isDead)
            {
                isActive = true;
            }
            else
            {
                isActive = false;
            }

            if (dist < attackDist && CheckEqualHorizontalPosition()) {
                StartPunch();
            }
        }

    }

    public void AnimationControl()
    {
        if (isDead && direction == 1) anim.ChangeAnimation("IdleRight");
        else if (isDead && direction == -1) anim.ChangeAnimation("IdleLeft");
        else if (isAttacking && (direction == 1)) anim.ChangeAnimation("AttackRight");
        else if (isAttacking && (direction == -1)) anim.ChangeAnimation("AttackLeft");
        else if (isMoving && (direction == 1)) anim.ChangeAnimation("MoveRight");
        else if (isMoving && (direction == -1)) anim.ChangeAnimation("MoveLeft");

        else if (direction == 1) anim.ChangeAnimation("IdleRight");
        else if (direction == -1) anim.ChangeAnimation("IdleLeft");
    }

    void StartPunch() {
        isAttacking = true;
    }

    void FinishPunch()
    {
        isAttacking = false;
    }

    void StartAttack() {
        SoundManager.instance.Stop(SoundID.ESQUELETIN);
        SoundManager.instance.Play(SoundID.ESQUELETIN, false, 0.02F, 1);
        if (direction == 1) colliderManager.ActivateCollider("PunchRight", true);
        else colliderManager.ActivateCollider("PunchLeft", true);
    }

    void FinishAttack()
    {
        colliderManager.ActivateCollider("PunchRight", false);
        colliderManager.ActivateCollider("PunchLeft", false);
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            SoundManager.instance.Stop(SoundID.AIRPUNCH);
            SoundManager.instance.Stop(SoundID.PUNCH);
            SoundManager.instance.Play(SoundID.PUNCH, false, 0.02f, 0);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            rb.constraints = RigidbodyConstraints2D.None;
            isDead = true;
            FinishAttack();
            rb.AddForceAtPosition(Vector2.up, collision.gameObject.transform.position, ForceMode2D.Impulse);
            //Destroy(this.gameObject);
        }
    }
}