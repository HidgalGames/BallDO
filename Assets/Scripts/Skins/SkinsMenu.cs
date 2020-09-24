using UnityEngine;
using System.Collections.Generic;

public class SkinsMenu : MonoBehaviour
{
    public GameObject SkinButtonPrefab;

    private SkinSystem skinSystem;

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
            RectTransform buttonTrans = button.GetComponent<RectTransform>();
            buttonTrans.anchoredPosition = new Vector2(160f + 290f * i, -20f);
            button.SetupButton(skins[i], i, this);
        }
    }

    public void ChangeSkin(int skinNumber)
    {
        if(skinSystem != null)
        {
            skinSystem.ChangeSkin(skinNumber);
        }
    }

}
