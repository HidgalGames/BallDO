using UnityEngine;

[CreateAssetMenu(menuName = "New Level")]
public class Level : ScriptableObject
{
    [Range(0, 5)]
    public int rating = 0;
    public string sceneIndex;
    public bool unlocked = false;

    public void SetRating(int rate)
    {
        rating = rate;
    }

    public void Unlock()
    {
        unlocked = true;
    }
}
