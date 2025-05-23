#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Death : MonoBehaviour
{
    public SpriteRenderer sptRdr;
    public Sprite Gear;

    public GameObject _player;
    public GameObject _deathmenu;

    public GameObject _effect;
    public GameObject _effect2;

    public AudioSource oldcomputerSound;
    public AudioSource machineSound;
    public AudioSource music;

    public Rigidbody2D _rb2D;
    public Vector2 _deathDestination;

    private void Start()
    {
        _deathmenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            sptRdr.sprite = Gear;

            other.transform.position = _deathDestination;
            _rb2D.velocity = Vector2.zero;

            Time.timeScale = 0;

            _deathmenu.SetActive(true);

            oldcomputerSound.Play();
            music.Pause();

            _effect.SetActive(true);
            _effect2.SetActive(false);
        }
    }

    public void ReStartGame()
    {
        Time.timeScale = 1;

        _deathmenu.SetActive(false);

        oldcomputerSound.Pause();
        machineSound.Play();
        music.Play();

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
