using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFunctions : MonoBehaviour
{
    public GameObject MainUIObject;
    public GameObject PauseMenu;
    public GameObject EndLevelMenu;

    public Button nextLvlButton;

    private GameObject currentMenu;

    private void Start()
    {
        currentMenu = MainUIObject;
    }

    public void BackToGame()
    {
        GoToMenu(MainUIObject);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void GoToPause()
    {
        GoToMenu(PauseMenu);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToEndLevelMenu(bool canGoNext)
    {
        nextLvlButton.interactable = canGoNext;
        GoToMenu(EndLevelMenu);
    }

    private void GoToMenu(GameObject menu)
    {
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }

        currentMenu = menu;
        currentMenu.SetActive(true);
    }

}
