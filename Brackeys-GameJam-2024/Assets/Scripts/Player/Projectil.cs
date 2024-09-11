using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField]
    protected float _travelSpeed;
    protected Rigidbody2D _rb;
    protected bool _canDestroy;
    protected float _instantiationTime;
    protected Vector2 _moveDirection;


    protected void MoveProjectil()
    {
        _rb.velocity = _moveDirection * _travelSpeed ;
    }

    protected void ManageDestructionTime()
    {
        if(Time.time - _instantiationTime > PlayerManager.instance.PlayerStats.FireRange)
        {
            _canDestroy = true;
        }
    }

    protected void DestroyProjectil()
    {
        if(_canDestroy)
        {
            Destroy(gameObject);
        }
    }

    protected void HitTarget(Collider2D collision, string targetName, float damage)
    {
        if (collision.gameObject.CompareTag(targetName))
        {
            collision.gameObject.SendMessage("ReceiveDamage", damage);
            _canDestroy = true;
        }
    }
}
