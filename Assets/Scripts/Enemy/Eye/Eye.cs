using UnityEngine;

public class Eye : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    Animator animator;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("asda");
            animator.SetTrigger("Die");
            Destroy(gameObject, 2f);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
