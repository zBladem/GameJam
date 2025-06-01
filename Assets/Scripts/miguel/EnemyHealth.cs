using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    [SerializeField] private Color invulnerableColor = Color.black; // Enemigos negros no reciben da�o
    private SpriteRenderer sr;

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (sr != null && sr.color == invulnerableColor)
        {
            Debug.Log("Este enemigo es negro y no puede recibir da�o.");
            return;
        }

        currentHealth -= damage;
        Debug.Log("Enemigo da�ado. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
