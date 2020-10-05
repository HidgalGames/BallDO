using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade Points")]
public class UpgradePointsObject : ScriptableObject
{
    [Min(0)] public int Value = 0;

    private SkillsMenuLogic guiCoins;
    private UIAnimations animations;

    public void SetupGUI(SkillsMenuLogic gui)
    {
        guiCoins = gui;
    }

    public void SetupAnimController(UIAnimations controller)
    {
        animations = controller;
    }

    public void Add(int points)
    {
        Value += points;
        UpdateCoinsText();
    }

    public void Take(int points)
    {
        Value -= points;

        if(Value < 0)
        {
            Value = 0;
        }

        UpdateCoinsText();
    }

    private void UpdateCoinsText()
    {
        if (guiCoins)
        {
            guiCoins.CheckForUpgradePoints(false);
        }

        if (animations)
        {
            animations.SetSkillsButtonAnimation(Value > 0);
        }
    }
}
