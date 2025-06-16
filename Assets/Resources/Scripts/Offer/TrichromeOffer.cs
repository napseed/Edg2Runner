using UnityEngine;

public class TrichromeOffer : Offer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = Player.Instance;
        co = company.TriChrome;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.trichrome;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
