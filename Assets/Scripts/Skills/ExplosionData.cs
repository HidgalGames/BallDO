using UnityEngine;

[CreateAssetMenu(menuName ="Skills/Explosion Data")]
public class ExplosionData : ScriptableObject
{
    [Space]
    [Range(0, 5)] public int explosionForceLevel = 0;
    [Min(50f)] public float explosionForce = 50f;
    private float defaultExplosionForce = 50f;

    [Range(0, 5)] public int explosionRadiusLevel = 0;
    [Min(2f)] public float explosionRadius = 2f;
    private float defaultRadius = 2f;

    [Space]
    [Range(0, 5)] public int explosionTimeoutLevel = 0;
    [Min(3f)] public float explosionTimeout = 3f;
    private float defaultTimeout = 3f;


    public void UpdateExplosionLevels()
    {
        explosionRadius = defaultRadius + 0.4f * explosionRadiusLevel;

        explosionForce = defaultExplosionForce + 10f * explosionForceLevel;

        explosionTimeout = defaultTimeout - 0.5f * explosionTimeoutLevel;
    }

    public int GetLevel(SkillType type)
    {
        switch (type)
        {
            case SkillType.explosionForce:
                return explosionForceLevel;

            case SkillType.explosionRadius:
                return explosionRadiusLevel;

            case SkillType.explosionTimeout:
                return explosionTimeoutLevel;
        }

        return -1;
    }

    public void SetLevel(SkillType type, int level)
    {
        switch (type)
        {
            case SkillType.explosionForce:
                explosionForceLevel = level;
                break;

            case SkillType.explosionRadius:
                explosionRadiusLevel = level;
                break;

            case SkillType.explosionTimeout:
                explosionTimeoutLevel = level;
                break;
        }

        UpdateExplosionLevels();
    }

#if UNITY_EDITOR
    public void RestoreToDefaults()
    {
        explosionRadiusLevel = 0;
        explosionRadius = defaultRadius;

        explosionForceLevel = 0;
        explosionForce = defaultExplosionForce;

        explosionTimeoutLevel = 0;
        explosionTimeout = defaultTimeout;
    }
#endif
}
