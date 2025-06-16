using UnityEngine;

public class AmadaOffer : Offer
{
    private void OnEnable()
    {
        player = Player.Instance;
        co = company.amada;
        oPanel = OfferPanel.Instance;
        sprite = oPanel.amada;
    }

    public override void OfferUpgrade()
    {
        // DO UPGRADE
        EndOffer();
    }
}
