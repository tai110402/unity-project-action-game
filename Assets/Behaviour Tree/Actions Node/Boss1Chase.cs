using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Boss1Chase : ActionNode
{
    private float _minChaseDistance = 10f;
    private float _maxChaseDistance = 20f;
    private float _chaseSpeed = 4f;

    private GameObject _playerGameObject;
    protected override void OnStart() {
        
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        _playerGameObject = GameObject.FindWithTag("Player");

        float distance = (_playerGameObject.transform.position - context.gameObject.transform.position).magnitude;
        if (distance > _maxChaseDistance)
        {
            return State.Success;
        } else if (_minChaseDistance <= distance && distance <= _maxChaseDistance)
        {
            context.agent.speed = _chaseSpeed;
            context.agent.SetDestination(_playerGameObject.transform.position);
            return State.Running;
        } else if (distance < _minChaseDistance)
        {
            context.agent.ResetPath();
            return State.Success;
        }
        return State.Running;
    }
}
