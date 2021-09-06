using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class InGameMenu : MonoBehaviour
{
    public UnityEvent OnMenuEnabled;
    public UnityEvent OnMenuDisabled;

    private bool _isActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isActive = !_isActive;

            if (_isActive)
            {
                EnableMenu();
            }
            else
            {
                DisableMenu();
            }
        }
    }
    public void EnableMenu()
    {
        OnMenuEnabled.Invoke();

    }

    public void DisableMenu()
    {
        OnMenuDisabled.Invoke();

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
