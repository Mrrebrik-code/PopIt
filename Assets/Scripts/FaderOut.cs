using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FaderOut : MonoBehaviour
{
	[SerializeField] private Image _image;

	private void Start()
	{
		_image.DOFade(0, 2f);
	}
}
