using UnityEngine;

public class ManGUIFunctions : MonoBehaviour
{
    public GameObject MainMenuObject;
    public GameObject LevelsListMenuObject;
    public GameObject SkillsMenuObject;
    public GameObject SkinsMenuObject;

    private GameObject currentMenu;

    private void Start()
    {
        GoToMain();
    }

    public void GoToMain()
    {
        GoToMenu(MainMenuObject);
    }

    public void GoToLevelsList()
    {
        GoToMenu(LevelsListMenuObject);
    }

    public void GoToSkillsMenu()
    {
        GoToMenu(SkillsMenuObject);
    }

    public void GoToSninsMenu()
    {
        GoToMenu(SkinsMenuObject);
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
