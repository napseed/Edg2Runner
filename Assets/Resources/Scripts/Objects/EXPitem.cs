using Sonity;
using UnityEngine;

public class EXPitem : MonoBehaviour
{
    public LayerMask pMask;
    public float expMount = 10.0f;
    Player player;
    SoundManager sm;

    public SoundEvent expSound;

    // 결국 모든 인스턴스가 플레이어를 프리팹으로 받아야 하는가?
    private void Awake()
    {
        if (Player.Instance != null)
        {
            player = Player.Instance;
        }
        else
        {
            Player.OnPlayerInit += OnPlayerReady;
        }

        sm = SoundManager.Instance;
    }

    void OnPlayerReady(Player pl)
    {
        player = pl;
    }

    // 플레이어에 닿았다면 exp올리고 사라지기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & pMask.value) != 0)
        {
            sm.PlaySFX(expSound);
            player.AddExp(expMount);
            gameObject.SetActive(false);
            return;
        }
    }
}
