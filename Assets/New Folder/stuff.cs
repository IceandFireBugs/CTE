using UnityEngine;
using UnityEngine.SceneManagement; 

public class stuff : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BabyByeByeBye()
    {
        Application.Quit();

    }
}
