using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
	public static MenuHandler Instance;
	[SerializeField] private TMP_Text _bestScoreBrainText;
	[SerializeField] private TMP_Text _scoreMoneyText;

	[SerializeField] private List<ProductHolder> _productsHolder;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}


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

	public void UnSelectedButton(ProductHolder product)
    {
		_productsHolder.ForEach(productTemp =>
		{
            if (productTemp.IsBuy)
            {
				if (product == productTemp)
				{
					productTemp.SelectedButton();
				}
				else
				{
					productTemp.UnSelectedButton();
				}
			}
			
		});
	}

	public void StartGame(string nameScene)
	{
		SceneManager.LoadScene(nameScene);
	}

	public void UpdateMoney()
    {
		if (PlayerPrefs.HasKey("money"))
		{
			_scoreMoneyText.text = PlayerPrefs.GetInt("money").ToString();
		}
	}
}
