using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    bool onCD = false;
    float cdTimer = 0;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject screamer;
    bool gameover = false;
    float littleTimer = 0;
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
        if (gameover)
        {
            screamer.SetActive(true);
            littleTimer += Time.deltaTime;
        }
        if (littleTimer >= 2)
        {
            SceneManager.LoadScene("GameOver");
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
                gameover = true;
            }
        }
    }

    public int currentHP()
    {
        return hp;
    }
}
