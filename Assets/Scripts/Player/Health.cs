using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    bool onCD = false;
    float cdTimer = 0;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (onCD)
        {
            spriteRenderer.color = Color.red;
            cdTimer += Time.deltaTime;
        }
        if (cdTimer >= 3)
        {
            spriteRenderer.color = Color.white;
            onCD = false;
            cdTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Evil"))
        {
            if (!onCD)
            {
                onCD = true;
                hp--;
            }
        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (hp <= 0)
            {
                Debug.Log("GameOver");
            }
        }
    }

    public int currentHP()
    {
        return hp;
    }
}
