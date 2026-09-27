using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonmanage : MonoBehaviour
{
    public void LoadExit()
    {
        SceneManager.LoadScene("exit");
    }
    public void GoGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Main()
    {
        SceneManager.LoadScene("menu");
    }

    public void ScoreShowin()
    {
        SceneManager.LoadScene("scoreboard");
    }
    public void GameExit()
    {

        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }
   
}
