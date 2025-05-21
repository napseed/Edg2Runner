using System.Collections;
using UnityEngine;

public class ActivateWeaponButtons : MonoBehaviour
{
    public GameObject hiddenButtons;
    public bool isRise;

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

    public void Start()
    {
        if (hiddenButtons.activeSelf)
        {
            hiddenButtons.SetActive(false);
        }
        isRise = false;

        b1.transform.position = hPos;
        b2.transform.position = hPos;
        b3.transform.position = hPos;
    }

    public void WeaponButtonFunc()
    {
        if (!isRise)
        {
            ActivateButtons();
        }
        else
        {
            DeActivateButtons();
        }
    }

    void ActivateButtons()
    {
        
        StartUp();
    }

    void DeActivateButtons()
    {
        StartDown();
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
        hiddenButtons.SetActive(true);
        isRise = true;

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
        isRise = false;

        float elapsedTime = 0.0f;

        while (elapsedTime < riseTime)
        {
            elapsedTime += Time.deltaTime;
            b1.transform.position = Vector3.Lerp(b1pos, hPos, elapsedTime / riseTime);
            b2.transform.position = Vector3.Lerp(b2pos, hPos, elapsedTime / riseTime);
            b3.transform.position = Vector3.Lerp(b3pos, hPos, elapsedTime / riseTime);

            yield return null;
        }

        hiddenButtons.SetActive(false);
    }
}
