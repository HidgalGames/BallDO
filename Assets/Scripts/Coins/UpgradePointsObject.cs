using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade Points")]
public class UpgradePointsObject : ScriptableObject
{
    [Min(0)] public int Value = 0;

    private SkillsMenuLogic guiCoins;

    public void SetupGUI(SkillsMenuLogic gui)
    {
        guiCoins = gui;
    }

    public void Add(int points)
    {
        Value += points;
        UpdateCoinsText();
    }

    public void Take(int points)
    {
        Value -= points;
        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        if (guiCoins)
        {
            guiCoins.CheckForUpgradePoints();
        }
    }
}
