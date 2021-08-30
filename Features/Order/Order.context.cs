using System.Collections.Generic;

public class OrderContext
{
    public Dictionary<ItemKind, int> prices = new Dictionary<ItemKind, int>();
    public float serviceCharge { get; set; }
    public Order order { get; set; }
}