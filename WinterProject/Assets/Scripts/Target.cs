using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public float maxHealth = 50f;

    virtual public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
