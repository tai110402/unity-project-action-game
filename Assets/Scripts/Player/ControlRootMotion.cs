using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRootMotion : MonoBehaviour
{
    private Animator _playerAnimator;
    private PlayerMovement _playerMovement;
    private float _speedOnRootMotion = 0.05f;


    [SerializeField] private int _indexOfSwordLayer = 2;
    [SerializeField] private string[] _useRootMotionSwordAnimationArray;

    private bool isUse;

    // Start is called before the first frame update
    void Start()
    {
        _playerAnimator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            for (int i = 0; i < _useRootMotionSwordAnimationArray.Length; i++)
            {
                if (_playerAnimator.GetCurrentAnimatorStateInfo(_indexOfSwordLayer).IsName(_useRootMotionSwordAnimationArray[i]))
                {
                    ApplyRootMotion();
                    isUse = true;
                    break;
                }
                isUse = false;
            }
            if (isUse == false)
            {
                ApplyCustomMotion();
            }
        }
    }

    private void  ApplyRootMotion()
    {
        _playerAnimator.applyRootMotion = true;

        if (_playerMovement.CurrentSpeed > _speedOnRootMotion)
        {
            _playerMovement.CurrentSpeed -= 0.01f;
        }
        else if (_playerMovement.CurrentSpeed < _speedOnRootMotion)
        {
            _playerMovement.CurrentSpeed += 0.01f;
        }
    }

    private void ApplyCustomMotion()
    {
        _playerAnimator.applyRootMotion = false;
    }
}
