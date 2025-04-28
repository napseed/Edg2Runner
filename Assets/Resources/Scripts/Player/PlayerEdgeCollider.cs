using UnityEngine;
using static PlayerController;

public class PlayerEdgeCollider : MonoBehaviour
{
    public PlayerController player;
    public int platformLayer;
    public Rigidbody2D rg;


    private void Awake()
    {
        player = transform.parent.GetComponent<PlayerController>();
        platformLayer = LayerMask.NameToLayer("PlatformCollider");
        rg = player.GetComponent<Rigidbody2D>();
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
        }
    }

}
