using Sonity;
using System.Collections;
using UnityEngine;

public class WeaponLaser : PlayerWeapon
{
    public SoundEvent laserSfx;
    SoundManager sm;

    [SerializeField]
    private GameObject laser;

    [SerializeField]
    private Coroutine laserCor;

    public float laserRemain = 0.0f;

    public override void InitWeapon()
    {
        Debug.Log("레이저 무기를 이닛합니다");
        sm = SoundManager.Instance;

        laserCor = StartCoroutine(FireCor());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override IEnumerator FireCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireTerm);
            BurstWeapon();
        }
    }

    // 레이저 발사 : 오브젝트를 껐다 켰다 할 뿐
    public override void BurstWeapon()
    {
        sm.PlaySFX(laserSfx);
        laser.SetActive(true);
        Invoke("LaserOff", laserRemain);
    }

    public void LaserOff()
    {
        laser.SetActive(false);
    }
}
