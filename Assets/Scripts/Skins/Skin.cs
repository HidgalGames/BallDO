using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Skins/Skin")]
public class Skin : ScriptableObject
{
    public string skinName = "Default";
    public GameObject skinObject;
    public Sprite skinIcon;
    public Sprite joyIcon;
    public bool locked = true;
}
