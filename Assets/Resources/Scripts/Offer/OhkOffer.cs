using UnityEngine;
using static Offer;
using UnityEngine.U2D;

public class OhkOffer : Offer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        player = Player.Instance;
        co = company.OHKco;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.ohk;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
