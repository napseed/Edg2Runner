using UnityEngine;

public class WeaponizerOffer : Offer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = Player.Instance;
        co = company.Weaponizer;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.weaponizer;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
