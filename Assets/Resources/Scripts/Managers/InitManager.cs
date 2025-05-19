using UnityEngine;


/// <summary>
/// 여기서 순서대로 초기화하자
/// </summary>
public class InitManager : MonoBehaviour
{
    public BulletPool Dpool;
    public BulletPool Mpool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Dpool.InitPool();
        Mpool.InitPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
