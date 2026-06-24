using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                GetComponent<PlayerDeath>().OnDeath();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}