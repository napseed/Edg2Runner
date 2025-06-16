using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public List<GameObject> offers = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        confirm.SetActive(false);
        AEImage.sprite = giselle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadBasicOfferPrefabs()
    {
        // TODO: Addressables를 사용해서 로드하고 싶다
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

    public void ConfirmOffer()
    {
        activatedOffer.OfferUpgrade();
    }
}
