using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatStageManager : MonoBehaviour
{
    public static CombatStageManager instance;
    public GameObject ClearStageScreen, StageSelectionScreen;
    public Text Stagefinish;
    public Button enemyButton;

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

    private void Update()
    {
        if (StageSelectionScreen != null)
        {
            if(StageSelectionScreen.GetComponent<StageSelection>().currentnode.IsCompleted)
            {
                enemyButton.interactable = false;
            }
            else
            {
                enemyButton.interactable = true;
            }
        }
    }

    public void CheckClearCondition()
    {
        if(_totalEnemyNb == PlayerManager.instance.PlayerStats.TotalScore)
        {
            Stagefinish.text = $"Reward: {PlayerManager.instance.PlayerStats.KillScore * 10} Gold";
            PlayerManager.instance.PlayerStats.Gold += PlayerManager.instance.PlayerStats.KillScore * 10;
           
            StageIsClear = true; 
            StageSelectionScreen.GetComponent<StageSelection>().currentnode.IsCompleted = true;
            StageSelectionScreen.GetComponent<StageSelection>().disablecurbutton();
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
        //ClearStageScreen.SetActive(false);
        //StageSelectionScreen.SetActive(true);

    }
}
