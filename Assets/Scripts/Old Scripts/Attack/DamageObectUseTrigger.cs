using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObectUseTrigger : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        DamageableObject damgeableObject = other.GetComponent<DamageableObject>();

        if (damgeableObject != null)
        {
            damgeableObject.Damage(_damage);
            Debug.Log("dame");
        }
    }
}
