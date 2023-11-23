using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Skill : MonoBehaviour
{
    private DamageableObject _damageableObject;
    private Animator _boss2Animator;

    // Intrinsic Skill
    [SerializeField] private GameObject _intrinsicSkillGameObject;

    // First Skill
    [SerializeField] private GameObject _firstSkillGameObject;

    // Start is called before the first frame update
    void Start()
    {
        _damageableObject = GetComponent<DamageableObject>();
        _boss2Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_damageableObject.CurrentHealth < _damageableObject.MaxHealth / 2)
        {
            StartCoroutine(Intrinsic());
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(FirstSkill());
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(SecondSkill());
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(ThirdSkill());
        }
    }

    IEnumerator Intrinsic()
    {
        _boss2Animator.CrossFade("IntrinsicSkill", 0.2f);
        _intrinsicSkillGameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        _intrinsicSkillGameObject.SetActive(false);
    }

    IEnumerator FirstSkill()
    {
        _boss2Animator.CrossFade("FirstSkill", 0f);
        yield return new WaitForSeconds(0.2f);
        _firstSkillGameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        _firstSkillGameObject.SetActive(false);
    }

    IEnumerator SecondSkill()
    {
        _boss2Animator.CrossFade("SecondSkill", 0f);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator ThirdSkill()
    {
        _boss2Animator.CrossFade("ThirdSkill", 0f);
        yield return new WaitForSeconds(0.5f);
    }
}
