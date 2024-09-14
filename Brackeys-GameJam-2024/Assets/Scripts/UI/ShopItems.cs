using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    [SerializeField] Item[] List;

    [SerializeField] Image ItemSprite;
    [SerializeField] Text Name;
    [SerializeField] Text InfoBox;
    [SerializeField] Text Price;
    [SerializeField] Button Buy;

    private void Start()
    {
        foreach (Item item in List)
        {
            Button button = item.gameObject.GetComponent<Button>();
            button.onClick.AddListener(() => UpdateScreen(item));
        }
        if(List.Length > 0)
        {

            UpdateScreen(List[0]);
        }
    }

    private void UpdateScreen(Item referance)
    {
        ItemSprite.sprite = referance.Sprite;
        Name.text = referance.Name;
        InfoBox.text = $"{referance.Description}";
        Price.text = $"Price {referance.Price}G";
        Buy.onClick.RemoveAllListeners();
        Buy.onClick.AddListener(referance.Buy);
    }



    //Need to changed to different script this is for testing
    public Text CurGold;
    
    void updategold()
    {
        CurGold.text = 
            $"Gold: {PlayerManager.instance.PlayerStats.Gold}\n" +
            $"Max Health: {PlayerManager.instance.PlayerStats.MaxHealth}\n" +
            $"Speed: {PlayerManager.instance.PlayerStats.PlayerSpeed}\n" +
            $"Damage: {PlayerManager.instance.PlayerStats.PlayerDamage}\n" +
            $"Damage Resistance: {PlayerManager.instance.PlayerStats.TimeBetweenDamage}\n" +
            $"FireRate: {PlayerManager.instance.PlayerStats.FireRate}\n" +
            $"FireRange: {PlayerManager.instance.PlayerStats.FireRange}";
            
    }

    private void Update()
    {
        updategold();
    }
}
