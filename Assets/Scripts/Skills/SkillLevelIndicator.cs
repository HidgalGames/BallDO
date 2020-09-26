using UnityEngine;

public class SkillLevelIndicator : MonoBehaviour
{
    public GameObject[] indicators;
    private int curlevel = 0;

    private void Start()
    {
        foreach (GameObject indicator in indicators)
        {
            indicator.SetActive(false);
        }
    }

    public void SetIndicatorLevel(int level)
    {
        for(int i = 0; i < level; i++)
        {
            indicators[i].SetActive(true);
        }
    }

    public void AddIndicator()
    {        
        if (curlevel < indicators.Length - 1)
        {            
            curlevel++;
        }

        indicators[curlevel - 1].SetActive(true);
    }

    public void RemoveIndicator()
    {
        if(curlevel > 0)
        {
            indicators[curlevel - 1].SetActive(false);
            curlevel = -1;
        }
        else
        {
            indicators[curlevel].SetActive(false);
        }
    }
}
