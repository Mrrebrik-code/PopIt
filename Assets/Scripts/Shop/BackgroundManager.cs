using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public static BackgroundManager Instance;
    [SerializeField] private List<Product> _products;
    private Product _product;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (var product in _products)
        {
            var tempName = PlayerPrefs.GetString("product_set");
            if (tempName == product.Name)
            {
                SetProduct(product);
            }
        }

    }

    public Sprite GetBackground()
    {
        return _product != null ? _product.Background : null;
    }

    public void SetProduct(Product product)
    {
        _product = product;
    }
}
