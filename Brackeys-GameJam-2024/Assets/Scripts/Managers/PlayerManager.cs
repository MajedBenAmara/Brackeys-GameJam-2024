using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject playerGameObject;
    public PlayerStats PlayerStats;
    public PlayerCombat PlayerCombat;
    private void Awake()
    {
        instance = this;
    }

}
