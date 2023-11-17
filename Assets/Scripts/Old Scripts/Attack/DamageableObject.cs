using TheKiwiCoder;
using UnityEngine;
public class DamageableObject : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth;

    public int CurrentHealth { get { return _currentHealth; } set { _currentHealth = value; } }
    public int MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damageAmount)
    {
        _currentHealth -= damageAmount;

        if (_currentHealth <= 0)
        {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.GetComponent<BehaviourTreeRunner>().enabled = false;
            gameObject.GetComponent<Animator>().CrossFade("EnemyDeath", 0f);

            GameObject.Destroy(gameObject, 4f);
        }
    }
}
