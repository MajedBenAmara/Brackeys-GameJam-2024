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
    private GameObject[] _enemy;

    EnemyToCreate[] _enemiesToCreate;
    private bool _startCreating = false;
    public static EnemiesCreator Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void StartCreateProcess(EnemyToCreate[] enemies)
    {
        _enemiesToCreate = enemies;
        _startCreating = true;
    }
    public IEnumerator CreateEnemy()
    {
        if (_startCreating)
        {
            foreach (EnemyToCreate e in _enemiesToCreate)
            {
                int length = e.EnemyNumber;
                GameObject enemy = SearchForEnemy(e.EnemyType);
                for (int i = 0; i < length; i++)
                {
                    Vector2 enemyPos = GetRandomCoor();
                    Instantiate(enemy, enemyPos, Quaternion.identity);
                    yield return new WaitForSeconds(_crationCD);                   
                }
            }
            _startCreating = false;
        }


    }

    private GameObject SearchForEnemy(string type)
    {
        GameObject enemy;
        foreach (GameObject e in _enemy)
        {
            if(e.GetComponent<Enemy>().EnemyName == type)
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
