using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]
    protected float bulletSpeed = 0.0f;
    [SerializeField]
    protected int bulletDamage = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Damage()
    {
        return bulletDamage;
    }
}
