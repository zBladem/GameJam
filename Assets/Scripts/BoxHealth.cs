using UnityEngine;

public class BoxHealth : MonoBehaviour
{
    public float life = 5;
    bool isDestroyed = false;
    Animator animator;
    BoxCollider2D bCol;
    [SerializeField] GameObject stopColl;
    public bool IsDestroyed
    {
        get { return isDestroyed; }
        set { isDestroyed = value; }
    }
    void Start()
    {
        bCol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        switch (life)
        {
            case 5:
                animator.SetInteger("boxStates",0);
                break;
            case 4:
                animator.SetInteger("boxStates", 1);
                break;
            case 3:
                animator.SetInteger("boxStates", 1);
                break;
            case 2:
                animator.SetInteger("boxStates", 2);
                break;
            case 1:
                animator.SetInteger("boxStates", 2);
                break;
            case 0:
                animator.SetInteger("boxStates", 3);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            life--;
            if(life <= 0)
            {
                Destroy(bCol);
                Destroy(stopColl);
                isDestroyed = true;
            }
            Debug.Log("BoxDestroyed");
        }
    }
}
