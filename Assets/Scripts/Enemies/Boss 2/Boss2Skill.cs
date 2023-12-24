using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss2Skill : MonoBehaviour
{
    private NavMeshAgent _agent;
    private DamageableObject _damageableObject;
    private Animator _enemyAnimator;
    private GameObject _player;

    // Intrinsic Skill
    [SerializeField] private GameObject _intrinsicSkillGameObject;

    // Skill
    [SerializeField] private GameObject _firstSkillGameObject;
    [SerializeField] private Transform _firstSkillGameObjectSpawnPoint;
    [SerializeField] private float _firstSkillCooldownTime = 3f;

    [SerializeField] private GameObject _secondSkillGameObject;
    [SerializeField] private Transform _secondSkillGameObjectSpawnPoint;
    [SerializeField] private float _secondSkillCooldownTime = 3f;

    [SerializeField] private GameObject _thirdSkillGameObject;
    [SerializeField] private Transform _thirdSkillGameObjectSpawnPoint;
    [SerializeField] private float _thirdSkillCooldownTime = 10f;

    private bool _isUsedIntrinsicSkill = false;
    private float _firstSkillStartTime = -1000f;
    private float _secondSkillStartTime = -1000f;
    private float _thirdSkillStartTime = -1000f;

    // Start is called before the first frame update
    void Start()
    {
        _firstSkillStartTime = Time.time - _firstSkillCooldownTime;
        _secondSkillStartTime = Time.time - _secondSkillCooldownTime;
        _thirdSkillStartTime = Time.time - _thirdSkillCooldownTime;

        _agent = GetComponent<NavMeshAgent>();
        _damageableObject = GetComponent<DamageableObject>();
        _enemyAnimator = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_damageableObject.CurrentHealth >= 0 && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("BlockedReaction"))
        {
            if (!_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("EnemyGetHit") || (_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("EnemyGetHit") && _enemyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.5f))
            {
                float distance = Vector3.Magnitude(_player.transform.position - transform.position);

                if (distance < 15)
                {
                    if (distance > 2f)
                    {
                        if (!_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("FirstSkill") && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("SecondSkill"))
                        {
                            if (!_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSkill"))
                            {
                                if (Time.time - _thirdSkillStartTime >= _thirdSkillCooldownTime && distance < 4)
                                {
                                    ResetNavPath();
                                    _thirdSkillStartTime = Time.time;
                                    ThirdSkill();
                                }
                                else
                                {
                                    _agent.SetDestination(_player.transform.position);
                                    _enemyAnimator.CrossFade("Walk", 0f);
                                }
                            }
                        }
                    }
                    else
                    {
                        ResetNavPath();

                        if ((Time.time - _firstSkillCooldownTime >= _firstSkillStartTime) && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("SecondSkill") && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSkill"))
                        {
                            _firstSkillStartTime = Time.time;
                            FirstSkill();
                        }
                        else if (((Time.time - _secondSkillCooldownTime >= _secondSkillStartTime)) && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("FirstSkill") && !_enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("ThirdSkill"))
                        {
                            _secondSkillStartTime = Time.time;
                            SecondSkill();
                        }


                    }
                }
            }
            
        }


        if (_damageableObject.CurrentHealth < _damageableObject.MaxHealth / 2 && _isUsedIntrinsicSkill)
        {
            _isUsedIntrinsicSkill = true;
            StartCoroutine(Intrinsic());
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            FirstSkill();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SecondSkill();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            ThirdSkill();
        }
    }

    private void ResetNavPath()
    {
        if (_agent.enabled == true)
        {
            _agent.ResetPath();
        }
    }

    IEnumerator Intrinsic()
    {
        _enemyAnimator.CrossFade("IntrinsicSkill", 0f);
        _intrinsicSkillGameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        _intrinsicSkillGameObject.SetActive(false);
    }

    private void FirstSkill()
    {
        _enemyAnimator.CrossFade("FirstSkill", 0f);
    }

    public void SpawnFirstSkillObject()
    {
        var damageObject = Instantiate(_firstSkillGameObject, _firstSkillGameObjectSpawnPoint.transform.position, _firstSkillGameObjectSpawnPoint.transform.rotation);
        Destroy(damageObject, 0.2f);
    }

    private void SecondSkill()
    {
        _enemyAnimator.CrossFade("SecondSkill", 0f);
    }

    public void SpawnSecondSkillObject()
    {
        var damageObject = Instantiate(_secondSkillGameObject, _secondSkillGameObjectSpawnPoint.transform.position, _secondSkillGameObjectSpawnPoint.transform.rotation);
        Destroy(damageObject, 0.02f);
    }

    IEnumerator ThirdSkillIE()
    {
        yield return new WaitForSeconds(3f);
        _agent.enabled = true;
    }
    private void ThirdSkill()
    {
        _agent.enabled = false;
        _enemyAnimator.CrossFade("ThirdSkill", 0f);
        StartCoroutine(ThirdSkillIE());
    }

    public void SpawnThirdSkillObject()
    {
        var damageObject = Instantiate(_thirdSkillGameObject, _thirdSkillGameObjectSpawnPoint.transform.position, _thirdSkillGameObjectSpawnPoint.transform.rotation);
        Destroy(damageObject, 0.3f);
    }
}
