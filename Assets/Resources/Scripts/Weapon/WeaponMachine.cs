using Sonity;
using System.Collections;
using UnityEngine;

public class WeaponMachine : PlayerWeapon
{
    public string targetPoolID = "M";
    public BulletPool pool;
    public GameObject firePos;
    public SoundEvent fireSfx;
    public int magCount;      // 발사수
    public float interval;      // 총알 간 시간
    public float coolDown;  // 발사 간 시간
    SoundManager sm;

    public enum FireState
    {
        Idle,
        Fire,
        Cooldown,
        Unavailable,
    }

    public FireState curState = FireState.Idle;

    private float timer = 0.0f;
    private int shotsFire = 0;


    public override void InitWeapon()
    {
        Debug.Log("기관총 무기를 이닛합니다");
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

    private void Update()
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
                    shotsFire++;
                    timer = interval;

                    if (shotsFire >= magCount)
                    {
                        curState = FireState.Cooldown;
                        timer = coolDown;
                        shotsFire = 0;
                    }
                }
                break;

            case FireState.Cooldown:
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    curState = FireState.Fire;
                    timer = 0.0f;
                }
                break;
            case FireState.Unavailable:
                break;
        }
    }


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
