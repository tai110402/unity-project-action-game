using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXSwordSkillSlashControl : MonoBehaviour
{
    [SerializeField] private GameObject[] _VFXNormalSkillObject;
    [SerializeField] private GameObject[] _VFXFirstSkill001Object;
    [SerializeField] private GameObject[] _VFXSecondSkill001Object;
    [SerializeField] private GameObject[] _VFXThirdSkill001Object;

    [SerializeField] private GameObject[] _VFXFirstSkill002Object;
    [SerializeField] private GameObject[] _VFXSecondSkill002Object;
    [SerializeField] private GameObject[] _VFXThirdSkill002Object;

    [SerializeField] private GameObject[] _VFXFirstSkill003Object;
    [SerializeField] private GameObject[] _VFXSecondSkill003Object;
    [SerializeField] private GameObject[] _VFXThirdSkill003Object;

    [SerializeField] private float _timeSetVFX=  0.4f;

    void SetVFXFirstNormalSwordSkillActiveTrue()
    {
        _VFXNormalSkillObject[0].SetActive(true);
        Invoke(nameof(SetVFXFirstNormalSwordSkillActiveFalse), _timeSetVFX);
    }
    void SetVFXFirstNormalSwordSkillActiveFalse()
    {
        _VFXNormalSkillObject[0].SetActive(false);
    }

    void SetVFXSecondNormalSwordSkillActiveTrue()
    {
        _VFXNormalSkillObject[1].SetActive(true);
        Invoke(nameof(SetVFXSecondNormalSwordSkillActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondNormalSwordSkillActiveFalse()
    {
        _VFXNormalSkillObject[1].SetActive(false);
    }

    // 001
    void SetVFXFirstSwordSkill001ActiveTrue()
    {
        _VFXFirstSkill001Object[0].SetActive(true);
        Invoke(nameof(SetVFXFirstSwordSkill001ActiveFalse), _timeSetVFX);
    }

    void SetVFXFirstSwordSkill001ActiveFalse()
    {
        _VFXFirstSkill001Object[0].SetActive(false);
    }

    void SetVFXSecondSwordSkill001Slash1ActiveTrue()
    {
        _VFXSecondSkill001Object[0].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill001Slash1ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill001Slash1ActiveFalse()
    {
        _VFXSecondSkill001Object[0].SetActive(false);
    }

    void SetVFXSecondSwordSkill001Slash2ActiveTrue()
    {
        _VFXSecondSkill001Object[1].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill001Slash2ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill001Slash2ActiveFalse()
    {
        _VFXSecondSkill001Object[1].SetActive(false);
    }

    void SetVFXSecondSwordSkill001Slash3ActiveTrue()
    {
        _VFXSecondSkill001Object[2].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill001Slash3ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill001Slash3ActiveFalse()
    {
        _VFXSecondSkill001Object[2].SetActive(false);
    }

    void SetVFXThirdSwordSkill001ActiveTrue()
    {
        _VFXThirdSkill001Object[0].SetActive(true);
        Invoke(nameof(SetVFXThirdSwordSkill001ActiveFalse), _timeSetVFX);
    }

    void SetVFXThirdSwordSkill001ActiveFalse()
    {
        _VFXThirdSkill001Object[0].SetActive(false);
    }

    //002
    void SetVFXFirstSwordSkill002ActiveTrue()
    {
        _VFXFirstSkill002Object[0].SetActive(true);
        Invoke(nameof(SetVFXFirstSwordSkill002ActiveFalse), _timeSetVFX);
    }

    void SetVFXFirstSwordSkill002ActiveFalse()
    {
        _VFXFirstSkill002Object[0].SetActive(false);
    }

    void SetVFXSecondSwordSkill002Slash1ActiveTrue()
    {
        _VFXSecondSkill002Object[0].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill002Slash1ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill002Slash1ActiveFalse()
    {
        _VFXSecondSkill002Object[0].SetActive(false);
    }

    void SetVFXSecondSwordSkill002Slash2ActiveTrue()
    {
        _VFXSecondSkill002Object[1].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill002Slash2ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill002Slash2ActiveFalse()
    {
        _VFXSecondSkill002Object[1].SetActive(false);
    }

    //void SetVFXSecondSwordSkill002Slash3ActiveTrue()
    //{
    //    _VFXSecondSkill002Object[2].SetActive(true);
    //    Invoke(nameof(SetVFXSecondSwordSkill002Slash3ActiveFalse), _timeSetVFX);
    //}
//
    //void SetVFXSecondSwordSkill002Slash3ActiveFalse()
    //{
    //    _VFXSecondSkill002Object[2].SetActive(false);
    //}

    void SetVFXThirdSwordSkill002Slash1ActiveTrue()
    {
        _VFXThirdSkill002Object[0].SetActive(true);
        Invoke(nameof(SetVFXThirdSwordSkill002Slash1ActiveFalse), _timeSetVFX);
    }

    void SetVFXThirdSwordSkill002Slash1ActiveFalse()
    {
        _VFXThirdSkill002Object[0].SetActive(false);
    }

    void SetVFXSwordSkill002Slash2ActiveTrue()
    {
        _VFXThirdSkill002Object[1].SetActive(true);
        Invoke(nameof(SetVFXThirdSwordSkill002Slash2ActiveFalse), _timeSetVFX);
    }

    void SetVFXThirdSwordSkill002Slash2ActiveFalse()
    {
        _VFXThirdSkill002Object[1].SetActive(false);
    }

    //003
    void SetVFXFirstSwordSkill003ActiveTrue()
    {
        _VFXFirstSkill003Object[0].SetActive(true);
        Invoke(nameof(SetVFXFirstSwordSkill003ActiveFalse), _timeSetVFX);
    }

    void SetVFXFirstSwordSkill003ActiveFalse()
    {
        _VFXFirstSkill003Object[0].SetActive(false);
    }

    void SetVFXSecondSwordSkill003Slash1ActiveTrue()
    {
        _VFXSecondSkill003Object[0].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill003Slash1ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill003Slash1ActiveFalse()
    {
        _VFXSecondSkill003Object[0].SetActive(false);
    }

    void SetVFXSecondSwordSkill003Slash2ActiveTrue()
    {
        _VFXSecondSkill003Object[1].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill003Slash2ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill003Slash2ActiveFalse()
    {
        _VFXSecondSkill003Object[1].SetActive(false);
    }

    void SetVFXSecondSwordSkill003Slash3ActiveTrue()
    {
        _VFXSecondSkill003Object[2].SetActive(true);
        Invoke(nameof(SetVFXSecondSwordSkill003Slash3ActiveFalse), _timeSetVFX);
    }

    void SetVFXSecondSwordSkill003Slash3ActiveFalse()
    {
        _VFXSecondSkill003Object[2].SetActive(false);
    }

    void SetVFXThirdSwordSkill003ActiveTrue()
    {
        _VFXThirdSkill003Object[0].SetActive(true);
        Invoke(nameof(SetVFXThirdSwordSkill003ActiveFalse), _timeSetVFX);
    }

    void SetVFXThirdSwordSkill003ActiveFalse()
    {
        _VFXThirdSkill003Object[0].SetActive(false);
    }
}
