using Sonity;
using System.Collections;
using UnityEngine;

public class WeaponMachine : PlayerWeapon
{
    public BulletPool pool;
    public GameObject firePos;
    public SoundEvent fireSfx;
    public int maxMag;
    public float interval;
    SoundManager sm;

    private Coroutine fireCor;

    public override void InitWeapon()
    {
        Debug.Log("기관총 무기를 이닛합니다");
        sm = SoundManager.Instance;

        fireCor = StartCoroutine(FireCor());
    }

    private void OnEnable()
    {

    }


    private void OnDisable()
    {
        if (fireCor != null)
        {
            StopCoroutine(fireCor);
        }
    }

    private void Update()
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

    public override void BurstWeapon()
    {
        for (int i = 0; i < maxMag; i++)
        {
            bullet = pool.GetBullet();
            if (bullet != null)
            {
                sm.PlaySFX(fireSfx);
                bullet.transform.position = firePos.transform.position;
            }
        }
    }
}
