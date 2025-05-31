using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Transform toplimit;
    [SerializeField] Transform bottonlimit;
    [SerializeField] Vector2 range;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.down * speed * Time.deltaTime;
        if (transform.position.y < bottonlimit.position.y)
        {
            Regen();
        }
    }
    void Regen()
    {
        Vector3 newpos=  new Vector3(transform.position.x,toplimit.position.y,transform.position.z);
        transform.position = newpos;


        float scale = Random.RandomRange(range.x, range.y);
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
