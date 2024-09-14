using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{

    public string Name;
    [TextArea] public string Description;
    public float Size;
    public Sprite Sprite;
    public int Price;
    public UnityEvent PowerUp;

    public void Buy()
    {
        FindAnyObjectByType<AudioManager>().Play("Upgrade");
        PowerUp?.Invoke();  
    }
    public void Health()
    {
        PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().AddHealth(Size, Price);
    }

    public void MaxHealth()
    {
        PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().AddMaxHealth(Size, Price);
    }
    public void Damage()
    {
        PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().IncreaseDamage(Size, Price);
    }

    public void Firerate()
    {
        PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().changeFireRate(Size, Price);
    }

    public void FireRange()
    {
        PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().changeFireRange(Size, Price);
    }

}
