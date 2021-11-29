using UnityEngine;

public abstract class CharacterLife : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int currentHealth;

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
            Die();
    }

    protected abstract void Die();
}
