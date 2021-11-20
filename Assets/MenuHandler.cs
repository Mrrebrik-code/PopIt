using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
	[SerializeField] private TMP_Text _bestScoreBrainText;
	[SerializeField] private TMP_Text _scoreMoneyText;

	private void Awake()
	{
		if (PlayerPrefs.HasKey("money"))
		{
			_scoreMoneyText.text = PlayerPrefs.GetInt("money").ToString();
		}
		else
		{
			PlayerPrefs.SetInt("money", 0);
			_scoreMoneyText.text = "0";
		}

		if (PlayerPrefs.HasKey("best_brain"))
		{
			_bestScoreBrainText.text = "Рекорд: "+ PlayerPrefs.GetInt("best_brain").ToString();
		}
		else
		{
			PlayerPrefs.SetInt("best_brain", 0);
			_bestScoreBrainText.text = "Рекорд: 0"; 
		}
	}
	public void StartGame(string nameScene)
	{
		SceneManager.LoadScene(nameScene);
	}
}
