using System;
using TechTalk.SpecFlow;
using Xunit;

[Binding]
public class OrderSteps
{
	readonly OrderContext orderContext;

	public OrderSteps(OrderContext orderContext)
	{
		this.orderContext = orderContext;
	}

	ItemKind ParseItemKind(string itemKindString) {
		ItemKind itemKind;

		switch(itemKindString.ToUpper()) {
			case "STARTERS": itemKind = ItemKind.STARTER;
				break;
			case "MAINS": itemKind = ItemKind.MAIN;
				break;
			case "DRINKS": itemKind = ItemKind.DRINK;
				break;
			default: Enum.TryParse<ItemKind>(itemKindString.ToUpper(), out itemKind);
				break;
		}

		return itemKind;
	}

	[Given(@"a (.*) price of £(.*)")]
	public void GivenItemPrice(ItemKind itemKind, float price)
	{
		orderContext.prices[itemKind] = (int) (price * 100);
	}

	[Given(@"a service charge of (.*)%")]
	public void GivenServiceCharge(float percentage) {
		orderContext.serviceCharge = percentage / 100;
	}

	[Given(@"a new order")]
	public void GivenNewOrder()
	{
		orderContext.order = new Order(orderContext.prices, orderContext.serviceCharge);
	}

	[When(@"([0-9]*)(?: more)? (.*) (?:is|are) added")]
	public void WhenItemsAdded(int count, string itemKindString)
	{
		ItemKind itemKind = ParseItemKind(itemKindString);
		orderContext.order.AddItem(itemKind, count);
	}

	[When(@"a (.*) is removed")]
	public void WhenItemRemoved(string itemKindString) {
		ItemKind itemKind = ParseItemKind(itemKindString);
		orderContext.order.RemoveItem(itemKind);
	}

	[Then(@"the total should be £(.*)")]
	public void ThenCalculateTotal(float total)
	{
		int expected = (int) (total * 100);
		Assert.Equal(expected, orderContext.order.CalculateTotal());
	}
}