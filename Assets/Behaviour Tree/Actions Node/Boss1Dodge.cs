using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Boss1Dodge : ActionNode
{
    public float _minDistance = 0f;
    public float _maxDistance = 5f;
    public float _speed = 3f;
    private GameObject _playerGameObject;

    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        _playerGameObject = GameObject.FindWithTag("Player");
        float distance = (context.gameObject.transform.position - _playerGameObject.transform.position).magnitude;

        if (_minDistance <= distance && distance <= _maxDistance)
        {
            Vector3 direction = (context.gameObject.transform.position - _playerGameObject.transform.position).normalized;
            if (!context.animator.GetCurrentAnimatorStateInfo(0).IsName("EnemyGetHit"))
            {
                context.agent.SetDestination(direction * 5);
                context.agent.speed = _speed;
                context.animator.CrossFade("Walk", 0f);
            }

        }

        return State.Success;
    }
}
