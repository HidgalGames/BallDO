using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using BasicTools.ButtonInspector;
#endif

[CreateAssetMenu(menuName = "Skins/Skins List")]
public class SkinsList : ScriptableObject
{
#if UNITY_EDITOR
    [Space]
    [Button("New Skin", "NewSkin")]
    public bool restoreButton = false;
#endif

    public List<Skin> playerSkins;
    [Min(0)] public int currentSkin = 0;

    public bool ChangeSkin(int skinNumber)
    {
        if(skinNumber < playerSkins.Count)
        {
            currentSkin = skinNumber;
            return true;
        }
        else
        {
            currentSkin = 0;
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

    public void NewSkin()
    {
        Skin newSkin = Editor.CreateInstance<Skin>();

        NewSkinWindow.ShowWindow(newSkin, ref playerSkins); 
    }
#endif
}
