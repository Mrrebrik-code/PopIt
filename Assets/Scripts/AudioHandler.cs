using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeSounds
{
	popOne,
	popTwo
}
public class AudioHandler : MonoBehaviour
{
	public static AudioHandler Instance;
	[SerializeField] private AudioSource _soundSource;
	[SerializeField] private AudioSource _musicSource;

	[SerializeField] private AudioClip[] _audios;

    private void Start()
    {

        if (PlayerPrefs.HasKey("sound"))
        {
			_soundSource.volume = PlayerPrefs.GetFloat("sound");
		}
        else
        {
			_soundSource.volume = 10;
			PlayerPrefs.SetFloat("sound", 10);
		}

        if (PlayerPrefs.HasKey("music"))
        {
			_musicSource.volume = PlayerPrefs.GetFloat("music");
        }
		else
		{
			_musicSource.volume = 10;
			PlayerPrefs.SetFloat("music", 10);
		}
	}

    private void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
		
	}

    public void PlaySound(TypeSounds type)
	{
		_soundSource.PlayOneShot(_audios[(int)type]);
	}

	public void ChangeSoundAndSound(float sound, float music)
    {
		_soundSource.volume = sound;
		_musicSource.volume = music;
    }

}
