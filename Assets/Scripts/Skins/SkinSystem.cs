using UnityEngine;
using UnityEngine.UI;

public class SkinSystem : MonoBehaviour
{
    public SkinsList skinsList;
    [Min(0)] public int currentSkinNumber = 0;
    public Transform SkinParent;
    public Image joystick;

    private void Start()
    {
        ChangeSkin(currentSkinNumber);
    }

    public void ChangeSkin(int skinNumber)
    {
        if (skinNumber < skinsList.playerSkins.Length)
        {
            currentSkinNumber = skinNumber;

            Skin curSkin = skinsList.playerSkins[currentSkinNumber];

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

}
