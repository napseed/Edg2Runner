using Unity.VisualScripting;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Player player;
    public GameObject rPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("플레이어가 죽었다");
        player.GetComponent<PlayerController>().FreeGravity();
        player.transform.position = rPoint.transform.position;
    }
}
