using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool isInStair;
    public bool isBajando;
    public bool isSubiendo;
    public bool isMoving;
    public bool isJumping;
    public bool isRealJumping;
    public bool isFalling;
    public bool isInGround;
    public bool isTouchPlatform;
    public bool isPunch;
    public bool isFire;
    public bool isAttachedToStair;
    public bool isDamaged;
    public bool isDead;

    public bool isGunEquiped;
    public bool isKeyEquiped;


    // cambios en el player
    public bool isOnLever;
    public LeverController currentLeverController;
    // hasta aca


    public bool isEntering;
    public bool isExiting;
    public bool isOnDoor;
    public bool isOnCloseDoor;
    public bool isInWinnerDoor;
    public DoorController currentDoorController;
    
    public Vector3 newExitPosition;

    public float speed;

    public float jumpImpulse;
    public float climbSpeed;

    public SpriteRenderer render;
    public Rigidbody2D rb;
    public AnimationControllerCustom anim;
    public ChildColliderManager childColliderManager;
    public Text diamondCount;
    public Text livesCount;

    public GameObject gameOverImage;
    public GameObject winImage;

    public GameObject bulletPrefab;

    private SceneManagerCustom sceneManagerCustom;

    public bool isFinishAnimation;
    public float isFinishAnimationSpeed;
    public float isFinishAnimationTimer;
    public float isFinishAnimationCurrentTimer;

    public bool isWin;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<AnimationControllerCustom>();
        childColliderManager = GetComponent<ChildColliderManager>();
        diamondCount = GameObject.Find("DiamondCounter").GetComponent<Text>();
        livesCount = GameObject.Find("LivesCounter").GetComponent<Text>();
        gameOverImage = GameObject.Find("GameOver");
        winImage = GameObject.Find("Win");
        sceneManagerCustom = GetComponent<SceneManagerCustom>();

        SetLives(10);
    }

    void Update() {
        Transform trans = null;
        if (isFinishAnimation){
            isFinishAnimationCurrentTimer += Time.deltaTime;
            if (isFinishAnimationTimer < isFinishAnimationCurrentTimer)
            {
                if (isWin)
                {
                    sceneManagerCustom.ChangeToNextScene();
                }
                else
                {
                    sceneManagerCustom.ChangeToStartMenuScene();
                }
            }
        }
        if (isFinishAnimation && isDead) {
            trans = gameOverImage.GetComponent<RectTransform>().transform;
        }
        if (isFinishAnimation && isWin)
        {
            trans = winImage.GetComponent<RectTransform>().transform;
        }
        if (trans != null) {
            float x = trans.position.x + isFinishAnimationSpeed * Time.deltaTime * -1;
            if (x > Screen.width/2) {
                trans.position = new Vector3(x, trans.position.y, trans.position.z);
            }
            
        }
    }

    void FixedUpdate()
    {
        if (!isDamaged)
        {
            if (isInGround && !isMoving && !isJumping && !isSubiendo && !isBajando && !isInStair)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            if (rb.velocity.y > 0 && isRealJumping)
            {
                isJumping = true;
                isFalling = false;
            }
            else if (rb.velocity.y < 0 && !isInGround)
            {
                isFalling = true;
                isJumping = false;
            }
            else {
                isFalling = false;
                isJumping = false;
                isRealJumping = false;
            }

            if (isInStair && (!isInGround || (isInGround &&(isSubiendo||isBajando))) && (!isRealJumping || (isRealJumping && (isSubiendo || isBajando))) && !isAttachedToStair)
            {
                mountInStair();
            }

            if(((!isInStair)|| (isInStair && isInGround))&& isAttachedToStair)
            {
                unmountInStair();
            }
        }
    }

    void SetLives(int newLivesNum) {
        GameManager.instance.lives = newLivesNum;
        livesCount.text = GameManager.instance.lives.ToString();
    }

    void RemoveLive() {
        SetLives(GameManager.instance.lives - 1);
        if (GameManager.instance.lives == 0) {
            Kill();
        }
    }

    void Kill() {
        SetLives(0);
        isDead = true;
        rb.velocity = Vector2.zero;
        SoundManager.instance.Play(SoundID.GAMEOVER,false,0.3f,2);
    }

    void LateUpdate()
    {
        AnimationControl();
    }

    public void mountInStair() {
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        isAttachedToStair = true;
        isInGround = false;
    }

    public void unmountInStair(){
        rb.gravityScale = 1;
        rb.velocity = Vector2.zero;
        isAttachedToStair = false;
    }

    public void Move(float dir)
    {
        if (isEntering || isExiting || isPunch || isFire) return;
        isMoving = true;
        if (dir == 1) render.flipX = false;
        else render.flipX = true;

        Vector2 direct = new Vector2(dir * speed, rb.velocity.y);
        rb.velocity = direct;
    }

    public void Jump()
    {
        if (isInGround&&!isPunch&&!isFire) {
            SoundManager.instance.Stop(SoundID.JUMP_1);
            SoundManager.instance.Play(SoundID.JUMP_1, false, 0.1f, 0);
            isJumping = true;
            isRealJumping = true;
            rb.AddForce(Vector2.up * jumpImpulse, ForceMode2D.Impulse);
        }
    }

    public void Punch() {
        if (!isPunch && !isRealJumping) {
            SoundManager.instance.Stop(SoundID.AIRPUNCH);
            SoundManager.instance.Play(SoundID.AIRPUNCH, false, 0.05F, 0);
            isPunch = true;
            isMoving = false;
        }
    }

    public void Fire() {
        if (!isGunEquiped) return;
        isFire = true;
        DontMove();
    }

    public void FireBullet()
    {
        float offsetX = 0.5f;
        float offsetY = 0.78f;
        GameObject bullet = Instantiate(bulletPrefab);
        int dir = 1;
        if (render.flipX)
        {
            dir = -1;
            offsetX = -offsetX;
        }
        Vector3 newPosition = new Vector3(this.transform.position.x + offsetX, this.transform.position.y + offsetY, 0);
        bullet.transform.position = newPosition;
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.Fire(dir);
        SoundManager.instance.Stop(SoundID.GUNSHOT);
        SoundManager.instance.Play(SoundID.GUNSHOT, false, 0.05F, 0);
    }

    public void EndFire()
    {
        isFire = false;
    }

    public void FinishPunch()
    {
        isPunch = false;
    }

    public void ActivatePunchCollider()
    {
        if (render.flipX) {
            childColliderManager.ActivateCollider("PunchLeft", true);
        } else {
            childColliderManager.ActivateCollider("PunchRight", true);
        }
    }

    public void DesactivatePunchCollider()
    {
        childColliderManager.ActivateCollider("PunchLeft", false);
        childColliderManager.ActivateCollider("PunchRight", false);
    }

    public void OpenDoor() {
        newExitPosition = currentDoorController.Open();
        if (isOnCloseDoor) {
            currentDoorController.gameObject.GetComponentsInChildren<SpriteRenderer>()[1].enabled = false;
        }
        isEntering = true;
    }

    public void PushLever() {
        currentLeverController.PushLever();
    }

    public void ExitDoor()
    {
        if (!isInWinnerDoor)
        {
            transform.position = newExitPosition;
            isEntering = false;
            isExiting = true;
        }
        else {
            render.enabled = false;
            isWin = true;
            isFinishAnimation = true;
            SoundManager.instance.Play(SoundID.WIN,false,0.05f,0);
        }
    }

    public void FinishExiting()
    {
        isExiting = false;
    }

    public void GameOverAnimation() {
        isFinishAnimation = true;
    }

    public void ExecuteAction() {
        if (isOnCloseDoor){
            OpenDoor();
        }
        if (isOnDoor) {
            OpenDoor();
        }
        if (isOnLever) {
            PushLever();
        }
    }

    public void DamagedStart()
    {
        isDamaged = true;
        isPunch = false;
    }

    
    public void DamagedFinish() {
        isDamaged = false;
        rb.gravityScale = 1;
        RemoveLive();
    }

    void catchDiamond() {
        SoundManager.instance.Stop(SoundID.JEWEL);
        SoundManager.instance.Play(SoundID.JEWEL, false, 0.05f, 0);
        GameManager.instance.diamonds++;
        diamondCount.text = GameManager.instance.diamonds.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if ((!(isJumping || isFalling)) || (isBajando || isSubiendo))
            {
                isInStair = true;
            }
        }

        if (collision.gameObject.layer == 14)
        {
            DamagedStart();
        }

        if (collision.gameObject.layer == 20)
        {
            Destroy(collision.gameObject);
            catchDiamond();
        }

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            SoundManager.instance.Play(SoundID.JUMP_2, false, 0.02F, 0);
            isInGround = true;
            isJumping = false;
            isFalling = false;
            isRealJumping = false;
        }

        if (collision.gameObject.layer == 19)
        {
            Kill();
            render.color = new Color(255, 255, 255, 0.2f);
        }

        if (collision.gameObject.layer == 23)
        {
            SoundManager.instance.Stop(SoundID.POSITIVE_SOUND);
            SoundManager.instance.Play(SoundID.POSITIVE_SOUND, false, 0.2F, 0);
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("GUI-GunItem").GetComponent<Image>().enabled = true;
            isGunEquiped = true;
        }

        if (collision.gameObject.layer == 24)
        {
            SoundManager.instance.Stop(SoundID.POSITIVE_SOUND);
            SoundManager.instance.Play(SoundID.POSITIVE_SOUND, false, 0.2F, 0);
            Destroy(collision.gameObject);
            SetLives(GameManager.instance.lives+1);
        }

        if (collision.gameObject.layer == 25)
        {
            SoundManager.instance.Stop(SoundID.POSITIVE_SOUND);
            SoundManager.instance.Play(SoundID.POSITIVE_SOUND, false, 0.2F, 0);
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("GUI-KeyItem").GetComponent<Image>().enabled = true;
            isKeyEquiped = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        // cambios en el player
        if (collision.gameObject.layer == 22)
        {
            currentLeverController = collision.gameObject.GetComponent<LeverController>();
            isOnLever = true;
        }
        // hasta aca.

        if (collision.gameObject.layer == 12)
        {
            transform.parent = collision.transform;
        }
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            isInGround = true;
        }

        if (collision.gameObject.layer == 8)
        {
            if ((!(isJumping || isFalling)) || (isBajando || isSubiendo))
            {
                isInStair = true;
            }
        }
        if (collision.gameObject.layer == 16)
        {
            if (!isOnDoor) {
                isOnDoor = true;
                currentDoorController = collision.gameObject.GetComponent<DoorController>();
                if (currentDoorController.isWinnerDoor)
                {
                    isInWinnerDoor = true;
                }
                else
                {
                    isInWinnerDoor = false;
                }
            }
        }
        if (collision.gameObject.layer == 27)
        {
            if (!isOnCloseDoor&&isKeyEquiped)
            {
                isOnCloseDoor = true;
                currentDoorController = collision.gameObject.GetComponent<DoorController>();
                if (currentDoorController.isWinnerDoor)
                {
                    isInWinnerDoor = true;
                }
                else
                {
                    isInWinnerDoor = false;
                }
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            transform.parent = null;
        }
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12 || collision.gameObject.layer == 13)
        {
            isInGround = false;
        }
        if (collision.gameObject.layer == 8)
        {
            isInStair = false;
        }
        if (collision.gameObject.layer == 16)
        {
            isOnDoor = false;
        }
        if (collision.gameObject.layer == 22)
        {
            isOnLever = false;
        }
        if (collision.gameObject.layer == 16)
        {
            isOnCloseDoor = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            DamagedStart();
            rb.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
            if (collision.gameObject.transform.position.x <= this.transform.position.x)
            {
                rb.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
            }
        }
    }


    public void Climb(int dir)
    {   
        rb.position += new Vector2(0, climbSpeed*dir);
    }

    public void Up(bool value)
    {
        isSubiendo = value;
        if (isSubiendo && isAttachedToStair) Climb(1);
    }
    public void Down (bool value)
    {
        isBajando = value;
        if (isBajando && isAttachedToStair) Climb(-1);
    }



    public void DontMove()
    {
        if (isDamaged) return;
        isMoving = false;
        Vector2 direct = new Vector2(0, rb.velocity.y);
        rb.velocity = direct;
    }

    public void AnimationControl()
    {
        if (isDead) anim.ChangeAnimation("Deading");
        else if (isDamaged) anim.ChangeAnimation("Damaged");
        else if (isEntering) anim.ChangeAnimation("Entering");
        else if (isExiting) anim.ChangeAnimation("Exiting");
        else if (isFire) {
            if (isJumping || isFalling)
            {
                anim.ChangeAnimation("FireJump");
            }
            else {
                anim.ChangeAnimation("Fire");
            }

        } 
        else if (isJumping || isFalling) anim.ChangeAnimation("Jumping");
        else if (isMoving && isInGround) anim.ChangeAnimation("Walking");
        else if ((isSubiendo || isBajando) && isInStair)
        {
            anim.ChangeAnimation("Subiendo");
            anim.SetPlaying(true);

        }
        else if (!isSubiendo && !isBajando && !isInGround && isInStair)
        {
            anim.ChangeAnimation("Subiendo");
            anim.SetPlaying(false);

        }
        else if (isPunch) 
        {
            anim.ChangeAnimation("Punch");
        }
        else if (isInGround) anim.ChangeAnimation("Idle");

    }
}
