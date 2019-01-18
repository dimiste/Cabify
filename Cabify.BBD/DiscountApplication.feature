Feature: DiscountApplication
	In order to avoid mistakes
	I want to be told the sum of several products with discount

Scenario Outline: Add several products of shop's Cabify
	Given I have entered <QuantityVoucher>, <QuantityTshirt> and <QuantityMug>  into the application
	When I press calculate price
	Then the result should be <Result> on the screen

	Examples: 
	| QuantityVoucher | QuantityTshirt | QuantityMug | Result |
	| 1               | 1              | 1           | 32.50  |
	| 2               | 1              | 0           | 25.00  |
	| 1               | 4              | 0           | 81.00  |
	| 3               | 3              | 1           | 74.50  |
