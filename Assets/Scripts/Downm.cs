using UnityEngine;

public class Downm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float resetpos;
    [SerializeField] private float limtiy;



    void Update()
    {
        transform.Translate(Vector2.down * speed);


        if (transform.position.y > limtiy)
        {
            Vector3 newpos= transform.position;
            newpos.y += resetpos;
            transform.position = newpos;
        }
    }
}
