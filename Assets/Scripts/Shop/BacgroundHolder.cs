using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacgroundHolder : MonoBehaviour
{
    [SerializeField] private Image _bacground;

    private void Awake()
    {
        _bacground.sprite = BackgroundManager.Instance.GetBackground();
    }
}
