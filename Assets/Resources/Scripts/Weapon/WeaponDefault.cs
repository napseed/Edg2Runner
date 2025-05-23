using Sonity;
using System.Collections;
using System.Threading;
using UnityEngine;

public class WeaponDefault : PlayerWeapon
{
    public string targetPoolID = "D";
    public BulletPool pool;
    public GameObject firePos;
    public SoundEvent fireSfx;
    public float coolDown;      // 발사 간 시간
    SoundManager sm;

    [SerializeField]
    private Coroutine fireCor;

    public enum FireState
    {
        Idle,
        Fire,
        Cooldown,
        Unavailable,
    }

    public FireState curState = FireState.Idle;

    private float timer = 0.0f;

    public override void InitWeapon()
    {
        Debug.Log("기본 무기를 이닛합니다");
        sm = SoundManager.Instance;
        curState = FireState.Fire;
    }


    private void OnEnable()
    {
        pool.OnBulletPoolInit += AssignPool;
        InitWeapon();
    }

    private void OnDisable()
    {
        if (fireCor != null)
        {
            StopCoroutine(fireCor);
        }
        pool.OnBulletPoolInit -= AssignPool;
    }

    void AssignPool(BulletPool pl)
    {
        //Debug.Log($"{gameObject.name} TryAssignPool 호출됨");
        //Debug.Log($"  - 내가 원하는 ID : '{targetPoolID}'");
        //Debug.Log($"  - 전달된 풀 ID   : '{pl.poolID}'");

        if (pl.poolID == targetPoolID)
        {
            pool = pl;
            InitWeapon();
        }
    }

    void Update()
    {
        switch (curState)
        {
            case FireState.Idle:
                break;

            case FireState.Fire:
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    BurstWeapon();
                    timer = coolDown;

                }
                break;
            case FireState.Unavailable:
                break;
        }
    }


    // 발사
    public override void BurstWeapon()
    {
        bullet = pool.GetBullet();

        if (bullet != null)
        {
            sm.PlaySFX(fireSfx);
            bullet.transform.position = firePos.transform.position;
        }

    }
}
