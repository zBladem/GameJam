using UnityEngine;

public class BoxHealth : MonoBehaviour
{
    public float life = 5;
    bool isDestroyed = false;
    Animator animator;
    BoxCollider2D bCol;
    public bool IsDestroyed
    {
        get { return isDestroyed; }
        set { isDestroyed = value; }
    }
    void Start()
    {
        bCol = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(bCol);
            if(life <= 0)
            {
                Destroy(gameObject, 2f);
                isDestroyed = true;
            }
            Debug.Log("BoxDestroyed");
        }
    }
}
