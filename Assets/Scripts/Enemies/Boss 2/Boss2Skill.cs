using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Skill : MonoBehaviour
{
    private DamageableObject _damageableObject;
    private Animator _boss2Animator;

    // Intrinsic Skill
    [SerializeField] private GameObject _intrinsicSkillGameObject;

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

    }

    IEnumerator Intrinsic()
    {
        _boss2Animator.CrossFade("IntrinsicSkill", 0f);
        _intrinsicSkillGameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        _intrinsicSkillGameObject.SetActive(false);
    }
}
