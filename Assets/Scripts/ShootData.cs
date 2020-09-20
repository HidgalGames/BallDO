using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Shoot Data")]
public class ShootData : ScriptableObject
{
    [Range(0, 5)] public int shootForceLevel = 0;
    public float shootForce = 0f;
    private float defaultShootForce = 20f;

    [Space]
    [Range(0, 5)] public int shootTimeoutLevel = 0;
    public float shootTimeout = 0f;
    private float defaultTimeout = 1.6f;

    private void Start()
    {
        UpdateShootLevels();
    }

    public void UpdateShootLevels()
    {

        shootForce = defaultShootForce + 5f * shootForceLevel;

        shootTimeout = defaultTimeout - 0.2f * shootTimeoutLevel;
    }
}
