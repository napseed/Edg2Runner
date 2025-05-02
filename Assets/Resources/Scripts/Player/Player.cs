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

    private void OnDrawGizmos()
    {
        //BoxCollider2D col = GetComponent<BoxCollider2D>();
        //if (col != null)
        //{
        //    Gizmos.color = Color.red;
        //    Vector3 pos = col.transform.position + (Vector3)col.offset;
        //    Vector3 size = new Vector3(col.size.x, col.size.y, 0f);
        //    Gizmos.matrix = col.transform.localToWorldMatrix;
        //    Gizmos.DrawWireCube(col.offset, col.size);
        //}
    }
}
