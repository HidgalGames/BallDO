using UnityEngine;
using TMPro;

public class ManGUIFunctions : MonoBehaviour
{
    public GameObject MainMenuObject;
    public GameObject LevelsListMenuObject;
    public GameObject SkillsMenuObject;
    public GameObject SettingsMenuObject;
    public GameObject SkinsMenuObject;

    private GameObject currentMenu;

    [Space]
    public GameObject coinsObject;
    private TextMeshProUGUI coinsText;
    public Coins playerCoins;

    private void Start()
    {
        SetupCoinsObjects();

        GoToMain();
    }

    private void SetupCoinsObjects()
    {
        playerCoins.SetupGUI(this);
        coinsText = coinsObject.GetComponentInChildren<TextMeshProUGUI>();
        coinsText.text = playerCoins.TotalCoins.ToString();
    }

    public void UpdateCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void GoToMain()
    {
        coinsObject.SetActive(true);
        GoToMenu(MainMenuObject);
    }

    public void GoToLevelsList()
    {
        GoToMenu(LevelsListMenuObject);
    }

    public void GoToSkillsMenu()
    {
        coinsObject.SetActive(false);
        GoToMenu(SkillsMenuObject);
    }

    public void GoToSkinsMenu()
    {
        GoToMenu(SkinsMenuObject);
    }

    public void GoToSettingsMenu()
    {
        coinsObject.SetActive(false);
        GoToMenu(SettingsMenuObject);
    }

    private void GoToMenu(GameObject menu)
    {
        if(currentMenu != null)
        {
            currentMenu.SetActive(false);
        }

        currentMenu = menu;
        currentMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
