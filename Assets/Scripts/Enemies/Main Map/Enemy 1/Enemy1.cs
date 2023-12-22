using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private string _rangeAttackAnimationName = "RangeAttack";
    [SerializeField] private string _meleeAttackAnimationName = "MeleeAttack";
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _projectileVelocity = 10f;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _target;
    [SerializeField] private float _rangeSkillCooldownTime = 3f;
    [SerializeField] private float _meleeSkillCooldownTime = 3f;
    [SerializeField] private Transform _meleeDamageObjectSpawnPoint;
    [SerializeField] private GameObject _meleeDamageObject;

    private DamageableObject _damageableObject;
    private Animator _enemyAnimator;
    private NavMeshAgent _agent;
    private GameObject _player;
    private float _rangeSkillStartTime = -1000f;
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

            if (distance < 5)
            {
                if (distance > 1.2f)
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
            else if (distance < 15)
            {
                if (Time.time - _rangeSkillCooldownTime >= _rangeSkillStartTime)
                {
                    _rangeSkillStartTime = Time.time;
                    RangeAttack();
                }
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                RangeAttack();
            }
        }
    }

    private void RangeAttack()
    {
        _agent.enabled = false;
        Vector3 direction = Vector3.Normalize(_target.position - transform.position);
        direction = new Vector3(direction.x, 0, direction.z);
        transform.forward = (_target.position - transform.position);
        _enemyAnimator.CrossFade(_rangeAttackAnimationName, 0.1f);
        _agent.enabled = true;
    }

    private void MeleeAttack()
    {
        _enemyAnimator.CrossFade(_meleeAttackAnimationName, 0.1f);
    }

    public void MeleeDamageObject()
    {
        var damageObject = Instantiate(_meleeDamageObject, _meleeDamageObjectSpawnPoint.transform.position, _meleeDamageObjectSpawnPoint.transform.rotation);
    }

    public void ThrowObject()
    {
        Vector3 direction = ((_target.position + new Vector3(0, 1, 0)) - _spawnPoint.position).normalized;
        var projectile = Instantiate(_projectile, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
        projectile.GetComponent<Rigidbody>().velocity = direction * _projectileVelocity * Time.deltaTime;

    }

    IEnumerator Excute()
    {
        var projectile = Instantiate(_projectile, _spawnPoint.transform.position, _spawnPoint.transform.rotation);
        Vector3 c = _spawnPoint.position + (_target.position - _spawnPoint.position)/2 + new Vector3(0, 1f, 0);
        Vector3 target = _target.position;
        float t = 0f;
        while (t <= 1f)
        {
            projectile.transform.position = Evaluate(t, target, c);
            projectile.transform.up = Evaluate(t + 0.001f, target, c) - transform.position;
            t += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        // destroy this
    }

    private Vector3 Evaluate(float t, Vector3 target, Vector3 c)
    {
        Vector3 ac = Vector3.Lerp(_spawnPoint.position, c, t);
        Vector3 cb = Vector3.Lerp(c, target, t);
        Vector3 acb = Vector3.Lerp(ac, cb, t);
        return acb;
    }
}
