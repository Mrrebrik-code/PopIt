using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItButton : MonoBehaviour
{
	public int Id;
	private bool _isPop = false;

	private GameHandler _gameHandler;

	private void Start()
	{
		_gameHandler = GameHandler.Instance;
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
		ButtonDown();
	}

	private void ButtonDown()
	{
		_gameHandler.BallDestroy(Id);
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
