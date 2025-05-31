using UnityEngine;

public class Hearts : MonoBehaviour
{
    SpriteRenderer spr;
    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        switch (GameObject.FindWithTag("Player").GetComponent<Health>().currentHP())
        {
            case 0:
                Destroy(gameObject);
                break;
            case 1:
                spr.size = new Vector2(1, 1);
                break;
            case 2:
                spr.size = new Vector2(2, 1);
                break;
            case 3:
                spr.size = new Vector2(3, 1);
                break;
        }
    }
}
