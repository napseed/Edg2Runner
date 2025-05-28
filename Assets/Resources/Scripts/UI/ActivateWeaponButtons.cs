using System.Collections;
using UnityEngine;

public class ActivateWeaponButtons : MonoBehaviour
{
    public GameObject hiddenButtons;
    public bool isRise;

    public RectTransform b1;
    public RectTransform b2;
    public RectTransform b3;

    public Vector3 b1pos;
    public Vector3 b2pos;
    public Vector3 b3pos;
    public Vector3 hPos;

    private Coroutine curCor;
    public float riseTime = 0.0f;

    public bool b1able = false;
    public bool b2able = false;

    public void Start()
    {
        if (hiddenButtons.activeSelf)
        {
            hiddenButtons.SetActive(false);
        }
        isRise = false;

        b1pos = b1.localPosition;
        b2pos = b2.localPosition;
        b3pos = b3.localPosition;
        b1.localPosition = Vector3.zero;
        b2.localPosition = Vector3.zero;
        b3.localPosition = Vector3.zero;
    }

    private void OnEnable()
    {
        hPos = Vector3.zero;
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
            b1.localPosition = Vector3.Lerp(hPos, b1pos, elapsedTime / riseTime);
            b2.localPosition = Vector3.Lerp(hPos, b2pos, elapsedTime / riseTime);
            b3.localPosition = Vector3.Lerp(hPos, b3pos, elapsedTime / riseTime);

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
            b1.localPosition = Vector3.Lerp(b1pos, hPos, elapsedTime / riseTime);
            b2.localPosition = Vector3.Lerp(b2pos, hPos, elapsedTime / riseTime);
            b3.localPosition = Vector3.Lerp(b3pos, hPos, elapsedTime / riseTime);

            yield return null;
        }

        hiddenButtons.SetActive(false);
    }
}
