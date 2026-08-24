using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject adjustpanel;
    void Start()
    {
        AudioManager.instance.PlayBGM(0);
    }

    public void StartNewGame()
    {
        Setting.fromSave = false;
        SceneManager.LoadScene("Loading");
    }

    public void LoadsaveGame()
    {
        Setting.fromSave = true;
        SceneManager.LoadScene("Loading");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHideAdjustpanel(bool flag)
    {
        adjustpanel.SetActive(flag);
    }
}
