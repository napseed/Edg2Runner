using UnityEngine;

public class ZetaOffer : Offer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = Player.Instance;
        co = company.ZETA;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.zeta;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
