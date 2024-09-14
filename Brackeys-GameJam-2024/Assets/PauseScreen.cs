using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScreen : MonoBehaviour
{
    static public bool Paused;
    public static PauseScreen Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Paused = true;
    }

    private void Update()
    {
        Time.timeScale = (!Paused ? 1.0f : 0.0f);
    }

    public void UnPause()
    {
        Paused = true;
    }

    public void Pause()
    {
        Paused = false;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
