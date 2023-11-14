using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Boss1Attack : ActionNode
{
    private float _minDistance = 0f;
    private float _maxDistance = 5f;
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
            boss1Skill.SecondSkillEx();

            if (context.animator.GetCurrentAnimatorStateInfo(0).IsName("SecondSkill"))
            {
                return State.Running;
            }

            if (boss1Skill.IntrinsicList.Count >= 3)
            {
                boss1Skill.ThirdSkillEx();
            }
            if (context.animator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSkill"))
            {
                return State.Running;
            }
        }
        return State.Success;
    }
}
