using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBtn : MonoBehaviour
{
    public static event Action<int> OnKillIncrease;

    public string[] EnemiesType;
    public int[] EnemiesNumber;

    private EnemyToCreate[] _enemy;

    public int TotalEnemyNumber;

    public GameObject Boss;

    public void EnterStage()
    {
        FindAnyObjectByType<AudioManager>().Play("EnterCombat");
        _enemy = new EnemyToCreate[EnemiesType.Length];
        for (int i = 0; i < EnemiesType.Length; i++)
        {
            EnemyToCreate e = new EnemyToCreate();
            e.EnemyType = EnemiesType[i];
            e.EnemyNumber = EnemiesNumber[i];
            _enemy[i]= e;

        }


        EnemiesCreator.Instance.StartCreateProcess(_enemy);
        EnemiesCreator.Instance.StartCoroutine(EnemiesCreator.Instance.CreateEnemy());
        CalculateEnemyNumber();
        OnKillIncrease?.Invoke(TotalEnemyNumber);
    }

    private void CalculateEnemyNumber()
    {
        foreach (var item in EnemiesNumber)
        {
            TotalEnemyNumber += item;
        }

        Debug.Log("Total Enemy Number = " + TotalEnemyNumber);
    }

    public void SpawnBoss()
    {
        Instantiate(Boss, Vector3.zero, Quaternion.identity);
    }
}
