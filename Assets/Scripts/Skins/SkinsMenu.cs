using UnityEngine;
using System.Collections.Generic;

public class SkinsMenu : MonoBehaviour
{
    public GameObject SkinButtonPrefab;

    private SkinSystem skinSystem;

    [Space]
    public Coins playerCoins;

    [Space]
    public Transform listParentTransform;

    [Space]
    public List<SkinButton> buttons = new List<SkinButton>();

    private void Start()
    {
        skinSystem = FindObjectOfType<SkinSystem>();
        FillSkinsMenu();
    }

    private void FillSkinsMenu()
    {
        Skin[] skins = skinSystem.skinsList.playerSkins;

        RectTransform parentRect = listParentTransform.GetComponent<RectTransform>();
        parentRect.sizeDelta = new Vector2(290 * skins.Length, parentRect.sizeDelta.y);

        for(int i = 0; i < skins.Length; i++)
        {
            SkinButton button = Instantiate(SkinButtonPrefab, listParentTransform).GetComponent<SkinButton>();
            button.SetupButton(skins[i], i, this);
            buttons.Add(button);
        }
    }

    public bool BuySkin(int skinNumber)
    {
        Skin curSkin;
        if (skinNumber < skinSystem.skinsList.playerSkins.Length)
        {
            curSkin = skinSystem.skinsList.playerSkins[skinNumber];
            if (playerCoins.TakeCoins(curSkin.cost))
            {
                curSkin.locked = false;
                return true;
            }
        }

        return false;
    }

    public void ChangeSkin(int skinNumber)
    {
        buttons[skinSystem.GetCurrentSkinNumber()].SetChoosedCondition(false);

        if(skinSystem != null)
        {
            skinSystem.ChangeSkin(skinNumber);
        }
    }

    public int getCurSkinNumber()
    {
        return skinSystem.GetCurrentSkinNumber();
    }

}
