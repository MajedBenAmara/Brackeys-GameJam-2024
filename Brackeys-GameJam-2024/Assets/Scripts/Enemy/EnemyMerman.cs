using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMerman : Enemy
{
    [SerializeField]
    private float _timeBetweenAttacks;
    private float _attackMoment;

    private void Update()
    {
        ManageStates();
        FacePlayer();
    }

    private void Attack()
    {
        if (Time.time - _attackMoment > _timeBetweenAttacks)
        {
            _ModelAnim.Play("attack_anim");
            //_anim.Play(_orcIdleAnim);
            if (_ModelAnim.GetCurrentAnimatorStateInfo(0).IsName("attack_anim")
                    && _ModelAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > .99f)
            {
                _ModelAnim.Play("idle_anim");
                _attackMoment = Time.time;
            }
        }
    }

    private void ManageStates()
    {
        Vector2 playerPos = PlayerManager.instance.playerGameObject.transform.position;

        if (Vector2.Distance(transform.position, playerPos) < _distanceFromPlayer)
        {
            Attack();
        }
        else
        {
            ChasePlayer();
        }
    }
}