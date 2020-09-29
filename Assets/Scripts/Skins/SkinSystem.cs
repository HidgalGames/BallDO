using UnityEngine;
using UnityEngine.UI;

public class SkinSystem : MonoBehaviour
{
    public SkinsList skinsList;
    public Transform SkinParent;
    public Image joystick;

    private void Start()
    {
        ChangeSkin(skinsList.currentSkin);
    }

    public void ChangeSkin(int skinNumber)
    {
        if (skinsList.ChangeSkin(skinNumber))
        {
            Skin curSkin = skinsList.playerSkins[skinsList.currentSkin];

            if (SkinParent.childCount > 0)
            {
                Destroy(SkinParent.GetChild(0).gameObject);
            }

            Instantiate(curSkin.skinObject, SkinParent);

            if(joystick != null)
            {
                joystick.sprite = curSkin.joyIcon;
            }
        }
    }

    public int GetCurrentSkinNumber()
    {
        return skinsList.currentSkin;
    }
}
