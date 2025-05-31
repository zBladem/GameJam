using UnityEngine;

public class Downm : MonoBehaviour
{
    public float scroll;

    private void Update()
    {
        transform.Translate(Vector3.down * scroll * Time.deltaTime);
    }
}
