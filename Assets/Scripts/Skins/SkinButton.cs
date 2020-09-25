using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinButton : MonoBehaviour
{
    private SkinsMenu skinsMenu;
    public Button skinButton;
    public Button buyButton;

    public Image skinImage;
    public TextMeshProUGUI skinName;
    public TextMeshProUGUI skinCost;

    private int skinNumber = 0;

    public void SetupButton(Skin skin, int number, SkinsMenu menu)
    {
        skinImage.sprite = skin.skinIcon;
        skinName.text = skin.skinName;        
        skinButton.interactable = !skin.locked;

        if (skin.locked)
        {
            skinCost.text = skin.cost.ToString() + "$";
            buyButton.interactable = true;
        }
        else
        {
            buyButton.gameObject.SetActive(false);
            skinCost.text = string.Empty;
        }

        skinNumber = number;

        skinsMenu = menu;
    }

    public void BuySkin()
    {
        if (skinsMenu.BuySkin(skinNumber))
        {
            buyButton.gameObject.SetActive(false);
            skinButton.interactable = true;
            skinCost.text = string.Empty;
        }
    }

    public void ChangeSkin()
    {
        skinsMenu.ChangeSkin(skinNumber);
    }
}
