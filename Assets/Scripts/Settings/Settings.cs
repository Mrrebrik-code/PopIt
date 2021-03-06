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
        if (PlayerPrefs.HasKey("sound") && PlayerPrefs.HasKey("music"))
        {
            _soundValue = _soundSlider.value = PlayerPrefs.GetFloat("sound");
            _musicValue = _musicSlider.value = PlayerPrefs.GetFloat("music");
        }
		else
		{
            _soundValue = _soundSlider.value = 1;
            _musicValue = _musicSlider.value = 1;

            PlayerPrefs.SetFloat("sound", _soundValue);
            PlayerPrefs.SetFloat("music", _musicValue);
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
        AudioHandler.Instance.PlaySound(TypeSounds.Tap);
        PlayerPrefs.SetFloat("sound", _soundValue);
        PlayerPrefs.SetFloat("music", _musicValue);

        DestroyImmediate(gameObject);
    }
}
