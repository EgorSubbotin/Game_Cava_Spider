using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameplayController : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanael;
    [SerializeField]
    Button resumeGame;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanael.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => ResumGame());
    }
    public void ResumGame()
    {
        Time.timeScale = 1f;
        pausePanael.SetActive(false);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");        
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");      
    }
    public void PlayerDied()
    {
        Time.timeScale = 0f;
        pausePanael.SetActive(true);
        resumeGame.onClick.RemoveAllListeners();
        resumeGame.onClick.AddListener(() => RestartGame());
    }
}
