using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private GameObject _shop;
    [SerializeField]
    private GameObject _selectionStage;

    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _deathScreen;
    [SerializeField]
    private Text _Score;
    [SerializeField]
    private Text _endScore;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
        _deathScreen.SetActive(false);
    }

    public void ManagePausing(InputAction.CallbackContext ctx)
    {
       /* Debug.Log("Hello");
        if (ctx.performed)
        {

            if (_pauseMenu.activeSelf)
            {
                Replay();
            }
            else
            {
                PauseGame();
            }
        }
       */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (_pauseMenu.activeSelf)
            {
                Replay();
                FindAnyObjectByType<AudioManager>().Play("UnPause");

            }
            else
            {
                PauseGame();
                FindAnyObjectByType<AudioManager>().Play("Pause");
            }
        }
        ManageMusic();

    }

    private void ManageMusic()
    {
        if (_selectionStage.activeSelf)
        {
            FindAnyObjectByType<AudioManager>().PlayOnUpdate("Stage");
        }
        else
        {
            FindAnyObjectByType<AudioManager>().Stop("Stage");
        }

        if (_shop.activeSelf)
        {
            FindAnyObjectByType<AudioManager>().PlayOnUpdate("Shop");
        }
        else
        {
            FindAnyObjectByType<AudioManager>().Stop("Shop");
        }

        if (!(_selectionStage.activeSelf || _shop.activeSelf))
        {
            FindAnyObjectByType<AudioManager>().PlayOnUpdate("Combat");
        }
        else
        {
            FindAnyObjectByType<AudioManager>().Stop("Combat");

        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("time scale = " +  Time.timeScale);   
        _pauseMenu.SetActive(true);
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        Debug.Log("time scale = " + Time.timeScale);
        _pauseMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        FindAnyObjectByType<AudioManager>().Stop("Combat");
        FindAnyObjectByType<AudioManager>().Stop("Stage");
        FindAnyObjectByType<AudioManager>().Stop("Shop");
        SceneManager.LoadScene(0);
    }

    public void GoMainMenu(string me)
    {
        FindAnyObjectByType<AudioManager>().Stop("Combat");
        FindAnyObjectByType<AudioManager>().Stop("Stage");
        FindAnyObjectByType<AudioManager>().Stop("Shop");
        SceneManager.LoadScene(me);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateDeathScreen()
    {
        _Score.text = $"Score : {PlayerManager.instance.PlayerStats.TotalScore}";
        _endScore.text = $"Score : {PlayerManager.instance.PlayerStats.TotalScore}";
        _deathScreen.SetActive(true);
    }
}
