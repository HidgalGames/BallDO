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

#if UNITY_EDITOR
    public void RestoreSkins()
    {
        currentSkin = 0;

        foreach(Skin sk in playerSkins)
        {
            sk.RestoreToDefaults();
        }
    }
#endif
}
