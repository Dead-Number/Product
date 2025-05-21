#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;


public class MainMenueManadger : MonoBehaviour
{
    public AudioSource oldcomputerSound;

    public GameObject _menu;
    public GameObject _effect;
    public GameObject _effect2;

    private void Start()
    {
        Time.timeScale = 0;

        oldcomputerSound.Play();

        _effect2.SetActive(false);
    }
    public void StartGame()
    {
        Time.timeScale = 1;

        _menu.SetActive(false);

        oldcomputerSound.Pause();

        _effect.SetActive(false);
        _effect2.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif

    }
}
