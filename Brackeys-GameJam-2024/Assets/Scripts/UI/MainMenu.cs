using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] MenuScreen;
    [SerializeField] AudioMixer audioMixer;


    private void Start()
    {
        EnableScreen(MenuScreen[0]);
        FindAnyObjectByType<AudioManager>().Stop("Combat");
        FindAnyObjectByType<AudioManager>().Stop("Stage");
        FindAnyObjectByType<AudioManager>().Stop("Shop");
        FindAnyObjectByType<AudioManager>().Play("Menu");
    }
    public void LoadScene(string Scene)
    {
        FindAnyObjectByType<AudioManager>().Stop("Menu");
        SceneManager.LoadScene(Scene);

    }

    public void EnableScreen(GameObject Screen)
    {
        foreach (GameObject item in MenuScreen) 
        {
            if (item == Screen)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }


    public void SetVolume(Slider VolumeSlider)
    {
        float volume = VolumeSlider.value;
        audioMixer.SetFloat(VolumeSlider.name, volume);
    }


    public void Redirect(string Link)
    {
        Application.OpenURL(Link);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
