using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacgroundHolder : MonoBehaviour
{
    [SerializeField] private Image _bacground;

    private void Awake()
    {
        var sprite = BackgroundManager.Instance.GetBackground();
        if(sprite != null)
		{
            _bacground.sprite = sprite;
        }
       
    }
}
