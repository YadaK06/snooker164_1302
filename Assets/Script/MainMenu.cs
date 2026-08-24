using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject adjustpanel;

    [SerializeField]
    private Slider volumeSlider;
    void Start()
    {
        volumeSlider.value = AudioManager.instance.LoadCurrentMasterVolume();
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

    public void SetVolume(float volume)
    {
        AudioManager.instance.AdjustMasterVolume(volume);
    }
}
