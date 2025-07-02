using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    [SerializeField] string sceneName = "Victory";
    [SerializeField] float time = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeScene());
        }
    }
}
