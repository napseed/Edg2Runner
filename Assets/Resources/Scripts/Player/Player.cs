using UnityEngine;


/// <summary>
/// 플레이어 클래스
/// 컨테이너 그 이상의 역할을 할 수 있을까
/// </summary>
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
