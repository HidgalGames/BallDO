using UnityEngine;

public class UIAnimations : MonoBehaviour
{
    public UpgradePointsObject UC;

    [Space]
    public Animator skillsBtnAnimator;

    private void Awake()
    {
        UC.SetupAnimController(this);
        SetSkillsButtonAnimation(UC.Value > 0);
    }

    public void SetSkillsButtonAnimation(bool status)
    {
        skillsBtnAnimator.SetBool("HaveUC", status);
    }
}
