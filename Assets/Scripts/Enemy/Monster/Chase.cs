using UnityEngine;

public class Chase : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;
    SpriteRenderer spr;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        switch (GameObject.FindWithTag("Player").GetComponent<Health>().currentHP())
        {
            case 0:
                rb2d.linearVelocity = new Vector2(0, 1) * speed;
                spr.color = new Color(1, 1, 1, 1);
                break;
            case 1:
                spr.color = new Color(1, 1, 1, 0.5f);
                break;
            case 2:
                spr.color = new Color(1, 1, 1, 0.25f);
                break;
            case 3:
                spr.color = new Color(1, 1, 1, 0);
                break;
        }
    }
}
