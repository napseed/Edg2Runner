using Sonity;
using UnityEngine;
using static Player;

public class PlayerEdgeCollider : MonoBehaviour
{
    public Player player;
    public int platformLayer;
    public Rigidbody2D rg;
    SoundManager sm;
    public SoundEvent landSE;

    private void Awake()
    {
        player = transform.parent.GetComponent<Player>();
        platformLayer = LayerMask.NameToLayer("PlatformCollider");
        rg = player.GetComponent<Rigidbody2D>();
        sm = SoundManager.Instance;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == platformLayer)
        {
            Debug.Log("착지!");
            player.ChangeState("Land");
            player.ResetJump();
            sm.PlaySFX(landSE);
        }
    }

}
