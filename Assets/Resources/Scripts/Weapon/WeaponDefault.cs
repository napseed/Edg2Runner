using Sonity;
using System.Collections;
using UnityEngine;

public class WeaponDefault : PlayerWeapon
{
    public string targetPoolID = "D";
    public BulletPool pool;
    public GameObject firePos;
    public SoundEvent fireSfx;
    SoundManager sm;

    [SerializeField]
    private Coroutine fireCor;

    public override void InitWeapon()
    {
        Debug.Log("기본 무기를 이닛합니다");
        sm = SoundManager.Instance;

        fireCor = StartCoroutine(FireCor());
    }

    private void Awake()
    {
    }

    private void OnEnable()
    {
        pool.OnBulletPoolInit += AssignPool;
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
        Debug.Log($"{gameObject.name} TryAssignPool 호출됨");
        Debug.Log($"  - 내가 원하는 ID : '{targetPoolID}'");
        Debug.Log($"  - 전달된 풀 ID   : '{pl.poolID}'");

        if (pl.poolID == targetPoolID)
        {
            pool = pl;
            InitWeapon();
        }
    }

    void Update()
    {
        
    }

    public override IEnumerator FireCor()
    {
        while (true)
        {
            BurstWeapon();
            yield return new WaitForSeconds(fireTerm);
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
