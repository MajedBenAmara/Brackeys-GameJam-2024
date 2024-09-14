using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject playerGameObject;
    public PlayerStats PlayerStats;
    public PlayerCombat PlayerCombat;
    public PlayerMovement PlayerMovement;

    public GameObject StageSelectScreen;
    public GameObject ShopScreen;

    private void Awake()
    {
        instance = this;
    }



}
