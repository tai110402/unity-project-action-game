using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Boss1Attack : ActionNode
{
    public string _skillAnimationName;
    public float _minDistance = 0f;
    public float _maxDistance = 5f;
    public float _thirdSkillCondition = 1;
    private GameObject _playerGameObject;

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        _playerGameObject = GameObject.FindWithTag("Player");
        float distance = (context.gameObject.transform.position - _playerGameObject.transform.position).magnitude;

        if (_minDistance <= distance && distance <= _maxDistance)
        {
            Boss1Skill boss1Skill = context.gameObject.GetComponent<Boss1Skill>();

            if (context.animator.GetCurrentAnimatorStateInfo(0).IsName(_skillAnimationName))
            {
                context.agent.ResetPath();
                return State.Running;
            }

            if (_skillAnimationName == "DefaultRangeSkill")
            {
                boss1Skill.DefaultRangeSkillEx();
            }
            if (_skillAnimationName == "FirstSkill")
            {
                boss1Skill.FirstSkillEx();
               
            }
            if (_skillAnimationName == "SecondSkill")
            {
                boss1Skill.SecondSkillEx();
            }
            if (_skillAnimationName == "ThirdSkill")
            {
                if (boss1Skill.IntrinsicList.Count >= _thirdSkillCondition)
                {
                    boss1Skill.ThirdSkillEx();
                }
            }
        }
        if (context.animator.GetCurrentAnimatorStateInfo(0).IsName(_skillAnimationName))
        {
            context.agent.ResetPath();
            return State.Running;
        }

        return State.Success;
    }
}
