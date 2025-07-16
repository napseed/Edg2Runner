using UnityEngine;
using UnityEngine.UI;

public class InterfacePanel : MonoBehaviour
{
    public Image[] icons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void RegisterUp(Sprite sp)
    {
        foreach (var icon in icons)
        {
            if (icon.sprite == null)
            {
                icon.sprite = sp;
                break;
            }
            else if (icon.sprite == sp)
            {
                break;
            }

        }
    }
}
