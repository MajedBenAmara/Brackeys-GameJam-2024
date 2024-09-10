using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    private float _travelSpeed;
    private Rigidbody2D _rb;
    private bool _canDestroy;
    private float _instantiationTime;
    private Vector2 _moveDirection;
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
        ManageDestructionTime();
        DestroyCannonBall();
    }
    private void FixedUpdate()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        _rb.velocity = _moveDirection * _travelSpeed ;
    }

    private void ManageDestructionTime()
    {
        if(Time.time - _instantiationTime > PlayerManager.instance.PlayerStats.FireRange)
        {
            _canDestroy = true;
        }
    }

    private void DestroyCannonBall()
    {
        if(_canDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SendMessage("ReceiveDamage", PlayerManager.instance.PlayerStats.PlayerDamage);
            _canDestroy = true;
        }
    }
}
