using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float speed;
    float lifeTime = 0;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); 
        lifeTime += Time.deltaTime;
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
