using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Skill : MonoBehaviour
{

    [SerializeField] private Transform _targetTransform;
    [SerializeField] private Animator _boss1Animator;

    // Intrinsic
    [SerializeField] private GameObject _intrinsic;
    [SerializeField] private float _intrinsicCooldownTime = 2f;
    [SerializeField] private int _maxNumberOfIntrinsic = 7;
    [SerializeField] private int _intrinsicDamage = 3;
    private float _intrinsicSkillStartTime;
    private List<GameObject> _intrinsicList = new List<GameObject>();

    // Skill 1
    [SerializeField] private GameObject _firstSkillProjectile;
    [SerializeField] private Transform _firstSkillSpawnPoint;
    [SerializeField] private float _firstSkillCooldownTime = 3f;
    [SerializeField] private float _firstSkillSpeed = 3f;
    private float _firstSkillStartTime;

    // Start is called before the first frame update
    void Start()
    {
        _boss1Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Intrinsic();

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(SecondSkill());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(DefaultRangeSkill());
        }
    }

    // Boss1 intrinsic
    private void Intrinsic()
    {
        foreach(GameObject gameObject in _intrinsicList)
        {
            if (gameObject == null)
            {
                _intrinsicList.Remove(gameObject);
                _intrinsicSkillStartTime = Time.time;
                break;
            }
        }

        if (Time.time - _intrinsicSkillStartTime > _intrinsicCooldownTime && _intrinsicList.Count < _maxNumberOfIntrinsic)
        {
            var intrinsicProjectile = Instantiate(_intrinsic, transform.position + new Vector3(Random.Range(-4f,4f), Random.Range(0.2f, 0.4f), Random.Range(-4f, 4f)), transform.rotation);
            _intrinsicList.Add(intrinsicProjectile);
            _intrinsicSkillStartTime = Time.time;
        }
    }

    // Skill 1
    IEnumerator FirstSkill()
    {
        transform.forward = (_targetTransform.position - transform.position).normalized;
        _boss1Animator.CrossFade("FirstSkill", 0f);
        yield return new WaitForSeconds(0.4f);
    }

    // Skill Ultimate, active intrinsic
    IEnumerator SecondSkill()
    {
        transform.forward = (_targetTransform.position - transform.position).normalized;

        _boss1Animator.CrossFade("SecondSkill", 0f);
        yield return new WaitForSeconds(1.2f);
        foreach (GameObject gameObject in _intrinsicList)
        {
            gameObject.GetComponent<Boss1Intrinsic>().ActiveIntrinsicSkill();
            gameObject.GetComponent<EnemyDamageObject>().Damage = _intrinsicDamage;
        }
        _intrinsicList.Clear();
        _intrinsicSkillStartTime = Time.time;
    }

    private void DefaultMeleeSkill()
    {
        _boss1Animator.CrossFade("DefaultMeleeSkill", 0f);
    }

    IEnumerator DefaultRangeSkill()
    {
        transform.forward = (_targetTransform.position - transform.position).normalized;
        _boss1Animator.CrossFade("DefaultRangeSkill", 0f);
        yield return new WaitForSeconds(0.4f);

        if (Time.time - _firstSkillStartTime > _firstSkillCooldownTime)
        {
            _firstSkillStartTime = Time.time;

            var projectile = Instantiate(_firstSkillProjectile, _firstSkillSpawnPoint.position, _firstSkillSpawnPoint.rotation);

            Vector3 direction = (_targetTransform.position - _firstSkillSpawnPoint.position).normalized;
            projectile.GetComponent<Rigidbody>().velocity = direction * _firstSkillSpeed;
        }
    }
}
