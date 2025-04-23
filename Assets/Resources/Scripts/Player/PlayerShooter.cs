using UnityEngine;


/// <summary>
/// 플레이어의 총알을 쏘게 해주는 슈터 클래스
/// 가진 아이템에 따라 다른 총알을 쏘게 설계하고 싶다
/// </summary>
public class PlayerShooter : MonoBehaviour
{
    // 무기를 두 개 들고 있어서 서로 스위칭이 가능하게 하자
    // 라이크 메탈슬러그
    [SerializeField]
    private int[] primarys = new int[2];

    void Start()
    {
        // 주 무장이 비었다면 == 게임을 처음 시작했다면
        if (primarys[0] == 0)
        {
            primarys[0] = 1;
        }
    }

    void Update()
    {
        
    }
}
