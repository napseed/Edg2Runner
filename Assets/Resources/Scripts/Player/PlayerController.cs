using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum JumpState
    {
        Landed,
        Jumped,
        Djumped,
        Falled,
    }

    [SerializeField]
    private JumpState jumpState;

    private Rigidbody2D rigid;
    private Collider2D col;

    [SerializeField]
    private float jumpForce;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    void Start()
    {
        jumpState = JumpState.Landed;
        
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (rigid.linearVelocityY < 0)
        {
            Vector2 bottomLeft = new Vector2(col.bounds.min.x, col.bounds.min.y);

            RaycastHit2D rHit = Physics2D.Raycast(bottomLeft, Vector2.down, 0.1f, LayerMask.GetMask("Platform"));
            
            // 착지
            if (rHit.collider != null)
            {
                jumpState = JumpState.Landed;
            }
            // 점프 막기
            else if (jumpState == JumpState.Djumped)
            {
                jumpState = JumpState.Falled;
            }
            // 떨어진다면 점프 한번은 허용
            else if (jumpState == JumpState.Landed)
            {
                jumpState = JumpState.Jumped;
            }
        }
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log($"{jumpState}");
    }

    public void PlayerJump()
    {
        switch(jumpState)
        {
            case JumpState.Landed:
                Jump();
                jumpState = JumpState.Jumped;
                break;
            case JumpState.Jumped:
                rigid.linearVelocityY = 0;
                Jump();
                jumpState = JumpState.Djumped;
                break;
            case JumpState.Djumped:
                Debug.Log("Jump not available");
                break;
        }
    }
}
