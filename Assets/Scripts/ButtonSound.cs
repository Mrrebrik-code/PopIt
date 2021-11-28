using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonSound;
    [SerializeField] private AudioClip _clickButton;

    public void ButtSound()
    {
        _buttonSound.PlayOneShot(_clickButton);
    }
}
