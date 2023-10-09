using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void StartMenu() => SceneManager.LoadScene(0);
    
    public void PlayGame() => SceneManager.LoadScene(1);
   
    public void QuitGame() => Application.Quit();
}