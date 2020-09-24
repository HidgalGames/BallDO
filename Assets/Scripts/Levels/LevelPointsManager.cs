using UnityEngine;
using UnityEngine.UI;

public class LevelPointsManager : MonoBehaviour
{
    public int LevelPoints = 0;

    public Text pointsText;

    public void AddPoints(int points)
    {
        LevelPoints += points;
        pointsText.text = "Points: " + LevelPoints.ToString();
    }
}
