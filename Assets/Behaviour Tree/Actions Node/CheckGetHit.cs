using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckGetHit : ActionNode
{
    [SerializeField] private string _getHitAnimationName = "EnemyGetHit";

    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (context.animator.GetCurrentAnimatorStateInfo(0).IsName(_getHitAnimationName))
        {
            return State.Running;
        } else
        {
            return State.Success;
        }
    }
}
