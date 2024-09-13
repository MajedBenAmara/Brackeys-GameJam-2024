using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private GameObject _deathScreen;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    public void ManagePausing(InputAction.CallbackContext ctx)
    {
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
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateDeathScreen()
    {
        _deathScreen.SetActive(true);
    }
}
