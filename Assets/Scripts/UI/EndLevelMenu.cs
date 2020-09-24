using TMPro;
using UnityEngine;

public class EndLevelMenu : MonoBehaviour
{
    public TextMeshProUGUI completeText;
    public TextMeshProUGUI lvlRatingText;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void DrawRating(int rating)
    {
        lvlRatingText.text = string.Empty;

        for (int i = 0; i < rating; i++)
        {
            lvlRatingText.text += "* ";
        }
    }
}
