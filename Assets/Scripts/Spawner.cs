using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float cooldown;
    float minX, maxX, posY;
    void Start()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();

        if (box != null )
        {
            Vector2 centro = box.bounds.center;
            Vector2 size = box.bounds.size;

            minX = centro.x - size.x / 2f;
            maxX = centro.x + size.x / 2f;
            posY = centro.y;
        }
        InvokeRepeating(nameof(Spawnear), 1f, cooldown);
    }
    void Spawnear()
    {
        float randomX = Random.Range(minX, maxX);
        Vector3 posspaw = new Vector3(randomX, posY, 0f);
        Instantiate(enemy,posspaw,Quaternion.identity);
    }

    void Update()
    {
        
    }
}
