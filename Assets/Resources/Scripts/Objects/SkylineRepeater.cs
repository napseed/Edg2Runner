using UnityEngine;

/// <summary>
/// 게임의 배경을 반복해서 스크롤하게 해주는 클래스
/// </summary>
public class SkylineRepeater : MonoBehaviour
{
    public bool needAdjust = false;
    public float scrollSpeed;
    private float scrollWidth = 0.0f;
    private Vector3 secondPos = Vector3.zero;
    private Vector3 repeatPos = Vector3.zero;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        scrollWidth = sr.bounds.size.x;
        repeatPos = new Vector3(scrollWidth * 2.0f, 0, 0);
        secondPos = new Vector3(scrollWidth, 0, 0);
        if (needAdjust)
        {
            AdjustPosForSecond();
        }
    }

    void Update()
    {
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        if (transform.position.x <= -scrollWidth)
        {
            transform.position += repeatPos; 
        }
    }

    // 두번째 이미지를 위해서
    void AdjustPosForSecond()
    {
        transform.position += secondPos;
    }
}
