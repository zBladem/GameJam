using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] int hp;
    bool onCD = false;
    float cdTimer = 0;
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject screamer;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Face;
    [SerializeField] GameObject BlackScreen;
    [SerializeField] GameObject Music;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip hurtSound;
    AudioSource audios;
    bool gameover = false;
    bool FirstLevel = false;
    float littleTimer = 0;
    float TimerLine = 0;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audios = GetComponent<AudioSource>();
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
            UI.SetActive(false);
            Face.SetActive(false);
            littleTimer += Time.deltaTime;
        }
        if (littleTimer >= 2)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (FirstLevel)
        {
            TimerLine += Time.deltaTime;
        }
        if (TimerLine >= 2)
        {
            SceneManager.LoadScene("Nivel2");
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
                audios.PlayOneShot(hurtSound);
            }
        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (hp <= 0)
            {
                gameover = true;
                audios.PlayOneShot(jumpSound);
            }
        }
        if (collision.gameObject.CompareTag("Limit"))
        {
            gameover = true;
        }
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            FirstLevel = true;
            BlackScreen.SetActive(true);
            Music.GetComponent<AudioSource>().volume = 0;
        }
        if (collision.gameObject.CompareTag("LevelOneLimit"))
        {
            SceneManager.LoadScene("Nivel1");
        }
        if (collision.gameObject.CompareTag("EndExit"))
        {
            SceneManager.LoadScene("Nivel3");
        }
    }

    public int currentHP()
    {
        return hp;
    }
}
