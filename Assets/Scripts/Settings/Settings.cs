using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;

    private float _soundValue;
    private float _musicValue;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            _soundSlider.value = PlayerPrefs.GetFloat("sound");

        }

        if (PlayerPrefs.HasKey("music"))
        {
            _musicSlider.value = PlayerPrefs.GetFloat("music");
        }
        AudioHandler.Instance.ChangeSoundAndSound(_soundValue, _musicValue);
    }

    public void SoundChangeValue()
    {
        _soundValue = _soundSlider.value;
        AudioHandler.Instance.ChangeSoundAndSound(_soundValue, _musicValue);
    }

    public void MusicChangeValue()
    {
        _musicValue = _musicSlider.value;
        AudioHandler.Instance.ChangeSoundAndSound(_soundValue, _musicValue);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("sound", _soundValue);
        PlayerPrefs.SetFloat("music", _musicValue);

        DestroyImmediate(gameObject);
    }
}
