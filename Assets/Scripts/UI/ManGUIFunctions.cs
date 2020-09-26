using UnityEngine;
using TMPro;

public class ManGUIFunctions : MonoBehaviour
{
    public GlobalVariables variables;

    public GameObject MainMenuObject;
    public GameObject LevelsListMenuObject;
    public GameObject SkillsMenuObject;
    public GameObject SettingsMenuObject;
    public GameObject SkinsMenuObject;

    [Space]
    public GameObject tutorialScreenObject;

    private GameObject currentMenu;

    [Space]
    public GameObject coinsObject;
    private TextMeshProUGUI coinsText;
    public Coins playerCoins;

    [Space]
    public GameObject donateCoinsObject;
    private TextMeshProUGUI donateCoinsText;
    public DonateCoins donateCoins;

    private void Start()
    {
        SetupCoinsObjects();

        GoToMain();

        if (variables.firstStart)
        {
            tutorialScreenObject.SetActive(true);
            variables.firstStart = false;
        }
    }

    private void SetupCoinsObjects()
    {
        playerCoins.SetupGUI(this);
        coinsText = coinsObject.GetComponentInChildren<TextMeshProUGUI>();
        coinsText.text = playerCoins.TotalCoins.ToString();

        donateCoins.SetupGUI(this);
        donateCoinsText = donateCoinsObject.GetComponentInChildren<TextMeshProUGUI>();
        donateCoinsText.text = donateCoins.TotalCoins.ToString();
    }

    public void UpdateCoins(int coins)
    {
        coinsText.text = coins.ToString();
    }
    
    public void UpdateDonateCoins(int coins)
    {
        donateCoinsText.text = coins.ToString();
    }    

    public void GoToMain()
    {
        coinsObject.SetActive(true);
        donateCoinsObject.SetActive(true);
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
        donateCoinsObject.SetActive(false);
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
