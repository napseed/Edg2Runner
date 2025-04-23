using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    /// <summary>
    /// 지형을 생성 및 파괴하는 클래스
    /// </summary>
    /// 
    // 배열에 담는게 좋으려나
    [SerializeField]
    private GameObject[] terrains;

    //float elapsedTime = 0.0f;
    [SerializeField]
    float spawnTerm = 2.0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnPlane), 0f, spawnTerm);
    }

    void Update()
    {
        

    }

    void SpawnPlane()
    {
        Instantiate(terrains[0], transform.position, Quaternion.identity);
    }
    // 일단 처음은 플레인을 계속 생성하고
    // 모든 플레인은 좌측으로 밀어주면서
    // 일정 거리 이상의 플레인을 삭제시켜야 한다
}
