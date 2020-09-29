using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillsMenuLogic : MonoBehaviour
{
    [Header("Skills Datas")]
    public ExplosionData explosionData;
    public ShootData shootData;

    private int[] skillsLevels = new int[5];
    private int[] skillsDeltas = new int[5];

    [Header("Menu Objects")]
    public SkillLevelIndicator[] indicators;

    [Space]
    public Button[] UpgradeButtons;
    public Button[] MinusButtons;

    [Space]
    public TextMeshProUGUI pointsText;
    public UpgradePointsObject UpgradePoints;
    private int UCDelta = 0;

    private void Start()
    {
        UpgradePoints.SetupGUI(this);
    }

    private void OnEnable()
    {
        FillLevels();
        ActivateLevelIndicators();
        CheckForUpgradePoints();
    }

    private void OnDisable()
    {
        UpgradePoints.Add(UCDelta);
        UCDelta = 0;
    }

    private void ActivateLevelIndicators()
    {
        for(int i = 0; i < indicators.Length; i++)
        {
            indicators[i].SetIndicatorLevel(skillsLevels[i]);
        }
    }

    private void FillLevels()
    {
        for (int i = 0; i < 5; i++)
        {
            skillsDeltas[i] = 0;
            skillsLevels[i] = 0;
            UpdateLevelInformation((SkillType) i);
        }
    }

    private void UpdateLevelInformation(SkillType skillType)
    {
        if((int) skillType < 3)
        {
            skillsLevels[(int) skillType] = explosionData.GetLevel(skillType);
        }
        else
        {
            skillsLevels[(int) skillType] = shootData.GetLevel(skillType);
        }
    }

    public void CheckForUpgradePoints()
    {
        SetAllButtons(ButtonType.Both, false);
        UpdateUpgradePointsText();
        if (UpgradePoints.Value > 0)
        {
            SetAllButtons(ButtonType.UpgradeButton, true);
        }
    }

    public void UpdateUpgradePointsText()
    {
        pointsText.text = UpgradePoints.Value.ToString();
    }

    private void SetAllButtons(ButtonType type, bool isActive)
    {
        switch (type)
        {
            case ButtonType.UpgradeButton:
                for (int i = 0; i < UpgradeButtons.Length; i++)
                {
                    UpgradeButtons[i].interactable = isActive && IsButtonShouldBeActive(ButtonType.UpgradeButton, (SkillType) i);
                }
                return;

            case ButtonType.MinusButton:
                for (int i = 0; i < MinusButtons.Length; i++)
                {
                    MinusButtons[i].interactable = isActive && IsButtonShouldBeActive(ButtonType.MinusButton, (SkillType) i);
                }
                return;

            case ButtonType.Both:
                for (int i = 0; i < MinusButtons.Length; i++)
                {
                    UpgradeButtons[i].interactable = isActive && IsButtonShouldBeActive(ButtonType.UpgradeButton, (SkillType) i);
                    MinusButtons[i].interactable = isActive && IsButtonShouldBeActive(ButtonType.MinusButton, (SkillType) i);
                }
                return;
        }
    }

    private bool IsButtonShouldBeActive(ButtonType buttonType, SkillType skillType)
    {
        switch (buttonType)
        {
            case ButtonType.UpgradeButton:
                return ((skillsLevels[(int) skillType] + skillsDeltas[(int) skillType] < 5) && UpgradePoints.Value > 0);

            case ButtonType.MinusButton:
                return skillsDeltas[(int) skillType] > 0;
        }

        return false;
    }

    public void ChangeSkillLevel(ButtonType buttonType, SkillType skill)
    {
        switch (buttonType)
        {
            case ButtonType.UpgradeButton:
                if(skillsDeltas[(int) skill] < 5)
                {                    
                    skillsDeltas[(int) skill]++;
                    indicators[(int) skill].AddIndicator();
                    UpgradePoints.Take(1);
                    UCDelta++;
                }
                break;

            case ButtonType.MinusButton:
                if(skillsDeltas[(int) skill] > 0)
                {
                    skillsDeltas[(int) skill]--;
                    indicators[(int) skill].RemoveIndicator();
                    UpgradePoints.Add(1);
                    UCDelta--;
                }
                break;
        }

        UpdateUpgradePointsText();
        SetAllButtons(ButtonType.UpgradeButton, true);
        MinusButtons[(int) skill].interactable = IsButtonShouldBeActive(ButtonType.MinusButton, skill);
    }

    private void SetSkillLevel(SkillType skill, int level)
    {
        if((int) skill < 3)
        {
            explosionData.SetLevel(skill, level);
        }
        else
        {
            shootData.SetLevel(skill, level);
        }
    }

    public void AcceptChanges()
    {
        for(int i = 0; i < skillsDeltas.Length; i++)
        {
            if(skillsDeltas[i] > 0)
            {
                skillsLevels[i] += skillsDeltas[i];
                skillsDeltas[i] = 0;
                SetSkillLevel((SkillType) i, skillsLevels[i]);
            }

            MinusButtons[i].interactable = IsButtonShouldBeActive(ButtonType.MinusButton, (SkillType) i);
        }

        UCDelta = 0;
    }
}
