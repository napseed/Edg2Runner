using UnityEngine;

public class SofiaOffer : Offer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = Player.Instance;
        co = company.SOFIA;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.sofia;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
