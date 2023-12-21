using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private string _rangeAttackAnimationName = "RangeAttack";
    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _projectileVelocity = 10f;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _target;

    private Animator _enemyAnimator;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            RangeAttack();
        }

        //RangeAttack();
    }

    private void RangeAttack()
    {
        //transform.forward = (_target.position - transform.position);
        _enemyAnimator.CrossFade(_rangeAttackAnimationName, 0.1f);
        
    }

    private void MeleeAttack()
    {

    }

    public void ThrowObject()
    {
        Debug.Log("ok");
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
