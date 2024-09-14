using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectil : Projectil
{
    [SerializeField]
    private float _range;
    [SerializeField]
    private float _damage;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _moveDirection = transform.up;
        _instantiationTime = Time.time;
    }

    private void Update()
    {
        ManageDestructionTime(_range);
        DestroyProjectil();
    }
    private void FixedUpdate()
    {
        MoveProjectil();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HitTarget(collision, "Player", _damage);
    }
}
