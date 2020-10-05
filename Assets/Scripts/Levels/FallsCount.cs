using UnityEngine;

[CreateAssetMenu(menuName = "Falls Count")]
public class FallsCount : ScriptableObject
{
    private int fallsCount = 0;

    public int Get()
    {
        return fallsCount;
    }

    public void Set(int count)
    {
        fallsCount = count;
    }

    public void Add()
    {
        fallsCount++;
    }

#if UNITY_EDITOR
    public void Restore()
    {
        fallsCount = 0;
    }
#endif
}
