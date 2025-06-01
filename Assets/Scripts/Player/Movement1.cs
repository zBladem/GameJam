using UnityEngine;

public class Movement1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float ySpeed;
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

        mov.y = ySpeed;
        Vector2 mousePosition = Input.mousePosition;
        if (Input.GetMouseButton(0))
        {
            if(mousePosition.x< Screen.width/2)
            {
                mov.x = -1;
            }
            else if (mousePosition.x > Screen.width / 2)
            {
                mov.x = 1;
            }
                
        }
        //mov.Normalize();
       ani.SetFloat("Movement",mov.y);
    }
    private void FixedUpdate()
    {
        rgbd.MovePosition(rgbd.position + mov*speed * Time.deltaTime);
    }
}
