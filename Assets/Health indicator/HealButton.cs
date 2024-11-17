using UnityEngine;
using UnityEngine.UI;

public class HealButton : HearthButton
{
    [SerializeField] private Button _healButton;
    [SerializeField, Min(0f)] private float _healPower;

    private Heart _heart;

    //private void OnEnable()
    //{
    //    _healButton.onClick.AddListener(Heal);
    //}

    private void OnDestroy()
    {
        _healButton.onClick.RemoveListener(Heal);
    }

    private void Heal()
    {
        _heart.Heal(_healPower);
    }

    public override void Initilization(Heart heart)
    {
        _heart = heart;
        _healButton.onClick.AddListener(Heal);
    }
}
