using System.Collections;
using UnityEngine;

public class WeaponDefault : PlayerWeapon
{
    public BulletPool pool;
    public GameObject firePos;

    [SerializeField]
    private Coroutine fireCor;

    public void InitWeapon()
    {
        Debug.Log("기본 무기를 이닛합니다");
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

    void Update()
    {
        
    }

    private IEnumerator FireCor()
    {
        while (true)
        {
            BurstWeapon();
            yield return new WaitForSeconds(fireTerm);
        }
    }

    // 발사
    public void BurstWeapon()
    {
        bullet = pool.GetBullet();
        if (bullet != null)
        {
            bullet.transform.position = firePos.transform.position;
        }

    }
}
