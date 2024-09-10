using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public float PlayerSpeed;
    public float PlayerDamage;
    public float FireRate;
    public float FireRange;
    public float TimeBetweenDamage = 1f;

    private float _damageMoment;

    public void ReceiveDamage(float damage)
    {
        if(Time.time - _damageMoment >= TimeBetweenDamage)
        {
            CurrentHealth -= damage;
            _damageMoment = Time.time;
        }
    }


}

