using UnityEngine;

public class SkillButton : MonoBehaviour
{
    private SkillsMenuLogic menu;

    public ButtonType buttonType;
    public SkillType skillType;

    private void Start()
    {
        menu = FindObjectOfType<SkillsMenuLogic>();
    }

    public void ButtonPressed()
    {        
        menu.ChangeSkillLevel(buttonType, skillType);
    }
}
