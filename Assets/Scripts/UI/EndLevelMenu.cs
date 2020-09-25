using System.Collections;
using TMPro;
using UnityEngine;

public class EndLevelMenu : MonoBehaviour
{
    public TextMeshProUGUI completeText;
    public TextMeshProUGUI lvlRatingText;
    public TextMeshProUGUI coinsText;

    private int currentLvlRating = 0;

    private void OnEnable()
    {
        Time.timeScale = 0;
        StartCoroutine(DrawRating());
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

    public void SetRating(int rating)
    {
        lvlRatingText.text = string.Empty;
        currentLvlRating = rating;
    }

    private IEnumerator DrawRating()
    {
        for (int i = 0; i < currentLvlRating; i++)
        {
            lvlRatingText.text += "* ";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
