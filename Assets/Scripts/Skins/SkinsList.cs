using UnityEngine;

[CreateAssetMenu(menuName = "Skins/Skins List")]
public class SkinsList : ScriptableObject
{
    public Skin[] playerSkins;
    [Min(0)] public int currentSkin = 0;

    public bool ChangeSkin(int skinNumber)
    {
        if(skinNumber < playerSkins.Length)
        {
            currentSkin = skinNumber;
            return true;
        }

        return false;
    }
}
