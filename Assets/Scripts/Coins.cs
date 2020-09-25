using UnityEngine;

[CreateAssetMenu(menuName ="Skins/Coins")]
public class Coins : ScriptableObject
{
    [Min(0)] public int TotalCoins = 0;

    private ManGUIFunctions guiCoins;

    public void SetupGUI(ManGUIFunctions gui)
    {
        guiCoins = gui;
    }

    public void AddCoins(int addCoins)
    {
        TotalCoins += addCoins;
        if (guiCoins)
        {
            guiCoins.UpdateCoins(TotalCoins);
        }
    }

    public bool TakeCoins(int takeCoins)
    {
        if(TotalCoins >= takeCoins)
        {
            TotalCoins -= takeCoins;

            if (guiCoins)
            {
                guiCoins.UpdateCoins(TotalCoins);
            }

            return true;
        }

        return false;
    }
}
