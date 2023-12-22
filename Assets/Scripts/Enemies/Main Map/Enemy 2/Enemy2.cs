using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private string _meleeAttackAnimationName = "MeleeAttack";
    [SerializeField] private Transform _target;
    [SerializeField] private float _meleeSkillCooldownTime = 3f;
    [SerializeField] private Transform _meleeDamageObjectSpawnPoint;
    [SerializeField] private GameObject _meleeDamageObject;

    private DamageableObject _damageableObject;
    private Animator _enemyAnimator;
    private NavMeshAgent _agent;
    private GameObject _player;
    private float _meleeSkillStartTime = -1000f;

    // Start is called before the first frame update
    void Start()
    {
        _damageableObject = GetComponent<DamageableObject>();
        _enemyAnimator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindWithTag("Player");

        _meleeSkillStartTime = Time.time - _meleeSkillCooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_damageableObject.CurrentHealth >= 0 && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("BlockedReaction") && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("EnemyGetHit"))
        {
            float distance = Vector3.Magnitude(_player.transform.position - transform.position);

            if (distance < 15)
            {
                if (distance > 1f)
                {
                    if (!_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName(_meleeAttackAnimationName))
                    {
                        _agent.SetDestination(_player.transform.position);
                        _enemyAnimator.CrossFade("Walk", 0f);
                    }
                }
                else
                {
                    _agent.ResetPath();

                    if (Time.time - _meleeSkillCooldownTime >= _meleeSkillStartTime)
                    {
                        _meleeSkillStartTime = Time.time;
                        MeleeAttack();
                    }
                }
            }
        }
    }

    private void MeleeAttack()
    {
        _enemyAnimator.CrossFade(_meleeAttackAnimationName, 0.1f);
    }

    public void MeleeDamageObject()
    {
        var damageObject = Instantiate(_meleeDamageObject, _meleeDamageObjectSpawnPoint.transform.position, _meleeDamageObjectSpawnPoint.transform.rotation);
        Destroy(damageObject, 0.5f);
    }
}
