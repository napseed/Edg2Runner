using System.Collections;
using UnityEngine;


/// <summary>
/// 플레이어가 달 무기 클래스
/// 여러 무기들은 이 클래스를 상속받아서 사용하자
/// </summary>
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected float fireTerm;

    public virtual void InitWeapon()
    {
        return;
    }

    public virtual IEnumerator FireCor()
    {
        yield return null;
    }

    public virtual void BurstWeapon()
    {
        return;
    }
}
