using System.Collections;
using UnityEngine;

public class HiddenButtons : MonoBehaviour
{
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;

    public Vector3 b1pos; 
    public Vector3 b2pos; 
    public Vector3 b3pos;
    public Vector3 hPos;

    private Coroutine curCor;
    public float riseTime = 0.0f;

    private void Awake()
    {
        b1pos = b1.transform.position;
        b2pos = b2.transform.position;
        b3pos = b3.transform.position;
        hPos = gameObject.transform.position;
    }

    private void OnEnable()
    {
        b1.transform.position = hPos;
        b2.transform.position = hPos;
        b3.transform.position = hPos;

        // 활성화 되었으니 코루틴 시작하기
        StartUp();
    }


    public void StartUp()
    {
        curCor = StartCoroutine(UpButtonCor());
    }

    public void StartDown()
    {
        curCor = StartCoroutine(DownButtonCor());
    }


    // UI를 올리는 코루틴
    public IEnumerator UpButtonCor()
    {
        float elapsedTime = 0.0f;
        
        while (elapsedTime < riseTime)
        {
            elapsedTime += Time.deltaTime;
            b1.transform.position = Vector3.Lerp(hPos, b1pos, elapsedTime / riseTime);
            b2.transform.position = Vector3.Lerp(hPos, b2pos, elapsedTime / riseTime);
            b3.transform.position = Vector3.Lerp(hPos, b3pos, elapsedTime / riseTime);

            yield return null;
        }
    }

    // 내리는 코루틴
    public IEnumerator DownButtonCor()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < riseTime)
        {
            elapsedTime += Time.deltaTime;
            b1.transform.position = Vector3.Lerp(b1pos, hPos, elapsedTime / riseTime);
            b2.transform.position = Vector3.Lerp(b2pos, hPos, elapsedTime / riseTime);
            b3.transform.position = Vector3.Lerp(b3pos, hPos, elapsedTime / riseTime);

            yield return null;
        }
    }
}
