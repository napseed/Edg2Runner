using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 웨폰 매니저
/// 무기를 종류별로 갖고 있다가 플레이어가 무기를 교체하면 하위 오브젝트로 보내준다
/// </summary>
public class WeaponChanger : MonoBehaviour
{
    public GameObject[] primaries;
    public GameObject[] secondaries;

    public GameObject primaryNow;
    public GameObject secondaryNow;

    public BulletPool dPool;
    public BulletPool mPool;

    public int primNum;
    public int secNum;
    public int DeactiveNum = 999;

    bool bSwitch;

    private void Start()
    {
        
    }

    void Update()
    {

    }

    public void ActivateWeapon1(int num)
    {
        if (primaryNow != null)
        {
            primaryNow.SetActive(false);
        }
        primaries[num].SetActive(true);
        // 같은 무기로 바꾸면 서로 교환
        if ((num == secNum) && !bSwitch)
        {
            bSwitch = true;
            ActivateWeapon2(primNum);
        }
        primNum = num;
        primaryNow = primaries[num];
        bSwitch = false;
    }

    public void ActivateWeapon2(int num)
    {
        if (secondaryNow != null)
        {
            secondaryNow.SetActive(false);
        }
        secondaries[num].SetActive(true);
        // 같은 무기로 바꾸면 서로 교환
        if ((num == primNum) && !bSwitch)
        {
            bSwitch = true;
            ActivateWeapon1(secNum);
        }
        secNum = num;
        secondaryNow = secondaries[num];
        bSwitch = false;
    }
}
