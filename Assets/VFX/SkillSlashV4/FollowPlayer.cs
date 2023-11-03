using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;

    private void OnEnable()
    {
        transform.position = _playerTransform.position;
        transform.forward = _playerTransform.forward;
    }
}
