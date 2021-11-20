using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrainHandler : MonoBehaviour
{
	[SerializeField] private List<PopItButton> _buttonsPopit = new List<PopItButton>();
	private int Round = 1;
	[SerializeField] private Material _blinkMaterial;
	private List<PopItButton> _currentButtons = new List<PopItButton>();
	[SerializeField] private GameObject _gameOverPanel;
	[SerializeField] private GameObject _bonusPanel;

	private void Awake()
	{
		foreach (var button in _buttonsPopit)
		{
			button.onDownButton += OnDownHandler;
		}
	}

	private void OnDownHandler(PopItButton button)
	{
		if (_currentButtons[0] == button)
		{
			_currentButtons.Remove(button);
		}
		else
		{
			foreach (var buttonAll in _buttonsPopit)
			{
				buttonAll.IsDown = false;
			}
			_gameOverPanel.SetActive(true);
		}
		if(_currentButtons.Count == 0)
		{
			Round++;
			foreach (var buttonAll in _buttonsPopit)
			{
				buttonAll.IsDown = false;
			}
			_bonusPanel.SetActive(true);
		}
	}
	public void Start()
	{
		SetRound();
	}
	public List<PopItButton> RandomGenerationButtons()
	{
		List<PopItButton> tempButtons = new List<PopItButton>();
		var count = Random.Range(2, 6) + Round;
		if(count < _buttonsPopit.Count)
		{
			for (int i = 0; i < count; i++)
			{
				tempButtons.Add(_buttonsPopit[Random.Range(0, _buttonsPopit.Count)]);
			}

		}
		else
		{
			for (int i = 0; i < 15; i++)
			{
				tempButtons.Add(_buttonsPopit[Random.Range(0, _buttonsPopit.Count)]);
			}
		}

		return tempButtons;
	}

	public void SetRound()
	{
		foreach (var button in _buttonsPopit)
		{
			button.IsDown = false;
		}
		StartCoroutine(Delay());
	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds(0.3f);
		_currentButtons = RandomGenerationButtons();
		foreach (var button in _currentButtons)
		{
			button.Blink(_blinkMaterial);
			yield return new WaitForSeconds(2f);
		}
		foreach (var button in _buttonsPopit)
		{
			button.IsDown = true;
		}
	}

	public void ReplayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void ExitMune()
	{
		SceneManager.LoadScene(0);
	}
}
