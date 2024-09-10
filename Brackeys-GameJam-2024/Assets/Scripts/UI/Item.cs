using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public string Name;
    [TextArea] public string Description;
    public Sprite Sprite;
    public int Price;
    public UnityEvent PowerUp;

    public void Buy()
    {
        PowerUp?.Invoke();  
    }
    public void Heal()
    {
        Debug.Log("+100 HP");
    }

    public void damage()
    {
        Debug.Log("hoo nooo!");
    }

    public void shipstreangth()
    {
        Debug.Log("ship upgraded!!");
    }

    public void IDK()
    {
        Debug.Log("IDK!!!!!!!");
    }

}
