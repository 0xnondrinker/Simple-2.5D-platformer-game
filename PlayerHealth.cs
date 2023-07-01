using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;
    private bool _invulnerable = false;
    public AudioSource PickUpHealthSound;
    //public AudioSource TakeDamageSound;
    public HealthUI HealthUI;
    //public DamageScreen DamageScreen;
    //public Blink Blink;
    public UnityEvent EventsOnDamage;


    public void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }
    public void TakeDamage ( int damageValue)
    {
        if (_invulnerable == false)
        {
            Health -= damageValue;
            _invulnerable = true;
            Invoke("InvulnerableOff", 1f);
            //TakeDamageSound.Play();
            HealthUI.DisplayHealth(Health);
            //DamageScreen.StartEffect();
            //Blink.StartEffect();
            EventsOnDamage.Invoke();
            if (Health <= 0)
            {
                Health = 0;
                Die();
            }
        }
        
    }

    public void InvulnerableOff()
    {
        _invulnerable = false;
    }

    public void AddHealth (int healthValue)
    {
        Health += healthValue;
        PickUpHealthSound.Play();
        HealthUI.DisplayHealth(Health);
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }
    public void Die()
    {
        Debug.Log("You lose");
    }
}
