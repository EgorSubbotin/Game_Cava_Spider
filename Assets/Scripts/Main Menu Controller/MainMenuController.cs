using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
