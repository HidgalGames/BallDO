using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillsMenu : MonoBehaviour
{
    [Header("Skills Datas")]
    public ExplosionData explosionData;
    public ShootData shootData;

    [Header("Menu Objects")]
    public int explosionForceDelta = 0;
    public List<GameObject> ExplosionForceLevelPicks;

    public int explosionRadiusDelta = 0;
    public List<GameObject> ExplosionRadiusLevelPicks;

    public int explosionTimeoutDelta = 0;
    public List<GameObject> ExplosionTimeoutLevelPicks;

    [Space]
    public int shootForceDelta = 0;
    public List<GameObject> ShootForceLevelPicks;

    public int shootTimeoutDelta = 0;
    public List<GameObject> ShootTimeoutLevelPicks;

    [Space]
    public List<Button> UpgradeButtons;

    [Space]
    public TextMeshProUGUI pointsText;
    public UpgradePointsObject UpgradePoints;

    private void OnEnable()
    {
        ActivateLevelPicks();
        CheckForUpgradePoints();
    }

    private void OnDisable()
    {
        DeactivateLelvelPicks();
        SetUpgradeButtons(false);

        UpgradePoints.Add(explosionForceDelta + explosionRadiusDelta + explosionTimeoutDelta + shootForceDelta + shootTimeoutDelta);

        explosionForceDelta = 0;
        explosionRadiusDelta = 0;
        explosionTimeoutDelta = 0;
        shootForceDelta = 0;
        shootTimeoutDelta = 0;
    }

    public void AddUpgradePoints(int points)
    {
        if(points == 0)
        {
            return;
        }
        
        UpgradePoints.Add(points);

        if (UpgradePoints.Value > 0 && !UpgradeButtons[0].interactable)
        {
            SetUpgradeButtons(true);
        }

        UpdatePointsText();
    }

    public void LevelUpExplosionForce()
    {
        if(explosionData.explosionForceLevel < 5)
        {
            TakeUpgradePoint();
            explosionForceDelta++;
            ExplosionForceLevelPicks[explosionData.explosionForceLevel + explosionForceDelta - 1].SetActive(true);
            CheckUpgradeButtonsByStringNumber(0);
        }
    }

    public void LevelDownExplosionForce()
    {
        if(explosionForceDelta <= 0)
        {
            return;
        }

        ExplosionForceLevelPicks[explosionData.explosionForceLevel + explosionForceDelta - 1].SetActive(false);
        explosionForceDelta--;
        AddUpgradePoints(1);
        CheckUpgradeButtonsByStringNumber(0);
    }

    public void LevelUpExplosionRadius()
    {
        if (explosionData.explosionRadiusLevel < 5)
        {
            TakeUpgradePoint();
            explosionRadiusDelta++;
            ExplosionRadiusLevelPicks[explosionData.explosionRadiusLevel + explosionRadiusDelta - 1].SetActive(true);
            CheckUpgradeButtonsByStringNumber(1);
        }
    }

    public void LevelDownExplosionRadius()
    {
        if (explosionRadiusDelta <= 0)
        {
            return;
        }

        ExplosionRadiusLevelPicks[explosionData.explosionRadiusLevel + explosionRadiusDelta - 1].SetActive(false);
        explosionRadiusDelta--;
        AddUpgradePoints(1);
        CheckUpgradeButtonsByStringNumber(1);
    }

    public void LevelUpExplosionTimeout()
    {
        if (explosionData.explosionTimeoutLevel < 5)
        {
            TakeUpgradePoint();
            explosionTimeoutDelta++;
            ExplosionTimeoutLevelPicks[explosionData.explosionTimeoutLevel + explosionTimeoutDelta - 1].SetActive(true);
            CheckUpgradeButtonsByStringNumber(2);
        }
    }

    public void LevelDownExplosionTimeout()
    {
        if (explosionTimeoutDelta <= 0)
        {
            return;
        }

        ExplosionTimeoutLevelPicks[explosionData.explosionTimeoutLevel + explosionTimeoutDelta - 1].SetActive(false);
        explosionTimeoutDelta--;
        AddUpgradePoints(1);
        CheckUpgradeButtonsByStringNumber(2);
    }

    public void LevelUpShootForce()
    {
        if (shootData.shootForceLevel < 5)
        {
            TakeUpgradePoint();
            shootForceDelta++;
            ShootForceLevelPicks[shootData.shootForceLevel + shootForceDelta - 1].SetActive(true);
            CheckUpgradeButtonsByStringNumber(3);
        }
    }

    public void LevelDownShootForce()
    {
        if (shootForceDelta <= 0)
        {
            return;
        }

        ShootForceLevelPicks[shootData.shootForceLevel + shootForceDelta - 1].SetActive(false);
        shootForceDelta--;
        AddUpgradePoints(1);
        CheckUpgradeButtonsByStringNumber(3);
    }

    public void LevelUpShootTimeout()
    {
        if (shootData.shootTimeoutLevel < 5)
        {
            TakeUpgradePoint();
            shootTimeoutDelta++;
            ShootTimeoutLevelPicks[shootData.shootTimeoutLevel + shootTimeoutDelta - 1].SetActive(true);
            CheckUpgradeButtonsByStringNumber(4);
        }
    }

    public void LevelDownShootTimeout()
    {
        if (shootTimeoutDelta <= 0)
        {
            return;
        }

        ShootTimeoutLevelPicks[shootData.shootTimeoutLevel + shootTimeoutDelta - 1].SetActive(false);
        shootTimeoutDelta--;
        AddUpgradePoints(1);
        CheckUpgradeButtonsByStringNumber(4);
    }

    public void ApplyChanges()
    {
        explosionData.explosionForceLevel += explosionForceDelta;
        explosionData.explosionRadiusLevel += explosionRadiusDelta;
        explosionData.explosionTimeoutLevel += explosionTimeoutDelta;

        shootData.shootForceLevel += shootForceDelta;
        shootData.shootTimeoutLevel += shootTimeoutDelta;

        explosionData.UpdateExplosionLevels();
        shootData.UpdateShootLevels();

        explosionForceDelta = 0;
        explosionRadiusDelta = 0;
        explosionTimeoutDelta = 0;
        shootForceDelta = 0;
        shootTimeoutDelta = 0;

        if(UpgradePoints.Value > 0)
        {
            CheckAllAppliedButtons();
        }
        else
        {
            SetUpgradeButtons(false);
        }

    }

    private void TakeUpgradePoint()
    {
        UpgradePoints.Take(1);

        UpdatePointsText();

        if (UpgradePoints.Value == 0)
        {
            SetUpgradeButtons(false);
        }
    }

    private void ActivateLevelPicks()
    {
        for(int i = 0; i < 5; i++)
        {
            if(i < explosionData.explosionForceLevel)
            {
                ExplosionForceLevelPicks[i].SetActive(true);
            }

            if (i < explosionData.explosionRadiusLevel)
            {
                ExplosionRadiusLevelPicks[i].SetActive(true);
            }

            if (i < explosionData.explosionTimeoutLevel)
            {
                ExplosionTimeoutLevelPicks[i].SetActive(true);
            }

            
            if(i < shootData.shootForceLevel)
            {
                ShootForceLevelPicks[i].SetActive(true);
            }

            if (i < shootData.shootTimeoutLevel)
            {
                ShootTimeoutLevelPicks[i].SetActive(true);
            }
        }
    }

    private void CheckUpgradeButtonsByStringNumber(int stringNumber)
    {
        switch (stringNumber)
        {
            case 0:
                UpgradeButtons[stringNumber].interactable = (explosionData.explosionForceLevel + explosionForceDelta < 5 && UpgradePoints.Value > 0);
                UpgradeButtons[stringNumber + 1].interactable = true;
                break;

            case 1:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = (explosionData.explosionRadiusLevel + explosionRadiusDelta < 5 && UpgradePoints.Value > 0);
                UpgradeButtons[stringNumber + 1].interactable = true;
                break;

            case 2:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = (explosionData.explosionTimeoutLevel + explosionTimeoutDelta < 5 && UpgradePoints.Value > 0);
                UpgradeButtons[stringNumber + 1].interactable = true;
                break;

            case 3:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = (shootData.shootForceLevel + shootForceDelta < 5 && UpgradePoints.Value > 0);
                UpgradeButtons[stringNumber + 1].interactable = true;
                break;

            case 4:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = (shootData.shootTimeoutLevel + shootTimeoutDelta < 5 && UpgradePoints.Value > 0);
                UpgradeButtons[stringNumber + 1].interactable = true;
                break;
        }
    }

    private void CheckAppliedUpgradeButtons(int stringNumber)
    {
        switch (stringNumber)
        {
            case 0:
                UpgradeButtons[stringNumber].interactable = UpgradeButtons[stringNumber + 1].interactable = (explosionData.explosionForceLevel + explosionForceDelta < 5);
                break;

            case 1:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = UpgradeButtons[stringNumber + 1].interactable = (explosionData.explosionRadiusLevel + explosionRadiusDelta < 5);
                break;

            case 2:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = UpgradeButtons[stringNumber + 1].interactable = (explosionData.explosionTimeoutLevel + explosionTimeoutDelta < 5);
                break;

            case 3:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = UpgradeButtons[stringNumber + 1].interactable = (shootData.shootForceLevel + shootForceDelta < 5);
                break;

            case 4:
                stringNumber *= 2;
                UpgradeButtons[stringNumber].interactable = UpgradeButtons[stringNumber + 1].interactable = (shootData.shootTimeoutLevel + shootTimeoutDelta < 5);
                break;
        }
    }

    private void DeactivateLelvelPicks()
    {
        for(int i = 0; i < 5; i++)
        {
            ExplosionForceLevelPicks[i].SetActive(false);
            ExplosionRadiusLevelPicks[i].SetActive(false);
            ExplosionTimeoutLevelPicks[i].SetActive(false);

            ShootForceLevelPicks[i].SetActive(false);
            ShootTimeoutLevelPicks[i].SetActive(false);
        }
    }

    private void CheckForUpgradePoints()
    {
        SetUpgradeButtons(false);
        UpdatePointsText();
        if(UpgradePoints.Value > 0)
        {
            SetUpgradeButtons(true);
            CheckAllAppliedButtons();
        }
    }

    private void CheckAllAppliedButtons()
    {
        for (int i = 0; i < 5; i++)
        {
            CheckAppliedUpgradeButtons(i);
        }
    }

    private void UpdatePointsText()
    {
        pointsText.text = UpgradePoints.Value.ToString();
    }

    private void SetUpgradeButtons(bool isActive)
    {
        for(int i = 0; i < UpgradeButtons.Count; i++)
        {
            UpgradeButtons[i].interactable = isActive;
        }

    }
}
