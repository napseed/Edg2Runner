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

    public void InitWeapon()
    {
        Debug.Log("레이저 무기를 이닛합니다");
        sm = SoundManager.Instance;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LaserCor()
    {
        while (true)
        {
            BurstWeapon();
            yield return new WaitForSeconds(fireTerm);
        }
    }

    // 레이저 발사 : 오브젝트를 껐다 켰다 할 뿐
    public void BurstWeapon()
    {

    }
}
