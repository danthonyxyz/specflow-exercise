Feature: Calculating the total cost of an order

    Background:
        Given a starter price of £4.00
        And a main price of £7.00
        And a drink price of £2.50
        And a service charge of 10%

    Scenario: Creating an order
        Given a new order
        When 4 starters are added
        And 4 mains are added
        And 4 drinks are added
        Then the total should be £59.40

    Scenario: Appending items to an order
        Given a new order
        When 1 starter is added
        And 2 mains are added
        And 2 more mains are added
        Then the total should be £35.20