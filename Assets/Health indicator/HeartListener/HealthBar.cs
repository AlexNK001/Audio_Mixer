using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HeartListener
{
    [SerializeField] private Slider _slider;

    private Heart _heart;
    private float _maxHealth;

    private void OnDisable()
    {
        _heart.HealthChanged -= DisplayHealth;
    }

    public override void Initilization(Heart heart, float maxHealth, float currentHealth)
    {
        _heart = heart;
        _heart.HealthChanged += DisplayHealth;
        _maxHealth = maxHealth;
        DisplayHealth(currentHealth);
    }

    private void DisplayHealth(float currentHealth)
    {
        _slider.value = Mathf.InverseLerp(0f, _maxHealth, currentHealth);
    }
}
