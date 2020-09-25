using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject background;

    [Header("For english version")]
    public GameObject[] tutorialScreensEN;

    [Header("For russian version")]
    public GameObject[] tutorialScreensRU;

    private bool screenEnabled = false;
    private GameObject curScreen;

    private int touchCount = 0;

    private void Update()
    {
        if (Input.touchCount > 0 && screenEnabled)
        {
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Ended)
            {
                touchCount++;
            }

            if(touchCount == 2)
            {
                touchCount = 0;
                SetActiveCurrentScreenObjects(false);
                Time.timeScale = 1;
            }
        }
    }

    public void ShowScreen(int screenNumber)
    {
        if(screenNumber < tutorialScreensEN.Length)
        {
            if(curScreen != tutorialScreensEN[screenNumber])
            {
                Time.timeScale = 0;
                curScreen = tutorialScreensEN[screenNumber];
                SetActiveCurrentScreenObjects(true);
            }
        }
    }

    private void SetActiveCurrentScreenObjects(bool isActive)
    {
        background.SetActive(isActive);
        curScreen.SetActive(isActive);
        screenEnabled = isActive;
    }

}
