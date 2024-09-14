using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIelements : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Stage;

    bool ShopEnabled;
    bool StageEnabled;


    private void Start()
    {
        ShopEnabled = false;
        StageEnabled = false;
        Shop.SetActive(false);
        Stage.SetActive(false);

        EnableStage();
    }
    /*void Update()
    {
        Time.timeScale = (!ShopEnabled && !StageEnabled)  ? 1.0f : 0.0f;
        if (Input.GetKeyDown(KeyCode.E) && !StageEnabled)
        {
            ShopEnabled = !ShopEnabled;
            Shop.SetActive(ShopEnabled);
        }

        if (Input.GetKeyDown(KeyCode.F) && !ShopEnabled)
        {
            StageEnabled = !StageEnabled;
            Stage.SetActive(StageEnabled);
        }
    }*/


    public void EnableShop()
    {
        ShopEnabled = !ShopEnabled;
        Shop.SetActive(ShopEnabled);
    }

    public void EnableStage() 
    {
        StageEnabled = !StageEnabled;
        Stage.SetActive(StageEnabled);
    }

    public void hidethis(GameObject refer)
    { 
        refer.SetActive(false); 
    }
}
