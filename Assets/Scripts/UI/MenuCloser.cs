using UnityEngine;

public class MenuCloser : MonoBehaviour
{
    public GameObject menuObject;

    public void CloseMenu()
    {
        menuObject.SetActive(false);
    }
}
