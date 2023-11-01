using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayAxeUpgradeRequirement : MonoBehaviour
{
    [SerializeField] private Text _defaultFirstNormalAxeSkillRequireText;
    [SerializeField] private Text _defaultSecondNormalAxeSkillRequireText;

    [SerializeField] private Text _firstAxeSkill001UpgradeRequireText;

    [SerializeField] private Text _secondAxeSkill001UpgradeRequireText;
    [SerializeField] private Text _secondAxeSkill002UpgradeRequireText;
    [SerializeField] private Text _secondAxeSkill003UpgradeRequireText;

    [SerializeField] private Text _thirdAxeSkill001UpgradeRequireText;
    [SerializeField] private Text _thirdAxeSkill002UpgradeRequireText;
    [SerializeField] private Text _thirdAxeSkill003UpgradeRequireText;

    // Update is called once per frame
    void Update()
    {
        Display("DefaultFirstNormalAxeSkill", _defaultFirstNormalAxeSkillRequireText);
        Display("DefaultSecondNormalAxeSkill", _defaultSecondNormalAxeSkillRequireText);

        Display("FirstAxeSkill001", _firstAxeSkill001UpgradeRequireText);

        Display("SecondAxeSkill001", _secondAxeSkill001UpgradeRequireText);
        Display("SecondAxeSkill002", _secondAxeSkill002UpgradeRequireText);
        Display("SecondAxeSkill003", _secondAxeSkill003UpgradeRequireText);

        Display("ThirdAxeSkill001", _thirdAxeSkill001UpgradeRequireText);
        Display("ThirdAxeSkill002", _thirdAxeSkill002UpgradeRequireText);
        Display("ThirdAxeSkill003", _thirdAxeSkill003UpgradeRequireText);

    }

    private void Display(string skillName, Text skillUpgradeRequirementText)
    {
        Skill skill = RuntimeSkillData.SkillDictionary[skillName];
        if (skill.IsUnlocked)
        {
            if (skill.Level < skill.MaxLevel - 1)
            {
                skillUpgradeRequirementText.text = "< Exp: " + skill.ExpToUpgradeArray[skill.Level - 1] + " >";
            }
            else if (skill.Level == skill.MaxLevel - 1)
            {
                skillUpgradeRequirementText.text = "< Exp: " + skill.ExpToUpgradeArray[skill.Level - 1] + ", BKP: 1 >";
            }
            else if (skill.Level == skill.MaxLevel)
            {
                skillUpgradeRequirementText.text = "< Max Level >";
            }
        }
    }
}
