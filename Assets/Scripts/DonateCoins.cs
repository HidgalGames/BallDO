using UnityEngine;

[CreateAssetMenu(menuName = "Donation Coins")]
public class DonateCoins : ScriptableObject
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
        if (TotalCoins >= takeCoins)
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
