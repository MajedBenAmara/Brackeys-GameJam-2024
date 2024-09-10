using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject[] MenuScreen;


    private void Start()
    {
        EnableScreen(MenuScreen[0]);
    }
    public void LoadScene(string Scene)
    {
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
}
