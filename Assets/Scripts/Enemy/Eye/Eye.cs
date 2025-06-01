using System.Collections;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    Animator animator;
    BoxCollider2D bCol;

    void Start()
    {
        bCol = GetComponent<BoxCollider2D>();
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
        yield return new WaitForSeconds(7);
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
            Destroy(bCol);
            Debug.Log("asda");
            animator.SetTrigger("Die");
            Destroy(gameObject, 0.4f);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
