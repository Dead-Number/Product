using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerController : MonoBehaviour
{
    public float radius = 2.0f;
    public float impulse = 20.0f;

    public Sprite _gearZero;
    public Sprite _gearOne;
    public Sprite _gearTwo;

    private float _axis;

    public SpriteRenderer _sptRdr;

    public AudioSource _oldcomputerSound;

    public GameObject _pausemenu;
    public GameObject _effect;
    public GameObject _effect2;

    public CLEARDetect CLEARDetect;
    public CLEARDetect2 CLEARDetect2;

    private void Start()
    {
        _sptRdr.sprite = _gearZero;

        _pausemenu.SetActive(false);
    }

    public void Update()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.AddTorque(-impulse * _axis * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        _axis = value.Get<float>();
    }

    private void OnInterract()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D collider in colliders)
        {
            InterractObject InterractObjectComponent = collider.GetComponent<InterractObject>();
            InteractObjectNoScreen InteractObjectNoScreenComponent = collider.GetComponent<InteractObjectNoScreen>();

            if (InterractObjectComponent != null)
            {
                InterractObjectComponent.Activate();
                return;
            }

            else if (InteractObjectNoScreenComponent != null)
            {
                InteractObjectNoScreenComponent.Activate(); 
                return;
            }
        }

    }
    private void OnSwap()
    {
        if (_sptRdr.sprite == _gearZero)
        {
            _sptRdr.sprite = _gearOne;
            return;
        }

        if (_sptRdr.sprite == _gearOne)
        {
            _sptRdr.sprite = _gearTwo;
            return;
        }

        if (_sptRdr.sprite == _gearTwo)
        {
            _sptRdr.sprite = _gearZero;
            return;
        }
    }
    private void OnMenu()
    {
        Time.timeScale = 0;

        _pausemenu.SetActive(true);

        _oldcomputerSound.Play(0);

        _effect.SetActive(true);
        _effect2.SetActive(false);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;

        _pausemenu.SetActive(false);

        _oldcomputerSound.Pause();

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

    public void OnNextLine()
    {
        if (CLEARDetect != null && CLEARDetect.isActiveAndEnabled)
        {
            CLEARDetect.DisplayNextDialogueLine();
        }

        if (CLEARDetect2 != null && CLEARDetect2.isActiveAndEnabled && CLEARDetect.BoolCLEAR == true && CLEARDetect2.CLEAR2Start == true)
        {
            CLEARDetect2.DisplayNextDialogueLine2();
        }
    }
}
