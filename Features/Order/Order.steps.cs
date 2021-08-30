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

	[Given(@"a (.*) price of £(.*)")]
	public void GivenItemPrice(ItemKind itemKind, float price) {
		orderContext.prices[itemKind] = (int) (price * 100);
	}

	[Given(@"a new order")]
	public void GivenNewOrder(){
		orderContext.order = new Order(orderContext.prices);
	}

	[When(@"([0-9]*) (.*) are added")]
	public void WhenItemsAdded(int count, string item) {
		ItemKind itemKind;
		
		switch(item.ToUpper()) {
			case "STARTERS": itemKind = ItemKind.STARTER; 
				break;
			case "MAINS": itemKind = ItemKind.MAIN;
				break;
			case "DRINKS": itemKind = ItemKind.DRINK;
				break;
			default: Enum.TryParse<ItemKind>(item, out itemKind); 
				break;
		}

		orderContext.order.AddItem(itemKind, count);
	}

	[Then(@"the total should be £(.*)")]
	public void ThenCalculateTotal(float total)
	{
		int expected = (int) (total * 100);
		Assert.Equal(expected, orderContext.order.CalculateTotal());
	}
/* 
	[When(@"action")]
	public void WhenAction(){
		Console.WriteLine("When Some conditions");
	}

	[Then(@"testable outcome")]
	public void ThenTestableOutcome(){
		Console.WriteLine("Then some outcome");
		Assert.True(true,"expected true but fund false");
	} */
}