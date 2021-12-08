using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product_Bacground_type", menuName = "Shop/Product")]
public class Product : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _backgroundSprite;

    public string Name { get { return _name; } }
    public int Price { get { return _price; } }
    public Sprite Background { get { return _backgroundSprite; } }
}
