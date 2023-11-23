using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private Transform _camXZDirection;
    [SerializeField] private string _dashAnimationName = "Dash";
    [SerializeField] private float _dashTime = 0.1f;
    [SerializeField] private float _dashSpeed = 15f;
    [SerializeField] private float _dashCooldown = 1f;
    [SerializeField] private float _dashStart = -5000f;
    [SerializeField] private CharacterTrail[] _characterTrail;

    private CharacterController _characterController;
    private Animator _playerAnimator;
    private bool _isDashPressed;

    public bool IsDashPressed { set { _isDashPressed = value; } get { return _isDashPressed; } }
    public float DashStart { set { _dashStart = value; } get { return _dashStart; } }
    public float DashCooldown { set { _dashCooldown = value; } get { return _dashCooldown; } }

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimator = GetComponent<Animator>();
        _dashStart = Time.time - _dashCooldown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isDashPressed)
        {

            if (Time.time - _dashStart > _dashCooldown)
            {
                _dashStart = Time.time;

                for (int i = 0; i < _playerAnimator.layerCount; i++)
                {
                    _playerAnimator.CrossFade(_dashAnimationName, 0f, i);
                }

                StartCoroutine(Dash());
                for (int i = 0; i < _characterTrail.Length; i++)
                {
                    _characterTrail[i].StartCharacterTrail();
                }
            }
            _isDashPressed = false;
        }
    }

    private IEnumerator Dash()
    {
        float startTime = Time.time;
        while (Time.time < startTime + _dashTime)
        {
            Vector3 dashDirection = transform.forward;
            _characterController.Move(dashDirection * _dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
