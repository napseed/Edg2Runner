using Sonity;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
///  플레이어 조작을 다루는 클래스
/// </summary>
public class Player : MonoBehaviour
{

    // 플레이어 초기화 이벤트
    public static event Action<Player> OnPlayerInit;

    // 싱글턴
    private static Player instance;

    // get하는 프로퍼티
    public static Player Instance => instance;
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindFirstObjectByType<Player>();
    //            if (instance == null)
    //            {
    //                GameObject player = new GameObject(typeof(Player).Name);
    //                instance = player.AddComponent<Player>();

    //                DontDestroyOnLoad(player);
    //            }
    //        }
    //        return instance;
    //    }
    //}

    [SerializeField]
    Player player;
    [SerializeField]
    private float HP = 10.0f;
    [SerializeField]
    private float EXP = 0.0f;
    [SerializeField]
    private float MaxEXP = 0.0f;
    [SerializeField]
    private float expMultiplier = 0.0f;

    public enum JumpState
    {
        Landed,
        Jumped,
        Djumped,
        Falled,
    }


    public JumpState jumpState;

    private Rigidbody2D rigid;
    private Collider2D col;
    public Animator anim;
    SoundManager sm;

    public SoundEvent slideSound;
    public SoundEvent jumpSound;
    public SoundEvent dJumpSound;
    public SoundEvent dmgSound;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private int jumpCount = 0;

    public Image expGauge;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + "destroyed");
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("Player called on " + gameObject.name);
        OnPlayerInit?.Invoke(this);
    }

    void Start()
    {
        Initialize();

        jumpState = JumpState.Landed;
        ResetJump();
        AdjustEXPGauge();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 bottomLeft = new Vector2(col.bounds.min.x, col.bounds.min.y);
        Vector2 bottomRight = new Vector2(col.bounds.max.x, col.bounds.min.y);

        RaycastHit2D lHit = Physics2D.Raycast(bottomLeft, Vector2.down, 1.0f, LayerMask.GetMask("PlatformCollider"));
        RaycastHit2D rHit = Physics2D.Raycast(bottomRight, Vector2.down, 1.0f, LayerMask.GetMask("PlatformCollider"));

        if (rigid.linearVelocityY < 0 && (lHit.collider == null && rHit.collider == null))
        {
            if (jumpCount == 0)
            {
                ChangeState("Fall");
                jumpCount++;
            }
        }
    }

    void Initialize()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        sm = SoundManager.Instance;
    }

    public void ResetJump()
    {
        jumpCount = 0;
    }

    public void ChangeState(string param)
    {
        switch (param)
        {
            case "Land":
                jumpState = JumpState.Landed;
                break;
             case "Jump":
                jumpState = JumpState.Jumped;
                break;
                case "Djump":
                jumpState = JumpState.Djumped;
                break;
                case "Fall":
                jumpState = JumpState.Falled;
                break;
        }

    }

    public void Slide()
    {
        sm.PlaySFX(slideSound);
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpCount++;
    }

    public void FreeGravity()
    {
        rigid.linearVelocityY = 0.0f;
    }

    public void PlayerJump()
    {
        switch (jumpCount)
        {
            case 0:
                Jump();
                sm.PlaySFX(jumpSound);
                ChangeState("Jump");
                break;
            case 1:
                rigid.linearVelocityY = 0;
                Jump();
                sm.PlaySFX(dJumpSound);
                ChangeState("Djump");
                break;
            case 2:
                Debug.Log("No more jump");
                break;
            default:
                break;
        }

    }

    public void GetDamage(int val)
    {
        anim.SetBool("bHit", true);
        HP -= val;
        sm.PlaySFX(dmgSound);
        Debug.Log($"HP is dereased by {val}. remain HP : {HP}");
        CheckDeath();
    }

    public void RecoverHit()
    {
        anim.SetBool("bHit", false);
    }

    void CheckDeath()
    {

    }

    public void AddExp(float val)
    {
        EXP += val;
        //Debug.Log($"Exp is added by {val}. Current exp amount is {EXP}.");
        AdjustEXPGauge();
    }

    public void MaxExpExtend()
    {
        MaxEXP *= expMultiplier;
        Debug.Log("Max exp has been adjusted");
    }

    public void AdjustEXPGauge()
    {
        expGauge.fillAmount = EXP / MaxEXP;
        if (expGauge.fillAmount >=  1)
        {
            Debug.Log("Level UP");
            // TODO : 시간 정지 후 플레이어 업그레이드 팝업
            MaxExpExtend();
            EXP = 0;
            AdjustEXPGauge();
        }
    }
}
