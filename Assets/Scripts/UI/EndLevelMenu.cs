using System.Collections;
using TMPro;
using UnityEngine;

public class EndLevelMenu : MonoBehaviour
{
    public TextMeshProUGUI completeText;
    public TextMeshProUGUI lvlRatingText;
    public TextMeshProUGUI coinsText;

    private int currentLvlRating = 0;
    private int lvlCoins = 0;
    private int currentCoins = 0;

    private void OnEnable()
    {
        Time.timeScale = 0;
        StartCoroutine(DrawRating());
        StartCoroutine(DrawCoins());
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

    public void SetCoins(int coins)
    {
        lvlCoins = coins;
    }

    IEnumerator DrawRating()
    {
        for (int i = 0; i < currentLvlRating; i++)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            lvlRatingText.text += "* ";
        }
    }

    IEnumerator DrawCoins()
    {
        while(currentCoins <= lvlCoins)
        {
            yield return new WaitForEndOfFrame();
            coinsText.text = "+" + currentCoins.ToString();
            currentCoins++;
        }

    }
}
