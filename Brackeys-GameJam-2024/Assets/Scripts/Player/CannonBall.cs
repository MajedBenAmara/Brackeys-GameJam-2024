using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonBall : Projectil
{
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _moveDirection = -PlayerManager.instance.PlayerCombat.FireDirection;
        _instantiationTime = Time.time;
    }

    private void Update()
    {
        ManageDestructionTime(PlayerManager.instance.PlayerStats.FireRange);
        DestroyProjectil();
    }
    private void FixedUpdate()
    {
        MoveProjectil();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitTarget(collision, "Enemy", PlayerManager.instance.PlayerStats.PlayerDamage);
    }
}
