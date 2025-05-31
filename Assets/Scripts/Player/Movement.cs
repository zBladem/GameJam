using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rgbd;
    private Vector2 mov;
    [SerializeField] private Animator ani;
    void Start()
    {
        rgbd=GetComponent<Rigidbody2D>();
        ani=GetComponent<Animator>();

    }

    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");

        mov.y = Input.GetAxisRaw("Vertical");
        mov.Normalize();
       ani.SetFloat("Movement",mov.y);
    }
    private void FixedUpdate()
    {
        rgbd.MovePosition(rgbd.position + mov*speed * Time.deltaTime);
    }
}
