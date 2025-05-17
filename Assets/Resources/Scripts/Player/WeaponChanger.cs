using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 웨폰 매니저
/// 무기를 종류별로 갖고 있다가 플레이어가 무기를 교체하면 하위 오브젝트로 보내준다
/// </summary>
public class WeaponChanger : MonoBehaviour
{
    public List<GameObject> pWeapons = new List<GameObject>();

    public GameObject primary;
    public GameObject secondary;

    public void Init()
    {

    }

    void Update()
    {
        
    }

    public void AddWeapon(GameObject weapon)
    {
        pWeapons.Add(weapon);
        return;
    }

    public void AttachPrimaryWeapon(GameObject child)
    {
        child.transform.SetParent(primary.transform);
        child.transform.localPosition = Vector3.zero;
        child.transform.localRotation = Quaternion.identity;
    }
    public void AttachSecondaryWeapon(GameObject child)
    {
        child.transform.SetParent(secondary.transform);
        child.transform.localPosition = Vector3.zero;
        child.transform.localRotation = Quaternion.identity;
    }
}
