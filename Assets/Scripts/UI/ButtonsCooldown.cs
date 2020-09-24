using UnityEngine;
using UnityEngine.UI;

public class ButtonsCooldown : MonoBehaviour
{
    public Image ShootButtonCooldown;
    private bool startShootCooldown = false;

    public Image ExplodeButtonCooldown;
    private bool startExplodeCooldown = false;

    [Space]
    public ShootData shootData;
    public ExplosionData explosionData;

    private void Update()
    {
        float delta = Time.deltaTime;

        if (startShootCooldown)
        {
            ShootButtonCooldown.fillAmount -= 1 / shootData.shootTimeout * delta;

            if(ShootButtonCooldown.fillAmount <= 0f)
            {
                startShootCooldown = false;
            }
        }

        if (startExplodeCooldown)
        {
            ExplodeButtonCooldown.fillAmount -= 1 / explosionData.explosionTimeout * delta;

            if (ExplodeButtonCooldown.fillAmount <= 0f)
            {
                startExplodeCooldown = false;
            }
        }
    }

    public void StartShootCooldown()
    {
        if (!startShootCooldown)
        {
            startShootCooldown = true;
            ShootButtonCooldown.fillAmount = 1f;
        }
    }

    public void StartExplodeCooldown()
    {
        if (!startExplodeCooldown)
        {
            startExplodeCooldown = true;
            ExplodeButtonCooldown.fillAmount = 1f;
        }
    }
}
