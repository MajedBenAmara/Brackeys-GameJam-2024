using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemiesCreator : MonoBehaviour
{
    [SerializeField]
    private float _innerRing, _outerRing;
    [SerializeField]
    private float _crationCD = 1;
    private float _creationTime;
    [SerializeField]
    private Enemy[] _enemy;

    EnemyToCreate[] _enemiesToCreate;
    private bool _startCreating = false;
    public static EnemiesCreator Instance;
    private void Awake()
    {
        Instance = this;
    }
    // try making a SO that hase enemyType(string) and enemyNumber(int) and make a list of SO and just go through that list and start creating enemies
    private void Update()
    {
        CreateEnemy();
    }



    public void StartCreateProcess(EnemyToCreate[] enemies)
    {
        _enemiesToCreate = enemies;
        _startCreating = true;
    }
    private void CreateEnemy()
    {
        if (!_startCreating)
            return;
        foreach (EnemyToCreate e in _enemiesToCreate)
        {
            int length = e.EnemyNumber;
            Enemy enemy = SearchForEnemy(e.EnemyType);
            for (int i = 0; i < length; i++)
            {
                if (Time.time - _creationTime > _crationCD)
                {
                    _creationTime = Time.time;
                    Vector2 enemyPos = GetRandomCoor();
                    Debug.Log("Pos = " + enemyPos);
                    Instantiate(enemy, enemyPos, Quaternion.identity);
                    length--;
                }
            }
        }
        _startCreating = false;

        /*        if (Time.time - _creationTime > _crationCD)
                {
                    _creationTime = Time.time;
                    Vector2 enemyPos = GetRandomCoor();
                    Debug.Log("Pos = " + enemyPos);
                    Instantiate(_enemy, enemyPos, Quaternion.identity);
                }*/

    }

    private Enemy SearchForEnemy(string type)
    {
        Enemy enemy = new Enemy();
        foreach (Enemy e in _enemy)
        {
            if(e.EnemyName == type)
            {
                enemy = e;
                return enemy;
            }
        }
        return null;
    }
    private Vector2 GetRandomCoor()
    {
        float posX = Random.Range(_innerRing, _outerRing);
        float posY = Random.Range(_innerRing, _outerRing);
        float negX = Random.Range(-_outerRing, -_innerRing);
        float negY = Random.Range(-_outerRing, -_innerRing);

        float posX2 = Random.Range(0, _innerRing);
        float posY2 = Random.Range(0, _outerRing);
        float negX2 = Random.Range(-_innerRing, 0);
        float negY2 = Random.Range(-_outerRing, 0);

        float finX, finY;
        float finX2, finY2;

        if (Random.value < 0.5f) finY2 = posY2; else finY2 = negY2;
        if (Random.value < 0.5f) finX = posX; else finX = negX;

        Vector2 res1 = new Vector2(finX, finY2);

        if (Random.value < 0.5f) finX2 = posX2; else finX2 = negX2;
        if (Random.value < 0.5f) finY = posY; else finY = negY;

        Vector2 res2 = new Vector2(finX2, finY);

        Vector2 finRes;

        if (Random.value < 0.5f) finRes = res1; else finRes = res2;

        return finRes;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector2(_innerRing * 2, _innerRing * 2));

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(_outerRing * 2, _outerRing * 2));
    }
}
