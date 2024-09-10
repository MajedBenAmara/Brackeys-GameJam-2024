using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Enemy : MonoBehaviour
{
    public string EnemyName;
    [SerializeField]
    private float _health;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private float _distanceromPlayer = .7f;
    [SerializeField]
    private Transform _model;
    internal bool EnemyIsDead = false;

    void Update()
    {
        ChasePlayer();
        FacePlayer();
        ManageHealth();
    }


    public void ChasePlayer()
    {
        if (Vector2.Distance(transform.position, PlayerManager.instance.playerGameObject.transform.position) > _distanceromPlayer)
        {
            Vector2 directionToPlayer = PlayerManager.instance.playerGameObject.transform.position - transform.position;
            transform.Translate(directionToPlayer.normalized * Speed * Time.deltaTime);
        }

    }

    // The player will recieve dmg the moment he enter the collision and if he stay in the collision 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("ReceiveDamage", _damage);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("ReceiveDamage", _damage);
        }

    }

    protected void FacePlayer()
    {
        if (PlayerManager.instance.playerGameObject != null)
        {
            // calaculate direction from enemy to player
            Vector2 direction = PlayerManager.instance.playerGameObject.transform.position - transform.position;

            // calculate the angle of the direction vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if ((angle < 90) && (angle > -90))
            {
                _model.localScale = new Vector2(Mathf.Abs(_model.localScale.x), _model.localScale.y);

            }
            else
            {
                _model.localScale = new Vector2(-Mathf.Abs(_model.localScale.x), _model.localScale.y);
            }
        }
    }

    public void ReceiveDamage(float damage)
    {
        Debug.Log("Enemy damaged");
        _health -= damage;
    }

    private void ManageHealth()
    {
        if(_health <= 0)
        {
            Death();
        }
    }
    // Defining what happen when the enemy is dead
    private void Death()
    {
        Destroy(gameObject);
    }
}
