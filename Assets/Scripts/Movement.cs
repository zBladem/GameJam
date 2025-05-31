using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rgbd;
    private Vector2 mov;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rgbd=GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");
        mov.Normalize();
       
    }
    private void FixedUpdate()
    {
        rgbd.MovePosition(rgbd.position + mov*speed * Time.deltaTime);
    }
}
