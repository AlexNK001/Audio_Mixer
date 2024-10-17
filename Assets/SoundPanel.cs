using UnityEngine;

public class SoundPanel : MonoBehaviour
{
    private const string MasterVolume = nameof(MasterVolume);
    private const string ButtonsVolume = nameof(ButtonsVolume);
    private const string MusikVolume = nameof(MusikVolume);

    protected readonly float _maxSoundValue = 1f;
    protected readonly float _minSoundValue = 0.0001f;

    [SerializeField] private SoundSlider _master;
    [SerializeField] private SoundSlider _buttons;
    [SerializeField] private SoundSlider _musik;

    private bool _isMute;
    private float _currentMasterVolume;

    private void Start()
    {
        _master.Initilization(MasterVolume, PlayerPrefs.GetFloat(MasterVolume, _maxSoundValue));
        _buttons.Initilization(ButtonsVolume, PlayerPrefs.GetFloat(ButtonsVolume, _maxSoundValue));
        _musik.Initilization(MusikVolume, PlayerPrefs.GetFloat(MusikVolume, _maxSoundValue));

        _currentMasterVolume = _master.Volume;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MasterVolume, _master.Volume);
        PlayerPrefs.SetFloat(ButtonsVolume, _buttons.Volume);
        PlayerPrefs.SetFloat(MusikVolume, _musik.Volume);
    }

    public void Mute()
    {
        if (_isMute)
        {
            _master.ChangeVolume(_currentMasterVolume);
            _isMute = false;
        }
        else
        {
            _currentMasterVolume = _master.Volume;
            _master.ChangeVolume(_minSoundValue);
            _isMute = true;
        }
    }
}
