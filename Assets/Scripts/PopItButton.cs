using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopItButton : MonoBehaviour
{
	private bool _isPop = false;

	private void OnMouseEnter()
	{
		if (InputHandler.Instance.IsDown)
		{
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

	private void OnMouseDown()
	{
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
