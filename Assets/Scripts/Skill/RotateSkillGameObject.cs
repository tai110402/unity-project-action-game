using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSkillGameObject : MonoBehaviour
{
    [SerializeField] private float _x;
    [SerializeField] private float _y;
    [SerializeField] private float _z;
    void Update()
    {
        transform.Rotate(new Vector3(_x, _y, _z));
    }
}
