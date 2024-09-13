using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStageManager : MonoBehaviour
{
    public static CombatStageManager instance;
    public GameObject ClearStageScreen, StageSelectionScreen;

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
        ClearStageScreen.SetActive(false);
        StageSelectionScreen.SetActive(true);

    }
}
