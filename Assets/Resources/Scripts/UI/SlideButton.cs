using UnityEngine;

public class SlideButton : MonoBehaviour
{
    public Player player;
    private Animator animator;
    private BoxCollider2D box;
    private Vector2 standSize = new Vector2(0.68f, 0.77f);
    public Vector2 slideSize = new Vector2(0.68f, 0.36f);
    public Vector2 slideOffset = new Vector2(0, -0.2f);

    public void holdSlide()
    {
        box.size = slideSize;
        box.offset = slideOffset;
        animator.SetBool("bSlide", true);
        Debug.Log("슬라이드 버튼 누름");
    }

    public void releaseSlide()
    {
        box.size = standSize;
        box.offset = Vector2.zero;
        animator.SetBool("bSlide", false);
        Debug.Log("슬라이드 놓음");
    }

    private void Start()
    {
        player = Player.Instance;
        animator = Player.Instance.GetComponent<Animator>();
        box = Player.Instance.GetComponent<BoxCollider2D>();
        standSize = box.size;
    }

    void Update()
    {
        
    }
}
