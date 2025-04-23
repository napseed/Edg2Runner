using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = gameObject;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
