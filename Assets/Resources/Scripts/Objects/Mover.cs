using UnityEngine;

public class Mover : MonoBehaviour
{
    public float moveSpeed;

    void Start()
    {
        Invoke("Kill", 10.0f);
    }

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void Kill()
    {
        Destroy(gameObject);    
    }
}
