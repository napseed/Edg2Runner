using UnityEngine;


/// <summary>
/// 여기서 순서대로 초기화하자
/// </summary>
public class InitManager : MonoBehaviour
{
    public BulletPool pool;
    public WeaponDefault weaponDefault;
    public WeaponDefault weaponDefault2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pool.InitPool();
        weaponDefault.InitWeapon();
        weaponDefault2.InitWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
