using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductHolder : MonoBehaviour
{
    [SerializeField] private GameObject _buttonBuy;
    [SerializeField] private GameObject _buttonSelected;
    [SerializeField] private Text _priceText;
    [SerializeField] private Image _iamgeBackground;

    [SerializeField] private Product _product;
    private bool _isBuy = false;

    private void Awake()
    {
        if (PlayerPrefs.HasKey($"product_{_product.Name}"))
        {
            _isBuy = Convert.ToBoolean(PlayerPrefs.GetInt($"product_{_product.Name}"));
        }
        _priceText.text = _product.Price.ToString();
        _iamgeBackground.sprite = _product.Background;
        SwitchButton();
    }

    public void TryBuy()
    {
        var money = PlayerPrefs.GetInt("money");
        if(money >= _product.Price)
        {
            money -= _product.Price;
            PlayerPrefs.SetInt("money", money);
            MenuHandler.Instance.UpdateMoney();
            _isBuy = true;
            PlayerPrefs.SetInt($"product_{_product.Name}", 1);
            Selected();
        }

        SwitchButton();
    }

    public void Selected()
    {
        BackgroundManager.Instance.SetProduct(_product);
        PlayerPrefs.SetString("product_set", _product.Name);
    }

    private void SwitchButton()
    {
        if (_isBuy)
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
