using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItButton : MonoBehaviour
{
	public int Id;
	private bool _isPop = false;

	private GameHandler _gameHandler;
	private DisplayScoreHandler _displayScoreHandler;
	private MeshRenderer _meshRenderer;

	public Action<PopItButton> onDownButton;

	[SerializeField] private bool _isAd;

	public bool IsDown = true;

	private void Awake()
	{
		_gameHandler = GameHandler.Instance;
		_displayScoreHandler = DisplayScoreHandler.Instance;
		_meshRenderer = GetComponent<MeshRenderer>();
	}

	private void OnMouseEnter()
	{
		if (InputHandler.Instance.IsDown)
		{
			ButtonDown();
		}

	}

	private void OnMouseDown()
	{
		if (_isAd)
		{
			//YandexSDK.instance.ShowInterstitial();
		}
		ButtonDown();
	}

	private void ButtonDown()
	{
		if (IsDown)
		{

			if (_gameHandler != null)
			{
				_gameHandler.BallDestroy(Id);
				_displayScoreHandler.UpdateTextScore();
			}
			onDownButton?.Invoke(this);

			if (_isPop)
			{
				AudioHandler.Instance.PlaySound(TypeSounds.popOne);
				_isPop = false;
			}
			else
			{
				AudioHandler.Instance.PlaySound(TypeSounds.popTwo);
				_isPop = true;
			}

			transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 180, 1f);
		}
	}

	public void Blink(Material material)
	{
		var tempMaterial = _meshRenderer.material;
		_meshRenderer.material = material;
		StartCoroutine(Delay(tempMaterial));
	}

	private IEnumerator Delay(Material material)
	{
		yield return new WaitForSeconds(1f);
		_meshRenderer.material = material;
	}
}
