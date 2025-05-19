using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 총알의 객체 풀
/// </summary>
public class BulletPool : MonoBehaviour
{
    public event Action<BulletPool> OnBulletPoolInit;
    public string poolID;
    public static Dictionary<string, BulletPool> Pools = new();

    public GameObject bulletPrefab;
    public int poolSize;
    private GameObject[] bullets;

    public void InitPool()
    {
        bullets = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].GetComponent<BulletDefault>().SetPool(gameObject.GetComponent<BulletPool>());
            bullets[i].SetActive(false);
        }
    }

    private void Awake()
    {
        InitPool();
        Pools[poolID] = this;
    }

    private void Start()
    {
        OnBulletPoolInit?.Invoke(this);
    }

    public GameObject GetBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!bullets[i].activeInHierarchy)
            {
                bullets[i].SetActive(true);
                return bullets[i];
            }

        }

        return null;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }

}
