using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEditor.Rendering;

public class OfferPanel : MonoBehaviour
{
    public Sprite amada;
    public Sprite ohk;
    public Sprite sofia;
    public Sprite weaponizer;
    public Sprite windmill;
    public Sprite trichrome;
    public Sprite zeta;
    public Sprite giselle;

    public Image AEImage;
    public GameObject confirm;
    public Offer activatedOffer;

    private static OfferPanel instance;
    public static OfferPanel Instance => instance;

    public int maxOfferCount = 3;
    public GameObject[] oPositions;

    public GameObject loader;
    // 오퍼 창에 뜰 3개의 랜덤 픽된 오퍼들
    public List<GameObject> actOffers = new List<GameObject>();
    // 수락 후 적용된 오퍼 리스트... 필요한가?
    public List<GameObject> appliedOffers = new List<GameObject>();

    public GameObject interfacePanel;
    PlayerUpgrade pUpgrade;

    private void Awake()
    {
        instance = this;
        pUpgrade = GetComponent<PlayerUpgrade>();
        //loadedOffers = loader.GetComponent<PrefLoader>().loadedPrefOffers;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        confirm.SetActive(false);
        AEImage.sprite = giselle;
        ShowOffer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSprite(Sprite sp)
    {
        AEImage.sprite = sp;
    }

    public void ShowConfirm()
    {
        if (!confirm.activeSelf)
        {
            confirm.SetActive(true);

        }
    }

    // 오퍼를 수락했다면 적용 후 인스턴싱된 오브젝트 삭제
    public void ConfirmOffer()
    {
        activatedOffer.OfferUpgrade();
        interfacePanel.GetComponent<InterfacePanel>().RegisterUp(activatedOffer.icon);

        for (int i = 0; i < oPositions.Length; i++)
        {
            Transform child = oPositions[i].transform.GetChild(0);
            Destroy(child.gameObject);
        }
    }

    public static List<GameObject> PickUnique(List<GameObject> list)
    {
        // 또셔 예이츠
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }

        return list.GetRange(0, 3);
    }

    public void ShowOffer()
    {
        actOffers = PickUnique(loader.GetComponent<PrefLoader>().loadedPrefOffers);
        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(actOffers[i]);
            obj.transform.SetParent(oPositions[i].transform, false);
        }
    }
}
