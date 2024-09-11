using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMerman : Enemy
{
    [SerializeField]
    private Animator _tridenAnim;
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
            _tridenAnim.Play("swing_anim");
            //_anim.Play(_orcIdleAnim);
            if (_tridenAnim.GetCurrentAnimatorStateInfo(0).IsName("swing_anim")
                    && _tridenAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > .8f)
            {
                _tridenAnim.Play("idle_anim");
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
            _tridenAnim.Play("idle_anim");
            ChasePlayer();
        }
    }
}