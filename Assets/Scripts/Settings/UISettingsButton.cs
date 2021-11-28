using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsButton : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Button>().onClick.AddListener(SettingsHandler.Instance.CreateSettings);
    }
}
