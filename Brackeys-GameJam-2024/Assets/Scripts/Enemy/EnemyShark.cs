using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShark : Enemy
{
    void Update()
    {
        ChasePlayer();
        FacePlayer();
    }
}
