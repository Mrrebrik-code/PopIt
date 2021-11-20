using System.Collections;
using System.Collections.Generic;
using TMPro;
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

	[SerializeField] private TMP_Text _currentRoundText;
	[SerializeField] private TMP_Text _currentCountBlinkText;

	[SerializeField] private TMP_Text _money;

	private void Awake()
	{
		foreach (var button in _buttonsPopit)
		{
			button.onDownButton += OnDownHandler;
		}
		_money.text = PlayerPrefs.GetInt("money").ToString();
		_currentRoundText.text = "Текущий раунд: " + Round;
		_currentCountBlinkText.text = "На память: " + _currentButtons.Count + "шт.";
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
			if (Round > PlayerPrefs.GetInt("best_brain"))
			{
				PlayerPrefs.SetInt("best_brain", Round);
			}
			
			_gameOverPanel.SetActive(true);
		}
		if(_currentButtons.Count == 0)
		{
			Round++;
			_currentRoundText.text = "Текущий раунд: " + Round;
			foreach (var buttonAll in _buttonsPopit)
			{
				buttonAll.IsDown = false;
			}
			_bonusPanel.SetActive(true);
			if (PlayerPrefs.HasKey("money"))
			{
				var temp = PlayerPrefs.GetInt("money");
				temp += 50;
				PlayerPrefs.SetInt("money", temp);
				_money.text = PlayerPrefs.GetInt("money").ToString();
			}
			else
			{
				PlayerPrefs.SetInt("money", 0);
			}
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
		_currentCountBlinkText.text = "На память: " + _currentButtons.Count + "шт.";
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
