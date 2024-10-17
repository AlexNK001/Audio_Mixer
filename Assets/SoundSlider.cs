using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] protected AudioMixerGroup _mixer;
    [SerializeField] protected Slider _slider;

    protected readonly float _maxSoundValue = 1f;
    protected readonly float _minSoundValue = 0.0001f;
    protected string _parametrName;
    protected float _correctionNumber = 20f;

    public float Volume { get; protected set; }

    public void Initilization(string parametrName, float volume)
    {
        _parametrName = parametrName;
        Volume = volume;
        _slider.value = Volume;
    }

    public void ChangeVolume(float value)
    {
        value = Mathf.Clamp(value, _minSoundValue, _maxSoundValue);
        Volume = value;
        _mixer.audioMixer.SetFloat(_parametrName, Mathf.Log10(Volume) * _correctionNumber);
    }
}
