using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class EnemyMermaid : Enemy
{
    [SerializeField]
    private float _escapeDistance;
    private bool _canFire;
    private float _fireTime;
    [SerializeField]
    private Transform _firePoint;
    [SerializeField]
    private Transform _waves;
    [SerializeField]
    private float _fireRate;
    private bool _dontFacePlayer = false;

    void Update()
    {
        ChasePlayer();
        EscapePlayer();
        AttackPlayer();
        if (_dontFacePlayer)
        {
            ReverseFacePlayer();
        }
        else
        {
            FacePlayer();
        }
        
    }



    private void EscapePlayer()
    {
        Vector2 playerPos = PlayerManager.instance.playerGameObject.transform.position;
        Vector2 direction = (Vector2)transform.position - playerPos;

        if (Vector2.Distance(transform.position, playerPos) < _escapeDistance)
        {
            transform.Translate(direction.normalized * Speed * Time.deltaTime);
            _dontFacePlayer = true;
            _ModelAnim.Play("chase_anim");

        }
        else
        {
            _dontFacePlayer = false;
        }

    }

    private void AttackPlayer()
    {
        Vector2 playerPos = PlayerManager.instance.playerGameObject.transform.position;
        float distanceFromPlayer = Vector2.Distance(transform.position, playerPos);
        if(distanceFromPlayer >= _escapeDistance && distanceFromPlayer <= _distanceFromPlayer)
        {
            ManageFireRate();
            FireCanon();

        }
    }

    private void ManageFireRate()
    {
        if (Time.time - _fireTime > _fireRate)
        {
            _canFire = true;
            _fireTime = Time.time;
        }
        else
        {
            _canFire = false;
            if(!_dontFacePlayer && _ModelAnim.GetCurrentAnimatorStateInfo(0).IsName("attack_anim")
                    && _ModelAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > .99f)
                _ModelAnim.Play("idle_anim");

        }
    }

    private void FireCanon()
    {
        if (_canFire)
        {
            Instantiate(_waves, _firePoint.position, _firePoint.rotation);
            _ModelAnim.Play("attack_anim");
        }
    }
    protected void ReverseFacePlayer()
    {
        if (PlayerManager.instance.playerGameObject != null)
        {
            // calaculate direction from enemy to player
            Vector2 direction = PlayerManager.instance.playerGameObject.transform.position - transform.position;

            // calculate the angle of the direction vector
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if ((angle < 90) && (angle > -90))
            {
                _model.localScale = new Vector2(-Mathf.Abs(_model.localScale.x), _model.localScale.y);

            }
            else
            {
                _model.localScale = new Vector2(Mathf.Abs(_model.localScale.x), _model.localScale.y);
            }
        }
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _escapeDistance);

    }
}
