using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class BossHP : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    Animator animator;
    private float range1=-6;
    private float range2 = 5.7f;
    [SerializeField] int Life = 20;
    [SerializeField]private Vector2 TargetPos;
    [SerializeField] float MYTIME;
    [SerializeField] float MAXTIME;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(Movement());
    }
    private IEnumerator Movement()
    {
        while(true)
        {
            for (float i = 0; i < MAXTIME; i+=Time.deltaTime)
            {
                MYTIME = MYTIME + 0.5f;
                TargetPos = new Vector2(Random.Range(range1, range2), transform.position.y);
                transform.position = new Vector2(Mathf.Lerp(transform.position.x, TargetPos.x, MYTIME), transform.position.y);
                yield return new WaitForSeconds(1);
            }
            MYTIME = 0;
            yield return new WaitForSeconds(MAXTIME);
        }
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
    }
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, Player.transform.position.y-5);
    }
}
