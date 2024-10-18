using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;

    private string _parametrName;

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void Initilization(string parametrName)
    {
        float minValueInDecibels = -80f;
        float maxValueInDecibels = 0f;

        _parametrName = parametrName;

        _mixer.audioMixer.GetFloat(_parametrName, out float valueInDecibels);
        float valueToSlider = Mathf.InverseLerp(minValueInDecibels, maxValueInDecibels, valueInDecibels);
        _slider.value = valueToSlider;
        Debug.Log($"valueInDecibels:{valueInDecibels} valueToSlider:{valueToSlider}");
        _slider.onValueChanged.AddListener(ChangeVolume);
    }

    private void ChangeVolume(float valueSlider)
    {
        float maxSoundValue = 1f;
        float minSoundValue = 0.0001f;
        float correctionNumber = 20f;
        Debug.Log($"valueSlider{valueSlider}");
        valueSlider = Mathf.Clamp(valueSlider, minSoundValue, maxSoundValue);
        _mixer.audioMixer.SetFloat(_parametrName, Mathf.Log10(valueSlider) * correctionNumber);
    }
}
