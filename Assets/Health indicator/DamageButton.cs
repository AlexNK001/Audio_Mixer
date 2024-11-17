using UnityEngine;
using UnityEngine.UI;

public class DamageButton : HearthButton
{
    [SerializeField] private Button _damageButton;
    [SerializeField, Min(0f)] private float _damage;

    private Heart _heart;

    //private void OnEnable()
    //{
    //    _damageButton.onClick.AddListener(Attack);
    //}

    private void OnDestroy()
    {
        _damageButton.onClick.RemoveListener(Attack);
    }

    private void Attack()
    {
        _heart.TakeDamage(_damage);
    }

    public override void Initilization(Heart heart)
    {
        _heart = heart;
        _damageButton.onClick.AddListener(Attack);
    }
}
