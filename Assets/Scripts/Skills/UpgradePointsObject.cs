using UnityEngine;

[CreateAssetMenu(menuName = "Upgrade Points")]
public class UpgradePointsObject : ScriptableObject
{
    [Min(0)] public int Value = 0;

    public void Add(int points)
    {
        Value += points;
    }

    public void Take(int points)
    {
        Value -= points;
    }
}
