using UnityEngine;

public class SoundPanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string MusikVolume = nameof(MusikVolume);

    [SerializeField] private SoundSlider _master;
    [SerializeField] private SoundSlider _buttons;
    [SerializeField] private SoundSlider _musik;

    private void Start()
    {
        _master.Initilization(MasterVolume);
        _buttons.Initilization(ButtonsVolume);
        _musik.Initilization(MusikVolume);
    }
}
