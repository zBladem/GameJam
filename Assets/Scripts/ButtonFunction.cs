using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonFunction : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void Change()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
