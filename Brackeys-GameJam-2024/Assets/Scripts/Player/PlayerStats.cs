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
    public int Gold = 10000;

    private float _damageMoment;

    public void ReceiveDamage(float damage)
    {
        if(Time.time - _damageMoment >= TimeBetweenDamage)
        {
            CurrentHealth -= damage;
            _damageMoment = Time.time;
        }
    }

    public void AddMaxHealth(float health, int gold)
    {
        if (gold > Gold) return;

        Gold -= gold;
        MaxHealth += health;
    }
    public void AddHealth(float health, int gold)
    {
        if (gold > Gold) return;

        Gold -= gold;
        CurrentHealth += health;

    }

    public void changeFireRate(float fr, int gold)
    {
        if (gold > Gold) return;

        Gold -= gold;
        FireRate -= fr;

    }

    public void changeFireRange(float fr, int gold)
    {
        if (gold > Gold) return;
        Gold -= gold;
        FireRange += fr;

    }

}

