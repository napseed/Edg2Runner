using System.Collections;
using UnityEngine;

/// <summary>
/// 적의 속성을 정의하는 최상위 클래스
/// </summary>
public class Enemy : MonoBehaviour
{
    public LayerMask bulletMask;
    protected float HP;
    public int DMG;
    public Sprite damagedSprite;
    protected SpriteRenderer sr;
    protected BoxCollider2D box;
    public LayerMask pMask;
    [SerializeField]
    private Player player;


    void Init()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        Init();

        if (Player.Instance != null)
        {
            player = Player.Instance;
        }
        else
        {
            Player.OnPlayerInit += OnPlayerReady;
        }
    }

    private void OnDisable()
    {
        Player.OnPlayerInit -= OnPlayerReady;
    }

    void OnPlayerReady(Player pl)
    {
        player = pl;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & bulletMask.value) != 0)
        {
            Debug.Log($"{gameObject.name} is hit by {collision.gameObject}");
            HP -= collision.gameObject.GetComponent<PlayerBullet>().Damage();
            CheckDeath();
        }

        else if (((1 << collision.gameObject.layer) & pMask.value) != 0)
        {
            DestroyBox();
            player.GetDamage(DMG);
            Debug.Log($"player is hit by {gameObject}");
        }
    }

    void CheckDeath()
    {
        if (HP <= 0)
        {
            sr.sprite = damagedSprite;
            if (box != null)
            {
                DestroyBox();
            }
            StartCoroutine(DestroyCor());
        }
    }


    protected void DestroyBox()
    {
        Destroy(box);
    }

    IEnumerator DestroyCor()
    {
        yield return new WaitForSeconds(1.0f);
        // 이펙트
        Destroy(gameObject);
    }
}
