using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinButton : MonoBehaviour
{
    private SkinsMenu skinsMenu;
    public Button skinButton;

    public Image skinImage;
    public TextMeshProUGUI skinName;

    private int skinNumber = 0;

    public void SetupButton(Skin skin, int number, SkinsMenu menu)
    {
        skinImage.sprite = skin.skinIcon;
        skinName.text = skin.skinName;
        skinNumber = number;
        skinButton.interactable = !skin.locked;
        skinsMenu = menu;
    }

    public void ChangeSkin()
    {
        skinsMenu.ChangeSkin(skinNumber);
    }
}
