using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [System.Serializable]
    public class ItemLevel
    {
        public string Name;
        [TextArea] public string Description;
        public float Size;
        public float Size2;
        public int Price;
    }

    public List<ItemLevel> Levels = new List<ItemLevel>();
    public string Name;
    public string Description;
    public float Size;
    public float Size2;

    public bool unlimited;

    public Sprite Sprite;
    public int Price;
    public UnityEvent PowerUp;

    public int currentLevel = 0;

    private void Start()
    {
        UpdateItemDetails();
    }
    public void Buy()
    {
        if (currentLevel < Levels.Count )
        {
            PowerUp?.Invoke();

            if (currentLevel < Levels.Count)
            {
                UpdateItemDetails();
            }
            else
            {
                Debug.Log("Max level reached.");
            }
        }
        if (unlimited)
        {
            PowerUp?.Invoke();
        }
    }

    void UpdateItemDetails()
    {
        if (currentLevel < Levels.Count)
        {
            Name = Levels[currentLevel].Name;
            Description = Levels[currentLevel].Description;
            Size = Levels[currentLevel].Size;
            Size2 = Levels[currentLevel].Size2;
            Price = Levels[currentLevel].Price;
        }
    }

    public void Cannon()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().Cannon(Size, Size2, Price)) currentLevel++;
        UpdateItemDetails();

    }

    public void Health()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().AddHealth(Size, Price)) currentLevel++;
        UpdateItemDetails();

    }

    public void MaxHealth()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().AddMaxHealth(Size, Price)) currentLevel++;
        UpdateItemDetails();

    }
    public void Damage()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().IncreaseDamage(Size, Price)) currentLevel++;
        UpdateItemDetails();

    }

    public void Speed()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().IncreaseSpeed(Size, Price)) currentLevel++;
        UpdateItemDetails();

    }

    public void Resistance()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().increaseResistance(Size, Price)) currentLevel++;
        UpdateItemDetails();

    }

    public void Firerate()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().changeFireRate(Size, Price)) currentLevel++;
        UpdateItemDetails();

    }

    public void FireRange()
    {
        if (PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().changeFireRange(Size, Price)) currentLevel++;
        UpdateItemDetails();
    }

}
