using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBtn : MonoBehaviour
{
    public string[] EnemiesType;
    public int[] EnemiesNumber;

    private EnemyToCreate[] _enemy;

    public void EnterStage()
    {
        _enemy = new EnemyToCreate[EnemiesType.Length];
        for (int i = 0; i < EnemiesType.Length; i++)
        {
            EnemyToCreate e = new EnemyToCreate();
            e.EnemyType = EnemiesType[i];
            e.EnemyNumber = EnemiesNumber[i];
            _enemy[i]= e;

            Debug.Log("enemy info = " + _enemy[i].EnemyType + " " + _enemy[i].EnemyNumber);
        }


        EnemiesCreator.Instance.StartCreateProcess(_enemy);
        EnemiesCreator.Instance.StartCoroutine(EnemiesCreator.Instance.CreateEnemy());
    }
}
