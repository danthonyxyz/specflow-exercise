using System;
using System.Collections.Generic;

public enum ItemKind { STARTER, MAIN, DRINK }

public class Order 
{
    public readonly List<ItemKind> items = new List<ItemKind>();
    readonly Dictionary<ItemKind, int> prices;

    public Order(Dictionary<ItemKind, int> prices) {
        this.prices = prices;
    }

    public void AddItem(ItemKind itemKind, int count) 
    {
        if (count < 1) 
            throw new ArgumentException("'count' must be greater than 0");

        for (int i = 0; i < count; i++) {
            items.Add(itemKind);
        }
    }

    public void RemoveItem(ItemKind itemKind) 
    {

    } 

    public int CalculateTotal()
    {
        return 123;
    }
}