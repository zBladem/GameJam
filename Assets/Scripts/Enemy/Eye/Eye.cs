using System.Collections;
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

        StartCoroutine(destroy());

    }
    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        animator.SetTrigger("Die");
        Destroy(this.gameObject,2);
        yield return null;
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
