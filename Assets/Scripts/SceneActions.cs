using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneActions : MonoBehaviour
{
    public void LoadIndexScene(int index)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(index);
    }

    public void LoadThisScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void FrizeTime()
    {
        Time.timeScale = 0f;
    }

    public void ReFrizeTime()
    {
        Time.timeScale = 1f;
    }
}
