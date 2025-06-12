using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool FinalLevel = false;
    float lifeTime = 0;

    void Update()
    {
        if(FinalLevel==false)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            lifeTime += Time.deltaTime;
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            lifeTime += Time.deltaTime;
        }
        if (lifeTime >= 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Evil"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("TutoBox"))
        {
            Destroy(gameObject);
        }
       // Destroy(gameObject);
    }
}
