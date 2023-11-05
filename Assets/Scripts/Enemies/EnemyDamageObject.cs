using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageObject : MonoBehaviour
{
    [SerializeField] private int _damage = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBox"))
        {
            RuntimePlayerData.PlayerData.CurrentHP -= _damage;
            Debug.Log("damge");
        }
    }
}
