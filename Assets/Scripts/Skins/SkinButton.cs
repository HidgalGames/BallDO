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
            skinCost.text = skin.cost.ToString();
            buyButton.interactable = true;
        }
        else
        {
            ActivateButton();
        }

        skinNumber = number;

        skinsMenu = menu;
    }

    public void BuySkin()
    {
        if (skinsMenu.BuySkin(skinNumber))
        {
            ActivateButton();
        }
    }

    public void ChangeSkin()
    {
        skinsMenu.ChangeSkin(skinNumber);
    }

    private void ActivateButton()
    {
        buyButton.gameObject.SetActive(false);
        skinButton.interactable = true;
        skinCost.gameObject.SetActive(false);
    }
}
