using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIControllerBaws : MonoBehaviour
{

    public bool isActive;
    public bool isMoving;

    public bool isShoot;
    public bool isThreeShoot;

    public bool subiendo;
    public float maxYLimit;
    public float minYLimit;
    public float maxXLimit;
    public float minXLimit;

    public bool goingRight;

    public float offset;


    public Rigidbody2D rb;
    public AnimationControllerCustom anim;
    public SpriteRenderer render;

    public bool attackDistance;

    public GameObject spitFirePrefab;
    public GameObject royce;

    public GameObject keyPrefab;

    public GameObject guiLifeBar;
    public float guiLifeBarStep;

    public float life;
    public float totalLife;
    public float playerHit;
    public float movingSpeed;

    public float timerDisparo;
    public float frecuenciaDeDisparo;

    public int countShot = 0;
    public int periodToThreeShot = 4;

    void Start()
    {
        playerHit = 5;
        totalLife = 10;
        guiLifeBar = GameObject.FindGameObjectWithTag("GUI-BossLife");
        guiLifeBarStep = guiLifeBar.GetComponent<RectTransform>().sizeDelta.x * (((playerHit*100f)/totalLife) /100f);
        life = totalLife;
        royce = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<AnimationControllerCustom>();

        maxXLimit = -7;
        minXLimit = 7;

        timerDisparo = 0;
        isMoving = true;
    }

    void Update()
    {
        if (royce.transform.position.x > this.transform.position.x)
        {
            render.flipX = false; // mirando hacia la derecha
        }
        else
        {
            render.flipX = true;
        }

        Move();

        maxYLimit = royce.transform.position.y + 2;
        minYLimit = royce.transform.position.y - 3;

        timerDisparo += Time.deltaTime;
        if (timerDisparo > frecuenciaDeDisparo) {
            timerDisparo = 0;
            countShot++;
            if (countShot == periodToThreeShot)
            {
                countShot = 0;
                ThreeShoot();
            }
            else {
                Shoot();
            }
        }

        AnimationControl();
    }

    public void ThreeShoot()
    {
        isThreeShoot = true;
        isMoving = false;
    }

    public void RealThreeShoot()
    {
        SoundManager.instance.Stop(SoundID.BOSS);
        SoundManager.instance.Play(SoundID.BOSS, false, 0.2f, 0);
        GameObject fireball = Instantiate(spitFirePrefab);
        Vector3 newPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1, 0);
        fireball.transform.position = newPosition;
        FireballBossController fireballBosscontroller = fireball.GetComponent<FireballBossController>();
        fireballBosscontroller.target = royce.transform.position;

        GameObject fireball2 = Instantiate(spitFirePrefab);
        fireball2.transform.position = newPosition;
        FireballBossController fireballBosscontroller2 = fireball2.GetComponent<FireballBossController>();
        fireballBosscontroller2.target = royce.transform.position + new Vector3(0, 1.5f, 0);

        GameObject fireball3 = Instantiate(spitFirePrefab);
        fireball3.transform.position = newPosition;
        FireballBossController fireballBosscontroller3 = fireball3.GetComponent<FireballBossController>();
        fireballBosscontroller3.target = royce.transform.position + new Vector3(0, -1.5f, 0);
    }

    public void FinishThreeShoot() {
        isThreeShoot = false;
        isMoving = true;
    }

    public void Shoot()
    {
        isShoot = true;
    }

    public void RealShoot()
    {
        SoundManager.instance.Stop(SoundID.BOSS_SOUND_B);
        SoundManager.instance.Play(SoundID.BOSS_SOUND_B, false, 0.2f, 0);
        GameObject fireball = Instantiate(spitFirePrefab);
        Vector3 newPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1, 0);
        fireball.transform.position = newPosition;
        FireballBossController fireballBosscontroller = fireball.GetComponent<FireballBossController>();
        fireballBosscontroller.target = royce.transform.position;
    }

    public void FinishShoot()
    {
        isShoot = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            int dir = 1;
            if (!render.flipX) dir = -1;
            rb.AddForce(new Vector2(dir, 1)*10, ForceMode2D.Impulse);
            life = life - 5;
            guiLifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(guiLifeBar.GetComponent<RectTransform>().sizeDelta.x - guiLifeBarStep, guiLifeBar.GetComponent<RectTransform>().sizeDelta.y);
            if (life <= 0) Die();

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12) {
            if (Random.Range(0, 2)==1)
            {
                goingRight = !goingRight;
            }
            else
            {
                subiendo = !subiendo;
            }
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
        Instantiate(keyPrefab);
    }

    public void Move()
    {
        if (isMoving)
        {
            if (transform.position.y >= maxYLimit || !subiendo)
            {
                transform.position += movingSpeed * Time.deltaTime * Vector3.down;
                subiendo = false;
            }
            if (transform.position.y <= minYLimit || subiendo)
            {
                transform.position += movingSpeed * Time.deltaTime * Vector3.up;
                subiendo = true;
            }

            if (transform.position.x <= maxXLimit || goingRight)
            {
                transform.position += movingSpeed * Time.deltaTime * Vector3.right;
                goingRight = true;
            }
            if (transform.position.x >= minXLimit || !goingRight)
            {
                transform.position += movingSpeed * Time.deltaTime * Vector3.left;
                goingRight = false;
            }
        }
    }

    public void AnimationControl() {
        if (isShoot)
        {
            anim.ChangeAnimation("Attack");
        }
        else if (isThreeShoot)
        {
            anim.ChangeAnimation("PowerAttack");
        }
        else if (isMoving)
        {
            anim.ChangeAnimation("Fly");
        }
    }

}