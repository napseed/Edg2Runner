using UnityEngine;

public class BulletDefault : PlayerBullet
{
    public BulletPool pool;
    public float lifeTerm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Invoke("ReturnToPool", lifeTerm);
    }

    private void OnDisable()
    {
        CancelInvoke("ReturnToPool");
    }

    public void SetPool(BulletPool mPool)
    {
        pool = mPool;
    }

    void ReturnToPool()
    {
        Debug.Log("기본 총알을 풀로 복구");
        pool.ReturnBullet(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReturnToPool();
    }
}
