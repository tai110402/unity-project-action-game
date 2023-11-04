using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXAxeSkillSlashControl : MonoBehaviour
{
    [SerializeField] private GameObject[] _VFXNormalSkillObject;
    [SerializeField] private GameObject[] _VFXFirstSkill001Object;
    [SerializeField] private GameObject[] _VFXSecondSkill001Object;
    [SerializeField] private GameObject[] _VFXThirdSkill001Object;
    [SerializeField] private float _timeSetVFX = 0.4f;

    void SetVFXFirstNormalAxeSkillActiveTrue()
    {
        _VFXNormalSkillObject[0].SetActive(true);
        Invoke(nameof(SetVFXFirstNormalAxeSkillActiveFalse), _timeSetVFX);
    }
    void SetVFXFirstNormalAxeSkillActiveFalse()
    {
        _VFXNormalSkillObject[0].SetActive(false);
    }

    void SetVFXSecondNormalAxeSkillActiveTrue()
    {
        _VFXNormalSkillObject[1].SetActive(true);
        Invoke(nameof(SetVFXSecondNormalAxeSkillActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondNormalAxeSkillActiveFalse()
    {
        _VFXNormalSkillObject[1].SetActive(false);
    }

    void SetVFXFirstSkill001ActiveTrue()
    {
        _VFXFirstSkill001Object[0].SetActive(true);
        Invoke(nameof(SetVFXFirstSkill001ActiveFalse), _timeSetVFX);
    }

    void SetVFXFirstSkill001ActiveFalse()
    {
        _VFXFirstSkill001Object[0].SetActive(false);
    }

    void SetVFXSecondAxeSkill001Slash1ActiveTrue()
    {
        _VFXSecondSkill001Object[0].SetActive(true);
        Invoke(nameof(SetVFXSecondAxeSkill001Slash1ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondAxeSkill001Slash1ActiveFalse()
    {
        _VFXSecondSkill001Object[0].SetActive(false);
    }

    void SetVFXSecondAxeSkill001Slash2ActiveTrue()
    {
        _VFXSecondSkill001Object[1].SetActive(true);
        Invoke(nameof(SetVFXSecondAxeSkill001Slash2ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondAxeSkill001Slash2ActiveFalse()
    {
        _VFXSecondSkill001Object[1].SetActive(false);
    }

    void SetVFXSecondAxeSkill001Slash3ActiveTrue()
    {
        _VFXSecondSkill001Object[2].SetActive(true);
        Invoke(nameof(SetVFXSecondAxeSkill001Slash3ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondAxeSkill001Slash3ActiveFalse()
    {
        _VFXSecondSkill001Object[2].SetActive(false);
    }

    void SetVFXThirdAxeSkill001ActiveTrue()
    {
        _VFXThirdSkill001Object[0].SetActive(true);
        Invoke(nameof(SetVFXThirdAxeSkill001ActiveFalse), _timeSetVFX);
    }

    void SetVFXThirdAxeSkill001ActiveFalse()
    {
        _VFXThirdSkill001Object[0].SetActive(false);
    }
}
