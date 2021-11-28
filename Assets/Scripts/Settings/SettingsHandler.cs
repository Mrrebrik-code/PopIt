using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour
{
    public static SettingsHandler Instance;
    [SerializeField] private GameObject _settings;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateSettings()
    {
        Instantiate(_settings, FindObjectOfType<Canvas>().transform);
    }
}
