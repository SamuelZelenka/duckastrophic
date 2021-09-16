using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCommands : MonoBehaviour
{
    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void QuitGame() => Application.Quit();

    public void NextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
