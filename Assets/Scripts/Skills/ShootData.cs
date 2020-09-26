using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Shoot Data")]
public class ShootData : ScriptableObject
{
    [Range(0, 5)] public int shootForceLevel = 0;
    [Min(20f)] public float shootForce = 20f;
    private float defaultShootForce = 20f;

    [Space]
    [Range(0, 5)] public int shootTimeoutLevel = 0;
    [Min(1.6f)] public float shootTimeout = 1.6f;
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

#if UNITY_EDITOR
    public void RestoreToDefaults()
    {
        shootForceLevel = 0;
        shootForce = defaultShootForce;

        shootTimeoutLevel = 0;
        shootTimeout = defaultTimeout;
    }
#endif
}
