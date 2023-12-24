using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageObject : MonoBehaviour
{
    [SerializeField] private int _damage = 3;
    [SerializeField] private string _enemyGameObjectTag = "Boss1";
    [SerializeField] private string _playerGetHitAnimationName = "GetStrongHit";
    [SerializeField] private bool _turnOnGetHitAnimation = false;

    private GameObject _playerGameObject;
    public int Damage { set { _damage = value; } get { return _damage; } }
    public bool TurnOnGetHitAnimation { set { _turnOnGetHitAnimation = value; } get { return _turnOnGetHitAnimation; } }

    private void Start()
    {
        _playerGameObject = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBox") && !_playerGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DefaultBlockSkill001") && !_playerGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("DefaultBlockSkill001") && !_playerGameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(2).IsName("DefaultBlockSkill001"))
        {
            int armor = RuntimeEquipmentData.EquipmentData.ArmorData.Armor[RuntimeEquipmentData.EquipmentData.ArmorData.Level-1];
            Debug.Log(armor);
            RuntimePlayerData.PlayerData.CurrentHP -= (_damage-(armor/100));

            if (_turnOnGetHitAnimation && (_playerGetHitAnimationName == "GetStrongHit" || _playerGetHitAnimationName == "GetHit"))
            {
                
                Animator x = _playerGameObject.GetComponent<Animator>();
                for (int i = 0; i < x.layerCount; i++)
                {
                    x.CrossFade(_playerGetHitAnimationName, 0f, i);
                }
                if (_playerGetHitAnimationName == "GetStrongHit")
                {
                    _playerGameObject.GetComponent<PlayerGetHit>().HitDirection = (_playerGameObject.transform.position - GameObject.FindWithTag(_enemyGameObjectTag).transform.position).normalized;

                } else if (_playerGetHitAnimationName == "GetHit")
                {
                    //playerGameObject.GetComponent<PlayerGetHit>().HitDirection = 0.1f * (playerGameObject.transform.position - GameObject.FindWithTag(_enemyGameObjectTag).transform.position).normalized;
                    _playerGameObject.GetComponent<PlayerGetHit>().HitDirection = 0.1f * (_playerGameObject.transform.position - other.transform.position).normalized;
                    Destroy(gameObject);
                }
            }
        }
    }
}
