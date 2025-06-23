using UnityEngine;
using UnityEngine.U2D;

public class Offer : MonoBehaviour
{
    public enum company
    {
        SOFIA,
        OHKco,
        Weaponizer,
        Windmill,
        amada,
        TriChrome,
        ZETA,
        etc,
    }

    protected company co;

    public OfferPanel oPanel;
    public Sprite sprite;
    public Player player;

    private void OnEnable()
    {
        
    }

    public void OfferFuction()
    {
        oPanel.ChangeSprite(sprite);
        oPanel.activatedOffer = this;
        oPanel.ShowConfirm();
    }

    public virtual void OfferUpgrade()
    {
        return;
    }

    public void EndOffer()
    {
        
        player.HideOffer();
    }
}
