using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        
        SceneManager.LoadScene("Game Scene"); // Replace "YourGameSceneName" with the actual name of your game scene
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
