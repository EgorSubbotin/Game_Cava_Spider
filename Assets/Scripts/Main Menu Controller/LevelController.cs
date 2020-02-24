using UnityEngine.SceneManagement;
using UnityEngine;
public class LevelController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void GoToManu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
