using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAxeSkill : MonoBehaviour
{
    private void Upgrade(string skillName)
    {
        Skill skill = RuntimeSkillData.SkillDictionary[skillName];
        PlayerData playerData = RuntimePlayerData.PlayerData;
        if (skill.IsUnlocked == true && playerData.Exp >= skill.ExpToUpgradeArray[skill.Level - 1] && skill.Level < skill.MaxLevel)
        {
            if (skill.Level == skill.MaxLevel - 1)
            {
                if (playerData.BossKillPoint >= 1)
                {
                    playerData.Exp -= skill.ExpToUpgradeArray[skill.Level - 1];
                    playerData.BossKillPoint -= 1;
                    skill.Level += 1;
                }
            }
            else
            {
                playerData.Exp -= skill.ExpToUpgradeArray[skill.Level - 1];
                Debug.Log(skill.Level + "  " + skill.ExpToUpgradeArray[skill.Level - 1]);
                skill.Level += 1;
            }
        }
    }

    // Normal Skill
    public void DefaultFirstNormalAxeSkillUpgrade()
    {
        Upgrade("DefaultFirstNormalAxeSkill");
    }

    public void DefaultSecondNormalAxeSkillUpgrade()
    {
        Upgrade("DefaultSecondNormalAxeSkill");
    }

    // Skill 1
    public void FirstAxeSkill001Upgrade()
    {
        Upgrade("FirstAxeSkill001");
    }

    // Skill 2
    public void SecondAxeSkill001Upgrade()
    {
        Upgrade("SecondAxeSkill001");
    }

    public void SecondAxeSkill002Upgrade()
    {
        Upgrade("SecondAxeSkill002");
    }

    public void SecondAxeSkill003Upgrade()
    {
        Upgrade("SecondAxeSkill003");
    }

    // Skill 3
    public void ThirdAxeSkill001Upgrade()
    {
        Upgrade("ThirdAxeSkill001");
    }

    public void ThirdAxeSkill002Upgrade()
    {
        Upgrade("ThirdAxeSkill002");
    }

    public void ThirdAxeSkill003Upgrade()
    {
        Upgrade("ThirdAxeSkill003");
    }
}
