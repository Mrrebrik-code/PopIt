using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISoundTap : MonoBehaviour
{
	private void OnEnable()
	{
		GetComponent<Button>().onClick.AddListener(TapSound);
	}

	private void TapSound()
	{
		AudioHandler.Instance.PlaySound(TypeSounds.Tap);
	}
}
