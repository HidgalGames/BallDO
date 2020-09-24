using UnityEngine;

public class DontDestroyBackgroundMusic : MonoBehaviour
{
    private static DontDestroyBackgroundMusic instance;

    private void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
