using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public void LoadMotion()
    {
        SceneManager.LoadScene("MOTION");
    }

    public void LoadSight()
    {
        SceneManager.LoadScene("SIGHT");
    }

    public void LoadSound()
    {
        SceneManager.LoadScene("SOUND");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
