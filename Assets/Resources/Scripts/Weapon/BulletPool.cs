using UnityEngine;


/// <summary>
/// 총알의 객체 풀
/// </summary>
public class BulletPool : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int poolSize;
    private GameObject[] bullets;
    //private int idx = 0;

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

    void Start()
    {
        
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
