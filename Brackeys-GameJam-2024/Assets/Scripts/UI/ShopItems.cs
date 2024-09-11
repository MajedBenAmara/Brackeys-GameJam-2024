using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopItems : MonoBehaviour
{
    [SerializeField] Item[] List;

    [SerializeField] Image ItemSprite;
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
        InfoBox.text = $"Name: {referance.Name}\nDescription: {referance.Description}";
        Price.text = $"Price {referance.Price}G";
        Buy.onClick.RemoveAllListeners();
        Buy.onClick.AddListener(referance.Buy);
    }



    //Need to changed to different script this is for testing
    public Text CurGold;
    
    void updategold()
    {
        CurGold.text = $"Gold: {PlayerManager.instance.playerGameObject.GetComponent<PlayerStats>().Gold}";
    }

    private void Update()
    {
        updategold();
    }
}
