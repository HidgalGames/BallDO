using UnityEngine;

public class SkillLevelIndicator : MonoBehaviour
{
    public GameObject[] indicators;
    private int curlevel = 0;

    public void SetIndicatorLevel(int level)
    {        
        curlevel = level;

        for (int i = 0; i < 5; i++)
        {
            if(i < level)
            {
                indicators[i].SetActive(true);
            }
            else
            {
                indicators[i].SetActive(false);
            }

        }
    }

    public void AddIndicator()
    {        
        curlevel++;
        indicators[curlevel - 1].SetActive(true);
    }

    public void RemoveIndicator()
    {
        curlevel--;
        indicators[curlevel].SetActive(false);
    }
}
