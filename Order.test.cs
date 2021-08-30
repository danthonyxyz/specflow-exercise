using System;
using System.Collections.Generic;
using Xunit;

public class OrderBuilder {
    Dictionary<ItemKind, int> prices = new Dictionary<ItemKind, int>() {
        { ItemKind.STARTER, 400 },
        { ItemKind.MAIN, 700 },
        { ItemKind.DRINK, 250 }
    };
    float serviceCharge = 0.1f;

    public Order Build() {
        return new Order(prices, serviceCharge);
    }
}

public class TestData {
    
}
public class TestAddItem
{
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void AddingItems(int count)
    {
        Order order = new OrderBuilder().Build();

        order.AddItem(ItemKind.STARTER, count);

        Assert.Equal(count, order.items.Count);
    }

    [Fact]
    public void AddingItemsSequentially() {
        Order order = new OrderBuilder().Build();

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
        Order order = new OrderBuilder().Build();

        Assert.Throws<ArgumentException>(() => order.AddItem(ItemKind.DRINK, count));
    }
}

public class TestRemoveItem {

    [Fact]
    public void RemovingItem() {
        Order order = new OrderBuilder().Build();

        Assert.Equal(0, order.items.Count);
        order.AddItem(ItemKind.MAIN, 1);
        order.RemoveItem(ItemKind.MAIN);
        Assert.Equal(0, order.items.Count);
    }

    [Fact]
    public void RemovingMultiple() {
        Order order = new OrderBuilder().Build();

        order.AddItem(ItemKind.DRINK, 4);
        order.AddItem(ItemKind.MAIN, 4);
        order.AddItem(ItemKind.STARTER, 4);
        order.RemoveItem(ItemKind.DRINK);
        order.RemoveItem(ItemKind.MAIN);
        order.RemoveItem(ItemKind.STARTER);
        Assert.Equal(9, order.items.Count);
    }
}