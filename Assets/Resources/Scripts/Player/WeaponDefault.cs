using UnityEngine;

public class WeaponDefault : PlayerWeapon
{
    [SerializeField]
    private GameObject[] defaultBullets = new GameObject[10];

    void Start()
    {
        // 시작하면 총알을 한 10개 만들고 싹다 비활성화
        for (int i = 0; i < 10; i++)
        {
            defaultBullets[i] = Instantiate(bullet, transform.position, Quaternion.identity);
            defaultBullets[i].SetActive(false);
        }
    }

    void Update()
    {
        
    }

    // 오브젝트 풀 만들어야 된다.
    // 어떻게 만드냐?
    // 스택을 만들어야 겠지
    public void BurstWeapon()
    {

    }
}
