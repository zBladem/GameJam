using UnityEngine;

public class Chase : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<Health>().currentHP() <= 0)
        {
            rb2d.linearVelocity = new Vector2(0, 1) * speed;
        }
    }
}
