using UnityEngine;
using System.Collections;

public class genericHP : MonoBehaviour
{
    public float speed = 5f;
    private Transform player;
    private BoxCollider2D boxCollider2D;
    Animator animator;

    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
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
        animator.SetTrigger("dying");
        Destroy(this.gameObject, 1);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(boxCollider2D);
            Debug.Log("asda");
            animator.SetTrigger("dying");
            Destroy(gameObject, 2f);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
