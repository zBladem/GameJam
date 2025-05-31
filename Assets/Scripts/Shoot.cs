using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Destroy(gameObject);
    }
}
