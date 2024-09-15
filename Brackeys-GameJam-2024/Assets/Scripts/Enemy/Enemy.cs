using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string EnemyName;
    [SerializeField]
    protected float _health;
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float Speed;
    [SerializeField]
    protected float _distanceFromPlayer = .7f;
    [SerializeField]
    protected Transform _model;
    [SerializeField]
    protected Animator _ModelAnim;

    internal bool EnemyIsDead = false;


    protected void ChasePlayer()
    {
        if (Vector2.Distance(transform.position, PlayerManager.instance.playerGameObject.transform.position) > _distanceFromPlayer)
        {
            Vector2 directionToPlayer = PlayerManager.instance.playerGameObject.transform.position - transform.position;
            transform.Translate(directionToPlayer.normalized * Speed * Time.deltaTime);
            if (_ModelAnim != null) _ModelAnim.Play("chase_anim");

        }

    }

    // The player will recieve dmg the moment he enter the collision and if he stay in the collision 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("ReceiveDamage", _damage);
            if(EnemyName == "Shark")
            {
                _ModelAnim.Play("attack_anim");
            }
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("ReceiveDamage", _damage);
            if (EnemyName == "Shark")
            {
                _ModelAnim.Play("attack_anim");
            }
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
        _health -= damage;
        GetComponent<FlashEffect>().NormalFlash();
        ManageHealth();
    }

    private void ManageHealth()
    {
        if(_health <= 0)
        {
            Death();
        }
    }
    // Defining what happen when the enemy is dead
    protected virtual void Death()
    {
        PlayerManager.instance.PlayerStats.IncreaseKillScore();
        CombatStageManager.instance.CheckClearCondition();
        Destroy(gameObject);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _distanceFromPlayer);
    }
}
