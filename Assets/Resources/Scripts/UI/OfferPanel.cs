using UnityEngine;
using UnityEngine.UI;

public class OfferPanel : MonoBehaviour
{
    public Sprite amada;
    public Sprite ohk;
    public Sprite sofia;
    public Sprite weaponizer;
    public Sprite windmill;
    public Sprite corp1;
    public Sprite corp2;
    public Sprite giselle;

    public Image AEImage;
    public GameObject confirm;

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

    public void ChangeSprite(Sprite sp)
    {
        AEImage.sprite = sp;
    }

    public void ShowConfirm()
    {
        confirm.SetActive(true);
    }
}
