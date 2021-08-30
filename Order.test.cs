using System;
using System.Collections.Generic;
using Xunit;

public class TestAddItem
{
    readonly Dictionary<ItemKind, int> PRICES = new Dictionary<ItemKind, int>() {
        { ItemKind.STARTER, 400 },
        { ItemKind.MAIN, 700 },
        { ItemKind.DRINK, 250 }
    };

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void AddingItems(int count)
    {
        Order order = new Order(PRICES);

        order.AddItem(ItemKind.STARTER, count);

        Assert.Equal(count, order.items.Count);
    }

    [Fact]
    public void AddingItemsSequentially() {
        Order order = new Order(PRICES);

        order.AddItem(ItemKind.STARTER, 1);
        order.AddItem(ItemKind.MAIN, 2);
        order.AddItem(ItemKind.DRINK, 3);

        Assert.Equal(6, order.items.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-5)]
    public void AddingInvalidNumberOfItems(int count) {
        Order order = new Order(PRICES);

        Assert.Throws<ArgumentException>(() => order.AddItem(ItemKind.DRINK, count));
    }
}

public class TestRemoveItem {

}