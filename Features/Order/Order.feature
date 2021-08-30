Feature: Calculating the total cost of an order

    Background:
        Given a starter price of £4.00
        Given a main price of £7.00
        Given a drink price of £2.50

    Scenario: Adding items to an order
        Given a new order
        When 4 starters are added
        And 4 mains are added
        And 4 drinks are added
        Then the total should be £59.40