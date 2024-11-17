using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Heart _heart;
    [SerializeField, Min(0f)] private float _maxHealth;
    [SerializeField, Min(0f)] private float _currentHealth;
    [SerializeField] private HeartListener[] _heartListeners;

    private void Start()
    {
        _heart.Initilization(_maxHealth, _currentHealth);

        for (int i = 0; i < _heartListeners.Length; i++)
        {
            _heartListeners[i].Initilization(_heart, _maxHealth, _currentHealth);
        }
    }
}
