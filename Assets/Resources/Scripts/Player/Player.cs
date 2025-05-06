using Unity.VisualScripting;
using UnityEngine;


/// <summary>
///  플레이어 조작을 다루는 클래스
/// </summary>
public class Player : MonoBehaviour
{
    // 싱글턴
    private static Player instance;

    // get하는 프로퍼티
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<Player>();
                if (instance == null)
                {
                    GameObject player = new GameObject(typeof(Player).Name);
                    instance = player.AddComponent<Player>();

                    DontDestroyOnLoad(player);
                }
            }
            return instance;
        }
    }

    [SerializeField]
    Player player;


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

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private int jumpCount = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            Debug.Log(gameObject.name + "destroyed");
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Player called on " + gameObject.name);
        }

    }

    void Start()
    {
        Initialize();

        jumpState = JumpState.Landed;
        ResetJump();
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
                ChangeState("Jump");
                break;
            case 1:
                rigid.linearVelocityY = 0;
                Jump();
                ChangeState("Djump");
                break;
            case 2:
                Debug.Log("No more jump");
                break;
            default:
                break;
        }

    }
}
