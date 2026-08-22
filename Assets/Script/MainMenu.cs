using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void StartNewGame()
    {
        Setting.fromSave = false;
        SceneManager.LoadScene("Loadding");
    }

    public void LoadaveGame()
    {
        Setting.fromSave = true;
        SceneManager.LoadScene("Loadding");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
