using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidWaves : Projectil
{
    [SerializeField]
    private float _wavesDamage = 2f;
    [SerializeField]
    private float _range; 

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _moveDirection = PlayerManager.instance.playerGameObject.transform.position - transform.position;
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
        HitTarget(collision, "Player", _wavesDamage);
    }
}
