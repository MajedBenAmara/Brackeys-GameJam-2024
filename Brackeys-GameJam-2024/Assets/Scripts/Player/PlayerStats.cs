using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;
    public float PlayerSpeed;
    public float PlayerDamage;
    public float FireRate;
    public float FireRange;
    public float TimeBetweenDamage = 1f;
    public int Gold = 0;
    public int KillScore = 0;
    public int TotalScore = 0;

    public Slider HpSlider;

    private float _damageMoment;

    private void Start()
    {
        HpSlider.value = CurrentHealth / MaxHealth;
    }
    private void Update()
    {
        HpSlider.value = CurrentHealth / MaxHealth;

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void ReceiveDamage(float damage)
    {
        if(Time.time - _damageMoment >= TimeBetweenDamage)
        {
            CurrentHealth -= damage;
            HpSlider.value = CurrentHealth / MaxHealth;
            GetComponent<FlashEffect>().NormalFlash();
            CheckHP();
            _damageMoment = Time.time;
        }
    }

    public bool AddMaxHealth(float health, int gold)
    {
        if (gold > Gold) return false;

        Gold -= gold;
        MaxHealth += health;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");
        return true;

    }
    public bool AddHealth(float health, int gold)
    {
        if (gold > Gold) return false;


        Gold -= gold;
        CurrentHealth += health;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;

    }

    public bool changeFireRate(float fr, int gold)
    {
        if (gold > Gold) return false;


        Gold -= gold;
        FireRate -= fr;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;

    }

    public bool changeFireRange(float fr, int gold)
    {
        if (gold > Gold) return false;

        Gold -= gold;
        FireRange += fr;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;

    }

    public bool IncreaseDamage(float fr, int gold)
    {
        if (gold > Gold) return false;

        Gold -= gold;
        PlayerDamage += fr;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;

    }

    public bool IncreaseSpeed(float fr, int gold)
    {
        if (gold > Gold) return false;

        Gold -= gold;
        PlayerSpeed += fr;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;

    }

    public bool increaseResistance(float fr, int gold)
    {
        if (gold > Gold) return false;

        Gold -= gold;
        TimeBetweenDamage += fr;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;

    }

    public bool Cannon(float fr,float fr2 ,int gold)
    {
        if (gold > Gold) return false;

        Gold -= gold;
        FireRate -= fr2;
        FireRange += fr;
        FindAnyObjectByType<AudioManager>().Play("Upgrade");

        return true;
    }

    public void CheckHP()
    {
        if(CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            UIManager.Instance.ActivateDeathScreen();
            FindAnyObjectByType<AudioManager>().Play("Dead");
            //gameObject.SetActive(false);
        }
    }

    public void IncreaseKillScore()
    {
        KillScore++;
        TotalScore++;
    }

    public void ResetKillScore()
    {
        KillScore = 0;
    }

}

