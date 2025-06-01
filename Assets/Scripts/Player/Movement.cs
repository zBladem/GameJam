using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] BoxHealth bh;
    [SerializeField] private float speed;
    [SerializeField] private float ySpeed;
    [SerializeField] private Rigidbody2D rgbd;
    private Vector2 mov;
    [SerializeField] string sceneName;
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
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("StopZone"))
        {
            ySpeed = 0;
            StartCoroutine(ChangeLevel());
        }
        if (other.gameObject.CompareTag("StopZoneTutorial"))
        {
            ySpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StopZoneTutorial"))
        {
            ySpeed = 1;
        }
    }
}
