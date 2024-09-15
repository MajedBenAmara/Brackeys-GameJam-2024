using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStageManager : MonoBehaviour
{
    public static CombatStageManager instance;
    public GameObject ClearStageScreen, StageSelectionScreen;
    public Text Stagefinish;

    internal bool StageIsClear = false;

    private int _totalEnemyNb;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        EnemyBtn.OnKillIncrease += ChackKillCount;
    }

    public void CheckClearCondition()
    {
        if(_totalEnemyNb == PlayerManager.instance.PlayerStats.KillScore)
        {
            Stagefinish.text = $"Reward: {PlayerManager.instance.PlayerStats.KillScore * 10} Gold";
            PlayerManager.instance.PlayerStats.Gold += PlayerManager.instance.PlayerStats.KillScore * 10;
            StageIsClear = true; 
            ClearStageScreen.SetActive(true);
        }
    }

    private void ChackKillCount(int count)
    {
        _totalEnemyNb = count;
    }

    // btn func
    public void GoToNext()
    {
        StageIsClear = false;
        PlayerManager.instance.PlayerStats.ResetKillScore();
        Time.timeScale = 1.0f;
        ClearStageScreen.SetActive(false);
        StageSelectionScreen.SetActive(true);

    }
}
