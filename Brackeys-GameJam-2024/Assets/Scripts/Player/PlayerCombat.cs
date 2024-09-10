using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    internal Vector2 FireDirection;
    [SerializeField]
    private Transform _shipModel;
    [SerializeField]
    private Transform _cannonballs;
    [SerializeField]
    private Transform _firePoint;
    private Vector2 _mousePosition, _shootDirection;
    private bool _canFire;
    private float _fireTime;
    private void Update()
    {
        RotateShip();
        ManageFireRate();
        FireCanon();
    }

    private void RotateShip()
    {
        // getting the mouse coor in world space coordiante system
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // calculating the direction from the weapon holder to the mouse
        _shootDirection = (_mousePosition - new Vector2(transform.position.x, transform.position.y)).normalized;

        _shipModel.up = FireDirection = -_shootDirection;
    }

    private void ManageFireRate() 
    {
        if (Time.time - _fireTime > PlayerManager.instance.PlayerStats.FireRate)
        {
            _canFire = true;
            _fireTime = Time.time;
        }
        else
        {
            _canFire = false;
        }
    }

    private void FireCanon()
    {
        if (_canFire)
        {
            Instantiate(_cannonballs, _firePoint.position, _firePoint.rotation);
        }
    }  
}
