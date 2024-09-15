using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScreen : MonoBehaviour
{
    static public bool Paused;



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
