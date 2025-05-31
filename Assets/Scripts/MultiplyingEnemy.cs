using UnityEngine;

public class MultiplyingEnemy : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 3f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float speedBoost = 1.5f;
    [SerializeField] private Transform player;
    [SerializeField] private bool hasMultiplied = false;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRadius && !hasMultiplied)
        {

            Instantiate(enemyPrefab, transform.position + Vector3.right * 1.5f, Quaternion.identity);
            speed *= speedBoost; // Aumentar velocidad
            hasMultiplied = true;
        }

        direction = (player.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
