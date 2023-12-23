using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    private float timeFollow = 0.05f;
    private void OnEnable()
    {
        float time = Time.time;
        StartCoroutine(Follow(time, timeFollow));
    }

    IEnumerator Follow(float startTime, float followTime)
    {
        while (Time.time - startTime < followTime)
        {
            transform.position = _playerTransform.position;
            transform.forward = _playerTransform.forward;
            yield return new WaitForSeconds(0.001f);
        }
    }
}
