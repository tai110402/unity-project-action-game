using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Boss1FirstAttack : ActionNode
{
    private float _minDistance = 20f;
    private float _maxDistance = 25F;
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
            if (boss1Skill.IntrinsicList.Count >= 1)
            {
                boss1Skill.ThirdSkillEx();
            }
        }

        if (context.animator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSkill"))
        {
            return State.Running;
        }

        return State.Failure;
    }
}
