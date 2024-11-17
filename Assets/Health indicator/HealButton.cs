using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Button _healButton;
    [SerializeField, Min(0f)] private float _healPower;
    [SerializeField] private Heart _heart;

    private void OnEnable()
    {
        _healButton.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _healButton.onClick.RemoveListener(Heal);
    }

    private void Heal()
    {
        _heart.Heal(_healPower);
    }
}
