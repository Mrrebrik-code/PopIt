using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductHolder : MonoBehaviour
{
    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private GameObject _buttonSelected;
    [SerializeField] private GameObject _buttonHighlight;
    [SerializeField] private Text _priceText;
    [SerializeField] private Image _iamgeBackground;

    [SerializeField] private Product _product;
    public bool IsBuy = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey($"product_{_product.Name}"))
        {
            IsBuy = Convert.ToBoolean(PlayerPrefs.GetInt($"product_{_product.Name}"));

        }
        _priceText.text = _product.Price.ToString();
        _iamgeBackground.sprite = _product.Background;
        SwitchButton();

        if (IsBuy)
        {
            if (_product.Name == PlayerPrefs.GetString("product_set"))
            {
                SelectedButton();
            }
        }
    }

    internal void SelectedButton()
    {
        _buttonHighlight.gameObject.SetActive(true);
        _buttonSelected.SetActive(false);
    }

    internal void UnSelectedButton()
    {
        _buttonHighlight.gameObject.SetActive(false);
        _buttonSelected.SetActive(true);
    }

    public void TryBuy()
    {
        var money = PlayerPrefs.GetInt("money");
        if(money >= _product.Price)
        {
            money -= _product.Price;
            PlayerPrefs.SetInt("money", money);
            MenuHandler.Instance.UpdateMoney();
            IsBuy = true;
            PlayerPrefs.SetInt($"product_{_product.Name}", 1);
            Selected();
        }

        SwitchButton();
    }

    public void Selected()
    {
        MenuHandler.Instance.UnSelectedButton(this);
        BackgroundManager.Instance.SetProduct(_product);
        PlayerPrefs.SetString("product_set", _product.Name);
    }

    private void SwitchButton()
    {
        if (IsBuy)
        {
            _buttonBuy.SetActive(false);
            _buttonSelected.SetActive(true);
        }
        else
        {
            _buttonBuy.SetActive(true);
            _buttonSelected.SetActive(false);
        }
    }
}
