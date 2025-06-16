using UnityEngine;

public class WindmillOffer : Offer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = Player.Instance;
        co = company.Windmill;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.windmill;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
