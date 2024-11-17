using System;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private float _maxHealth;
    private float _currentHealth;

    public event Action<float> HealthChanged;

    public void Initilization(float maxHealt,float currentHealt)
    {
        _maxHealth = maxHealt;
        _currentHealth = currentHealt;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged.Invoke(_currentHealth);
    }

    public void Heal(float healPower)
    {
        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + healPower);
        HealthChanged.Invoke(_currentHealth);
    }
}