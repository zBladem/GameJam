using UnityEngine;

public class reloj : MonoBehaviour
{
    float relojspeed;
    Rigidbody2D rigireloj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigireloj = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
