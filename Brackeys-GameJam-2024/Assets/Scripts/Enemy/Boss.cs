using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    private bool _canFire;
    private float _fireTime;


    [SerializeField]
    private GameObject projectil;

    [SerializeField]
    private Transform[] _instantiationPoints;
    [SerializeField]
    private float _fireRate, _specialFireRate;
    [SerializeField]
    private float _attackDuration, _restDuration;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private GameObject _endGameScreen;

    private bool _comboActive = false;
    private bool _canCreateProjectil = true;
    private float _attack1Timer, _attack2Timer, _attack3Timer, _restTimer;

    void Update()
    {
        ManageFireRate();
        RotateOrigin();
        AttacksTiming();
    }

    private void ManageFireRate()
    {
        float fireRate ;
        fireRate = (_comboActive)? _specialFireRate : _fireRate;
        if (Time.time - _fireTime > fireRate)
        {
            _canFire = true;
            _fireTime = Time.time;
        }
        else
        {
            _canFire = false;
        }
    }

    private void AttacksTiming()
    {
        if(_attack1Timer > 0)
        {
            _attack1Timer -= Time.deltaTime;
            // attack1
            RapidFire();
        }

        else if(_attack2Timer > 0)
        {
            _attack2Timer -= Time.deltaTime;
            //attack2
            FireRotatingCanon();
        }

        else if(_attack3Timer > 0)
        {
            _attack3Timer -= Time.deltaTime;
            //attack3;
            _comboActive = true;
            WaveFireRate();

            _restTimer = _restDuration;
        }

        else if(_restTimer > 0)
        {
            _restTimer -= Time.deltaTime;
            _comboActive = false;
            
            //resting
        }
        else
        {
            _attack1Timer = _attack2Timer = _attack3Timer = _attackDuration;
        }
    }

    private void RapidFire()
    {
        if (_canFire) 
        {
            for (int i = 1; i < 5; i++)
            {
                CreatProjectil(_instantiationPoints[i]);

            }
        }
    }

    private void FireRotatingCanon()
    {
        if (_canFire)
        {
            CreatProjectil(_instantiationPoints[0]);
        }
    }

    private void WaveFireRate()
    {        
        if (_canFire)
        {
            for (int i = 1; i < _instantiationPoints.Length; i++)
            {

                CreatProjectil(_instantiationPoints[i]);
            
            }
        }
    }

    private void RotateOrigin()
    {
        _instantiationPoints[0].eulerAngles = new Vector3(0f, 0f, _instantiationPoints[0].eulerAngles.z + _rotationSpeed);
    }

    private void CreatProjectil(Transform origin)
    {
        if(_canCreateProjectil)
            Instantiate(projectil, origin.position, origin.rotation);

    }

    protected override void Death()
    {
        _endGameScreen.SetActive(true);
        Destroy(gameObject);

    }
}
